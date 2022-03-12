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

@Component({
  selector: 'sm-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.scss']
})
export class PlayerDetailsComponent extends DetailsBaseComponent<IPlayer> implements OnInit, OnDestroy {
  //#region Properties

  countries: ICountry[];
  entity: IPlayer;
  image: IImage; //TODO: Create proper Image component
  imageFile: File

  //#endregion

  //#region Constructor

  constructor(
    public route: ActivatedRoute,
    public router: Router,
    public formBuilder: FormBuilder,
    public dialog: MatDialog,
    private playerService: PlayerService,
    private countryService: CountryService,
    private imageService: ImageService,
    private addressService: AddressService
  ) {
    super("Player", "/players", route, playerService, router);
    this.entity = {} as IPlayer;
    this.entity.address = {} as IAddress;
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

  //#endregion

  //#region Methods
  public openModal(): void {
    const dialog = this.dialog.open(AddressModalComponent, this._getAddressModalConfig(this.form.get('address') as FormGroup));

    this.subscriptions.push(dialog.afterClosed()
      .subscribe(result => {
        if (result) {
          this.form.get('address').setValue(result?.data);
          this.entity.address = result?.data;
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
      countryId: this.form.get('countryId'),
      readOnly: this.form.get('readOnly'),
      dateOfBirth: this.form.get('dateOfBirth'),
      phone: {
        countryCode: this.form.controls.phone.get("countryCode"),
        areaCode: this.form.controls.phone.get("areaCode"),
        extension: this.form.controls.phone.get('extension'),
        number: this.form.controls.phone.get('number'),
        phoneType: this.form.controls.phone.get('phoneType')
      },
      address: this.form.get('address')
    }
  }

  protected initializeForm(): FormGroup {
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    return this.formBuilder.group({
      id: [null],
      firstName: ['', [Validators.required, Validators.maxLength(100)]],
      lastName: ['', [Validators.required, Validators.maxLength(100)]],
      nickName: ['', [Validators.maxLength(100)]],
      height: [null, [Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]],
      weight: [null, [Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]],
      foot: ['', [Validators.required]],
      weakFootRating: [null], //,[Validators.required]
      flareRating: [null, [Validators.required]],
      countryId: [null, [Validators.required]],
      dateOfBirth: [null, [Validators.required]],
      attributesId: [null],
      phoneId: [null],
      addressId: [null],
      imageId: [null],
      phone: this.formBuilder.group({
        id: [null],
        countryCode: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        areaCode: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        extension: ['', [Validators.pattern(unsignedIntPattern)]],
        number: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        phoneType: ['', [Validators.required]]
      }),
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

  private _getAddressModalConfig(data: FormGroup): MatDialogConfig {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    //dialogConfig.height = "450px";
    dialogConfig.width = "60%";
    dialogConfig.data = data;

    return dialogConfig;
  }

  //#endregion
}
