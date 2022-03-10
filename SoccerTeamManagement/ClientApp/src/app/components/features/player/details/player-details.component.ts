import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { ICountry } from '../../../../interfaces/lookups/country';
import { IImage } from '../../../../interfaces/image';
import { IPlayer } from '../../../../interfaces/player';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { PlayerService } from '../../../../services/player.service';
import { Subscription } from 'rxjs';
import { OnDestroy } from '@angular/core';
import { CountryService } from '../../../../services/country.service';
import { StateService } from '../../../../services/state.service';
import { ImageService } from '../../../../services/image.service';

@Component({
  selector: 'sm-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.scss']
})
export class PlayerDetailsComponent implements OnInit, OnDestroy {
  //#region Properties
  controls;
  errorMessage: string;
  form: FormGroup;
  id: number;
  isCreateMode: boolean;
  isReadonly: boolean;
  isLoading: boolean;
  subscriptions: Subscription[];
  title: string;

  addressFormName: string;
  countries: ICountry[];
  image = {} as IImage; //TODO: Create proper Image component
  imageFile: File

  //#endregion

  //#region Constructor

  constructor(private route: ActivatedRoute, private router: Router,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private formBuilder: FormBuilder, private playerService: PlayerService, private countryService: CountryService,
    private stateService: StateService, private imageService: ImageService) {
    this.addressFormName = 'address';
    this.subscriptions = new Array<Subscription>();
    this.imageFile = null;
    this.id = +this.route.snapshot.paramMap.get('id');
    this.isLoading = true;
    this._setFormMode();
    this._buildForm();
  }

  //#endregion

  //#region Events
  public ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  public ngOnInit() {
    if (!this.isCreateMode) {
      this._disableForm();
    }

    if (this.isCreateMode) {
      this.title = "Create Player";
      this.isLoading = false;
    }
    else {
      this._getPlayer();
    }

    this._getCountries();
    this._createControlReferences();
  }

  public onFileSelected(event) {
    this.imageFile = event.target.files[0] as File;
  }

  public onReadonlyChange($event: MatSlideToggleChange) {
    if (!this.isCreateMode) {
      if ($event.checked) {
        this._disableForm();
      }
      else {
        this._enableForm();
      }
    }

    if (this.isCreateMode) {
      this._enableForm();
    }
  }

  public onCreate() {
    console.log("onCreate");

    //this.subscriptions.push(this.playerService.create(this._getFormData())
    //  .subscribe(
    //    data => this.router.navigate(['/players']),
    //    error => this.errorMessage = error as string));
  }

  public onSubmit() {
    if (this.form.valid) {
      if (this.isCreateMode) {
        this.onCreate();
      }
      else {
        this.onUpdate();
      }
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  public onUpdate() {
    console.log("onUpdate");
    this.subscriptions.push(this.playerService.update(this._getFormData())
      .subscribe(
        data => this.router.navigate(['/players']),
        error => this.errorMessage = error as string));
  }

  public onImageUpload(): void {
    this.subscriptions.push(this.imageService.create(this.image, this.imageFile)
      .subscribe(
        data => this.image.id = data,
        error => this.errorMessage = error as string));
  }

  private _onPlayerLoaded(player: IPlayer): void {
    this.title = "Edit - " + player.firstName + " " + player.lastName;
    this.form.patchValue(player);
    this.isLoading = false;
  }

  //#endregion

  //#region Methods

  private _buildForm(): void {
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(100)]],
      lastName: ['', [Validators.required, Validators.maxLength(100)]],
      nickName: ['', [Validators.maxLength(100)]],
      height: ['', [Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]],
      weight: ['', [Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]],
      foot: ['', [Validators.required]],
      flareRating: ['', [Validators.required]],
      countryId: ['', [Validators.required]],
      dateOfBirth: [new Date(), [Validators.required]],
      phone: this.formBuilder.group({
        countryCode: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        areaCode: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        extension: ['', [Validators.pattern(unsignedIntPattern)]],
        number: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        phoneType: ['', [Validators.required]]
      })
      /*//Photo
      image: new FormControl('', Validators.required),
      //Attributes
      //Teams
      teams: new FormControl('', Validators.required),
      positions: new FormControl('', Validators.required),
      parents: new FormControl('', Validators.required)*/
    });
  }

  private _createControlReferences(): void {
    this.controls = {
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
      }
    }
  }

  private _deleteImage() {
    this.subscriptions.push(this.imageService.delete(+this.image.id)
      .subscribe(
        data => data,
        error => this.errorMessage = error as string));
  }

  private _disableForm(): void {
    this.isReadonly = true;
    this.form.disable();
    //this.form.controls['readOnly'].enable();
    //this.controls.readOnly.enable();
  }

  private _enableForm(): void {
    this.isReadonly = false;
    this.form.enable();
  }

  private _getCountries(): void {
    if (!this.countries) {
      this.subscriptions.push(this.countryService.getAll()
        .subscribe(
          data => this.countries = data,
          error => this.errorMessage = error as string));
    }
  }

  private _getFormData(): IPlayer {
    let player = {} as IPlayer;
    player = this.form.value;
    player.id = this.id;

    return player;
  }

  private _getPlayer(): void {
    this.subscriptions.push(this.playerService.getById(this.id)
      .subscribe(
        data => this._onPlayerLoaded(data),
        error => this.errorMessage = error as string));
  }

  private _setFormMode(): void {
    if (this.id && this.id > 0) {
      this.isCreateMode = false;
      this.isReadonly = true;
    }
    else {
      this.isCreateMode = true;
      this.isReadonly = false;
    }
  }

  public findInvalidControls() {
    const invalid = [];
    const controls = this.form.controls;
    for (const name in controls) {
      if (controls[name].invalid) {
        console.log("INVALID CONTROL: " + name);
        invalid.push(name);
      }
    }
    return invalid;
  }

  //#endregion
}
