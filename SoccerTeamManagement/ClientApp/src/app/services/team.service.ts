import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, Observable } from 'rxjs';
import { ITeamPlayer } from '../interfaces/joins/team-player';
import { ITeam } from '../interfaces/team';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})

export class TeamService extends BaseService<ITeam> {
  constructor(
    private formBuilder: FormBuilder,
    http: HttpClient, @Inject('BASE_URL') protected baseUrl: string
  ) {
    super(http, 'team/', baseUrl);
  }

  public getByLeague(id: number): Observable<ITeam[]> {
    return this.http.get<ITeam[]>(this.url + 'getteambyleague/' + id.toString())
      .pipe(catchError(this.handleError));
  }

  public getByClub(id: number): Observable<ITeam[]> {
    return this.http.get<ITeam[]>(this.url + 'getteamsbyclub/' + id.toString())
      .pipe(catchError(this.handleError));
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({});
  }

  public toTeams(teamPlayers: ITeamPlayer[]): ITeam[] {
    const teams = [] as ITeam[];

    if (teamPlayers) {
      teamPlayers.forEach(teamPlayer => {
        teams.push(this.toTeam(teamPlayer));
      });
    }

    return teams;
  }

  public toTeamPlayer(teamId: number, playerId: number, joined: Date, departed: Date = null) {
    const teamPlayer = {} as ITeamPlayer;

    teamPlayer.playerId = playerId;
    teamPlayer.teamId = teamId;
    teamPlayer.joinedTeam = joined;
    teamPlayer.departedTeam = departed;

    return teamPlayer;
  }

  public toTeam(teamPlayer: ITeamPlayer) {
    return teamPlayer?.team;
  }
}
