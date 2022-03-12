import { Component, Inject, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IAddress } from '../../../../interfaces/address';
import { ICountry } from '../../../../interfaces/lookups/country';
import { IState } from '../../../../interfaces/lookups/state';
import { AddressService } from '../../../../services/address.service';
import { CountryService } from '../../../../services/country.service';
import { StateService } from '../../../../services/state.service';

@Component({
  selector: 'app-address-modal',
  templateUrl: './address-modal.component.html',
  styleUrls: ['./address-modal.component.scss'],
})
export class AddressModalComponent implements OnInit, OnDestroy {
  //#region Properties
  @Input() countries: ICountry[];
  controls;
  errorMessage: string;
  form: FormGroup;
  states: IState[];
  subscriptions: Subscription[];
  title: string;

  //#endregion

  //#region Constructor

  constructor(
    public router: Router,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<AddressModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FormGroup,
    private addressService: AddressService,
    private countryService: CountryService,
    private stateService: StateService
  ) {
    this.errorMessage = '';
    this.subscriptions = new Array<Subscription>();
    this.title = "Address";
  }

  //#endregion

  //#region Events

  public ngOnDestroy(): void {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  public ngOnInit(): void {
    this.form = this.data;
    this._getCountries();
    this._getStates(237);
    this.controls = this._initializeControlReferences();
    this._conditionalValidationOfState();
  }

  public onCloseModal(): void {
    this.dialogRef.close();
  }

  public onCountryChange(countryId: number): void {
    if (countryId === 237 && !this.states) {
      this._getStates(countryId);
    }

    const country = this.countries.find(x => x.id === countryId);

    if (country) {
      this.controls.country.patchValue(country);
    }
  }

  public onStateChange(stateId: number): void {
    const state = this.states.find(x => x.id === stateId);

    if (state) {
      this.controls.state.patchValue(state);
    }
  }

  public onSubmit(): void {
    if (this.form.valid) {
      this._onUpdate();
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  private _onUpdate(): void {
    this.subscriptions.push(this.addressService.update(this.form.value)
      .subscribe(
        data => this.dialogRef.close({ data: this.form.value as FormGroup }),
        error => this.errorMessage = error as string));
  }

  //#endregion

  //#region Methods

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
      country: this.form.get('country'),
      stateId: this.form.get('stateId'),
      state: this.form.get('state'),
      zipCode: this.form.get('zipCode')
    };
  }

  private _getCountries(): void {
    if (!this.countries) {
      this.subscriptions.push(this.countryService.getAll()
        .subscribe(
          data => this.countries = data,
          error => this.errorMessage = error as string));
    }
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
