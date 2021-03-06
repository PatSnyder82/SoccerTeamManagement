import { Component, Inject, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ICountry } from '../../../../interfaces/lookups/country';
import { IState } from '../../../../interfaces/lookups/state';
import { CountryService } from '../../../../services/country.service';
import { StateService } from '../../../../services/state.service';

@Component({
  selector: 'sm-address-modal',
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
  usaCountryCode: number;

  //#endregion

  //#region Constructor

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<AddressModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FormGroup,
    private countryService: CountryService,
    private stateService: StateService
  ) {
    this.errorMessage = '';
    this.subscriptions = new Array<Subscription>();
    this.title = "Address";
    this.usaCountryCode = 237;
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
    this._getStates(this.usaCountryCode);
    this.controls = this._initializeControlReferences();
    this._conditionalValidationOfState();
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onCountryChange(countryId: number): void {
    if (countryId === this.usaCountryCode && !this.states) {
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
    if (this.form?.valid) {
      this.dialogRef.close({ data: this.form.value as FormGroup })
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  //#endregion

  //#region Methods

  private _conditionalValidationOfState(): void {
    this.subscriptions.push(this.controls.countryId.valueChanges
      .subscribe(value => {
        if (value === this.usaCountryCode) {
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
      id: this.form.get('id'),
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
