import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ICountry } from '../../../../interfaces/lookups/country';
import { IImage } from '../../../../interfaces/image';
import { IPlayer } from '../../../../interfaces/player';
import { PlayerService } from '../../../../services/player.service';
import { OnDestroy } from '@angular/core';
import { CountryService } from '../../../../services/country.service';
import { ImageService } from '../../../../services/image.service';
import { DetailsBaseComponent } from '../../../base/details-base/details-base.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddressModalComponent } from '../../../shared/address/modal/address-modal.component';
import { IAddress } from '../../../../interfaces/address';
import { AddressPipe } from '../../../../pipes/address.pipe';
import { PositionsPipe } from '../../../../pipes/positions.pipe';
import { TeamPipe } from '../../../../pipes/team.pipe';
import { AddressService } from '../../../../services/address.service';
import { PhoneService } from '../../../../services/phone.service';
import { PhoneModalComponent } from '../../phone/modal/phone-modal.component';
import { StarRatingComponent } from '../../../shared/star-rating/star-rating.component';
import { PitchPositionsModalComponent } from '../../pitch/pitch-positions-modal/pitch-positions-modal.component';
import { IPosition } from '../../../../interfaces/lookups/position';
import { IPlayerPosition } from '../../../../interfaces/joins/player-position';
import { PlayerPositionService } from '../../../../services/player-position.service';
import { PositionService } from '../../../../services/position.service';
import { TeamSelectModalComponent } from '../../team/team-modal/team-select-modal.component';
import { ITeam } from '../../../../interfaces/team';
import { ITeamPlayer } from '../../../../interfaces/joins/team-player';
import { TeamPlayerService } from '../../../../services/team-player.service';

@Component({
  selector: 'sm-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.scss']
})
export class PlayerDetailsComponent extends DetailsBaseComponent<IPlayer> implements OnInit, OnDestroy {
  //#region Properties

  countries: ICountry[];
  image: IImage; //TODO: Create proper Image component
  imageFile: File;
  isNavigationExpanded = true;
  positions: IPosition[];
  primary: "primary";
  //#endregion

  //#region Constructor

  constructor(
    public route: ActivatedRoute,
    public router: Router,
    public formBuilder: FormBuilder,
    public dialog: MatDialog,
    private addressService: AddressService,
    private countryService: CountryService,
    private imageService: ImageService,
    private phoneService: PhoneService,
    private playerService: PlayerService,
    private playerPositionService: PlayerPositionService,
    private positionService: PositionService,
    private teamPlayerService: TeamPlayerService
  ) {
    super("Player", "/players", route, playerService, router);
    this.image = {} as IImage;
    this.imageFile = null;
  }

  //#endregion

  //#region Events

  public ngOnDestroy() {
    super.ngOnDestroy();
  }

  public ngOnInit() {
    super.ngOnInit();

    this._getCountries();
  }

  public onFileSelected(event) {
    this.imageFile = event.target.files[0] as File;
  }

  public onImageUpload(): void {
    this.subscriptions.push(this.imageService.create(this.image, this.imageFile)
      .subscribe(
        data => this.image.id = data,
        error => this.errorMessage = error as string));
  }

  public onSubmit(): void {
    if (this.form.valid) {
      const player = this.form.value;
      player.address.state = null; //TODO:  Are these two lines really needed?
      player.address.country = null; //TODO:  Are these two lines really needed?

      (player?.id) < 1 ? this.onCreate(player) : this.onUpdate(player);
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  //#endregion

  //#region Methods
  public openAddressModal(): void {
    const dialog = this.dialog.open(AddressModalComponent, this._getModalConfig(this.controls.address as FormGroup));

    this.subscriptions.push(dialog.afterClosed()
      .subscribe(result => {
        if (result) {
          this.controls.address.setValue(result?.data);
        }
      }));
  }

  public openPhoneModal(): void {
    const dialog = this.dialog.open(PhoneModalComponent, this._getModalConfig(this.controls.phone as FormGroup));

    this.subscriptions.push(dialog.afterClosed()
      .subscribe(result => {
        if (result) {
          this.controls.playerPositions.setValue(result?.data);
        }
      }));
  }

  public openPositionModal(): void {
    const dialog = this.dialog.open(PitchPositionsModalComponent, this._getPositionModalConfig(this.positions));

    this.subscriptions.push(dialog.afterClosed()
      .subscribe(result => {
        if (result) {
          this.positions = result?.data as IPosition[];
          const playerPositions = this.positionService.toPlayerPositions(this.positions, +this.form.get('id').value);
          this.controls.positions.setValue(this.positions);
          this.controls.playerPositions.setValue(playerPositions);
        }
      }));
  }

  public openTeamModal(): void {
    const dialog = this.dialog.open(TeamSelectModalComponent, this._getModalConfig(this.controls.id.value));

    this.subscriptions.push(dialog.afterClosed()
      .subscribe(result => {
        if (result) {
          const teamPlayer = result?.data as ITeamPlayer;
          const teamPlayers = this.controls.teamPlayers.value as ITeamPlayer[];
          teamPlayers.push(teamPlayer);
          this.controls.teamPlayers.setValue(teamPlayers);
          this._createTeamPlayers(teamPlayer);
        }
      }));
  }

  protected onEntityLoaded() {
    this.positions = this.positionService.toPositions(this.form.get('playerPositions').value);
    this.form.get('positions').setValue(this.positions);
  }

  protected initializeControlReferences() {
    return {
      id: this.form.get('id'),
      firstName: this.form.get('firstName'),
      lastName: this.form.get('lastName'),
      nickName: this.form.get('nickName'),
      height: this.form.get('height'),
      weight: this.form.get('weight'),
      foot: this.form.get('foot'),
      flareRating: this.form.get('flareRating'),
      weakFootRating: this.form.get('weakFootRating'),
      countryId: this.form.get('countryId'),
      readOnly: this.form.get('readOnly'),
      dateOfBirth: this.form.get('dateOfBirth'),
      phone: this.form.get('phone'),
      address: this.form.get('address'),
      positions: this.form.get('positions'),
      playerPositions: this.form.get('playerPositions'),
      teamPlayers: this.form.get('teamPlayers')
    }
  }

  private _deleteImage() {
    this.subscriptions.push(this.imageService.delete(+this.image.id)
      .subscribe(
        data => data,
        error => this.errorMessage = error as string));
  }

  private _getCountries(): void {
    if (!this.countries) {
      this.subscriptions.push(this.countryService.getAll()
        .subscribe(
          data => this.countries = data,
          error => this.errorMessage = error as string));
    }
  }

  private _getModalConfig(data): MatDialogConfig {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "60%";
    dialogConfig.data = data;

    return dialogConfig;
  }

  private _getPositionModalConfig(data): MatDialogConfig {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "550px";
    dialogConfig.height = "965px";
    dialogConfig.data = data;

    return dialogConfig;
  }

  private _createTeamPlayers(teamPlayer: ITeamPlayer): void {
    this.subscriptions.push(this.teamPlayerService.create(teamPlayer)
      .subscribe(
        data => data,
        error => this.errorMessage = error as string));
  }
}
  //#endregion
