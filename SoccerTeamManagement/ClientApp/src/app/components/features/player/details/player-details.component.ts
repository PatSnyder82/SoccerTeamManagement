import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
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
import { AddressService } from '../../../../services/address.service';
import { PhoneService } from '../../../../services/phone.service';
import { PhoneModalComponent } from '../../phone/modal/phone-modal.component';
import { StarRatingComponent } from '../../../shared/star-rating/star-rating.component';

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
    private playerService: PlayerService
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
      player.address.state = null;
      player.address.country = null;

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
    console.log("Before Open Phone Modal - Player: " + JSON.stringify(this.form.value, null, 2));
    const dialog = this.dialog.open(PhoneModalComponent, this._getModalConfig(this.controls.phone as FormGroup));

    this.subscriptions.push(dialog.afterClosed()
      .subscribe(result => {
        if (result) {
          this.controls.phone.setValue(result?.data);
        }
      }));
  }

  protected initializeControlReferences() {
    return {
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
      address: this.form.get('address')
    }
  }

  protected initializeForm(): FormGroup {
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    return this.formBuilder.group({
      id: [0],
      firstName: ['', [Validators.required, Validators.maxLength(100)]],
      lastName: ['', [Validators.required, Validators.maxLength(100)]],
      nickName: ['', [Validators.maxLength(100)]],
      height: [null, [Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]],
      weight: [null, [Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]],
      foot: [1, [Validators.required]],
      weakFootRating: [1, [Validators.required]],
      flareRating: [1, [Validators.required]],
      countryId: [null, [Validators.required]],
      dateOfBirth: [null, [Validators.required]],
      attributesId: [null],

      imageId: [null],
      phoneId: [null],
      phone: this.phoneService.getFormGroup(),
      addressId: [null],
      address: this.addressService.getFormGroup()
      /*//Photo
      image: new FormControl('', Validators.required),
      //Attributes
      //Teams
      teams: new FormControl('', Validators.required),
      positions: new FormControl('', Validators.required),
      parents: new FormControl('', Validators.required)*/
    });
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

  private _getModalConfig(data: FormGroup): MatDialogConfig {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "60%";
    dialogConfig.data = data;

    return dialogConfig;
  }
  onRatingChanged(rating) {
    console.log(rating);
    //this.rating = rating;
  }

  //#endregion
}
