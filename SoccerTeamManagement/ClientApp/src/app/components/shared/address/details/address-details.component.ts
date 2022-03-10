import { HttpClient } from '@angular/common/http';
import { OnDestroy } from '@angular/core';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ICountry } from '../../../../interfaces/lookups/country';
import { IState } from '../../../../interfaces/lookups/state';
import { CountryService } from '../../../../services/country.service';
import { StateService } from '../../../../services/state.service';

@Component({
  selector: 'sm-address-details',
  templateUrl: './address-details.component.html',
  styleUrls: ['./address-details.component.scss']
})
export class AddressDetailsComponent implements OnInit, OnDestroy {
  //#region Properties
  @Input() isReadOnly = false;
  @Input() countries: ICountry[];

  controls: {};
  errorMessage: string;
  form: FormGroup;
  formName: string;;
  address: FormGroup;
  states: IState[];
  subscriptions: Subscription[];

  //#endregion

  //#region Constructor

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private formBuilder: FormBuilder, private rootFormGroup: FormGroupDirective,
    private countryService: CountryService, private stateService: StateService) {
    this.subscriptions = new Array<Subscription>();
    this.formName = 'address';
  }

  //#endregion

  //#region Event

  ngOnInit(): void {
    this.form = this.rootFormGroup.form;
    this.form.addControl(this.formName, this._buildForm());
    this.address = this.form.get(this.formName) as FormGroup;

    this._conditionalValidationOfState();

    if (this.isReadOnly)
      this._disableForm();
    else
      this._enableForm();

    this._getCountries();
    this._createControlReferences();
  }

  public ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  onCountryChange(countryId: number) {
    if (countryId === 237 && this.states == null) {
      this._getStates(countryId);
    }
  }

  //#endregion

  //#region Methods

  private _buildForm(): FormGroup {
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    return this.formBuilder.group({
      addressLine1: ['', [Validators.required, Validators.maxLength(100)]],
      addressLine2: ['', [Validators.maxLength(100)]],
      city: ['', [Validators.required, Validators.maxLength(100)]],
      countryId: [null, [Validators.required]],
      stateId: [''],
      zipCode: ['', [Validators.pattern(unsignedIntPattern)]]
    });
  }

  private _conditionalValidationOfState(): void {
    this.subscriptions.push(this.form.controls.address.get('countryId').valueChanges
      .subscribe(value => {
        if (value === 237) {
          this.form.controls.address.get('stateId').setValidators([Validators.required]);
        }
        else {
          this.form.controls.address.get('stateId').clearValidators();
        }

        this.form.controls.address.get('stateId').updateValueAndValidity();
      }));
  }

  private _createControlReferences(): void {
    this.controls = {
      addressLine1: this.form.controls.address.get('addressLine1'),
      addressLine2: this.form.controls.address.get('addressLine2'),
      city: this.form.controls.address.get('city'),
      countryId: this.form.controls.address.get('countryId'),
      stateId: this.form.controls.address.get('stateId'),
      zipCode: this.form.controls.address.get('zipCode')
    }
  }

  private _disableForm(): void {
    this.isReadOnly = true;
    this.form.disable();
  }

  private _enableForm(): void {
    this.isReadOnly = false;
    this.address.enable();
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
}

  //#endregion
