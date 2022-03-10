import { Component, Inject, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { IAddress } from '../../../../interfaces/address';
import { ICountry } from '../../../../interfaces/lookups/country';
import { IState } from '../../../../interfaces/lookups/state';
import { CountryService } from '../../../../services/country.service';
import { StateService } from '../../../../services/state.service';

@Component({
  selector: 'app-address-modal',
  templateUrl: './address-modal.component.html',
  styleUrls: ['./address-modal.component.scss']
})
export class AddressModalComponent implements OnInit, OnDestroy {
  //#region Properties
  @Input() countries: ICountry[];
  controls;
  errorMessage: string;
  form: FormGroup;
  id: number;
  isCreateMode: boolean;
  title: string;
  states: IState[];
  subscriptions: Subscription[];

  //#endregion

  //#region Constructor

  constructor(public dialogRef: MatDialogRef<AddressModalComponent>, @Inject(MAT_DIALOG_DATA) public data: IAddress,
    private formBuilder: FormBuilder, private countryService: CountryService, private stateService: StateService) {
    this.isCreateMode = true;
    this.title = "Address";
    this.subscriptions = new Array<Subscription>();
  }

  //#endregion

  //#region Events

  public ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  ngOnInit(): void {
    this.form = this._buildForm();
    this._getCountries();
    this.controls = this._initializeControlReferences();
    this._conditionalValidationOfState();
  }
  onSubmit() {
    this.dialogRef.close({ data: this._getFormData()});
  }

  onCloseModal() {
    this.dialogRef.close();
  }

  onCountryChange(countryId: number) {
    if (countryId === 237 && this.states == null) {
      this._getStates(countryId);
    }
  }

  //onNoClick(): void {
  //  this.dialogRef.close();
  //}

  //#endregion

  //#region Methods

  private _buildForm(): FormGroup {
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    return this.formBuilder.group({
      addressLine1: [this.data.addressLine1, [Validators.required, Validators.maxLength(100)]],
      addressLine2: [this.data.addressLine2, [Validators.maxLength(100)]],
      city: [this.data.city, [Validators.required, Validators.maxLength(100)]],
      countryId: [this.data.countryId, [Validators.required]],
      stateId: [this.data.stateId],
      zipCode: [this.data.zipCode, [Validators.pattern(unsignedIntPattern)]]
    });
  }

  private _conditionalValidationOfState(): void {
    this.subscriptions.push(this.controls.countryId.valueChanges
      .subscribe(value => {
        if (value === 237) {
          this.controls.stateId.setValidators([Validators.required]);
        }
        else {
          this.controls.stateId.clearValidators();
        }

        this.controls.stateId.updateValueAndValidity();
      }));
  }

  private _initializeControlReferences() {
    return {
      addressLine1: this.form.get('addressLine1'),
      addressLine2: this.form.get('addressLine2'),
      city: this.form.get('city'),
      countryId: this.form.get('countryId'),
      stateId: this.form.get('stateId'),
      zipCode: this.form.get('zipCode')
    };
  }

  private _disableForm(): void {
    this.form.disable();
  }

  private _enableForm(): void {
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

  private _getFormData(): IAddress {
    let entity = {} as IAddress;
    entity = this.form.value;
    entity.id = this.id;

    return entity;
  }
  private _getStates(countryId: number): void {
    if (!this.states) {
      this.subscriptions.push(this.stateService.getByCountry(countryId)
        .subscribe(
          data => this.states = data,
          error => this.errorMessage = error as string));
    }
  }

  //#endregion
}
