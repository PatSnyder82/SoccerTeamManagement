import { OnDestroy } from '@angular/core';
import { Inject, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { IClub } from '../../../../interfaces/club';
import { ITeamPlayer } from '../../../../interfaces/joins/team-player';
import { ILeague } from '../../../../interfaces/league';
import { ITeam } from '../../../../interfaces/team';
import { ClubService } from '../../../../services/club.service';
import { LeagueService } from '../../../../services/league.service';
import { TeamService } from '../../../../services/team.service';

@Component({
  selector: 'sm-team-select-modal',
  templateUrl: './team-select-modal.component.html',
  styleUrls: ['./team-select-modal.component.scss']
})
export class TeamSelectModalComponent implements OnInit, OnDestroy {
  //#region Properties
  clubs: IClub[];
  controls;
  errorMessage: string;
  form: FormGroup;
  leagues: ILeague[];
  selectedTeam: ITeam;
  subscriptions: Subscription[];
  teams: ITeam[];
  title: string;
  usaCountryCode: number;

  //#endregion

  //#region Constructor

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<TeamSelectModalComponent>,
    @Inject(MAT_DIALOG_DATA) public playerId: number,
    private clubService: ClubService,
    private leagueService: LeagueService,
    private teamService: TeamService
  ) {
    this.errorMessage = '';
    this.clubs = [] as IClub[];
    this.leagues = [] as ILeague[];
    this.selectedTeam = {} as ITeam;
    this.subscriptions = [] as Subscription[];
    this.teams = [] as ITeam[];
  }

  //#endregion

  //#region Events

  ngOnDestroy(): void {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  ngOnInit(): void {
    this.form = this._initializeFormGroup();
    this.controls = this._initializeControlReferences();
    this.controls.clubId.disable();
    this.controls.teamId.disable();
    this._getLeagues();
    this._conditionalValidationOfClubs();
    this._conditionalValidationOfTeams();
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onClubChange(clubId: number): void {
    this._getTeams(clubId);
  }

  public onLeagueChange(leagueId: number): void {
    this._getClubs(leagueId);
    this.controls.teamId.disable();
  }

  public onSubmit(): void {
    if (this.form?.valid) {
      const joinedTeam = this.controls.joinedTeam.value;
      const playerTeam = this.teamService.toTeamPlayer(this.selectedTeam.id, this.playerId, joinedTeam, null);
      this.dialogRef.close({ data: playerTeam as ITeamPlayer })
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  public onTeamChange(teamId: number): void {
    const selectedTeam: ITeam = this.teams.find(x => x.id === teamId);

    if (selectedTeam) {
      this.selectedTeam = selectedTeam;
    }
    else {
      this.selectedTeam = null;
    }
  }

  //#endregion

  //#region Methods

  private _conditionalValidationOfClubs(): void {
    this.subscriptions.push(this.controls.leagueId.valueChanges
      .subscribe(() => {
        if (this.controls.clubId.disabled) {
          this.controls.clubId.clearValidators();
        }
        else {
          this.controls.clubId.setValidators([Validators.required]);
        }

        this.controls.clubId.updateValueAndValidity();
      }));
  }

  private _conditionalValidationOfTeams(): void {
    this.subscriptions.push(this.controls.clubId.valueChanges
      .subscribe(() => {
        if (this.controls.teamId.disabled) {
          this.controls.teamId.clearValidators();
        }
        else {
          this.controls.teamId.setValidators([Validators.required]);
        }

        this.controls.teamId.updateValueAndValidity();
      }));
  }

  private _initializeControlReferences() {
    return {
      leagueId: this.form.get('leagueId'),
      clubId: this.form.get('clubId'),
      joinedTeam: this.form.get('joinedTeam'),
      teamId: this.form.get('teamId')
    };
  }

  private _initializeFormGroup() {
    return this.formBuilder.group({
      leagueId: [null, [Validators.required]],
      clubId: [null],
      joinedTeam: [null, [Validators.required]],
      teamId: [null],
    });
  }

  private _getLeagues(): void {
    this.subscriptions.push(this.leagueService.getAll()
      .subscribe(
        data => this.leagues = data,
        error => this.errorMessage = error as string));
  }

  private _getClubs(leagueId: number): void {
    this.subscriptions.push(this.clubService.getByLeague(leagueId)
      .subscribe(
        data => this.clubs = data,
        error => this.errorMessage = error as string,
        () => this.controls.clubId.enable()));
  }

  private _getTeams(clubId: number): void {
    this.subscriptions.push(this.teamService.getByClub(clubId)
      .subscribe(
        data => this.teams = data,
        error => this.errorMessage = error as string,
        () => this.controls.teamId.enable()));
  }

  //#endregion
}
