import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IAddress } from '../interfaces/address';
import { BaseService } from './base.service';
import { CountryService } from './country.service';
import { StateService } from './state.service';

@Injectable({
  providedIn: 'root'
})
export class AddressService extends BaseService<IAddress> {
  constructor(private formBuilder: FormBuilder, http: HttpClient, @Inject('BASE_URL') protected baseUrl: string, private stateService: StateService, private countryService: CountryService) {
    super(http, 'address/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    return this.formBuilder.group({
      id: [0],
      addressLine1: ['', [Validators.required, Validators.maxLength(100)]],
      addressLine2: ['', [Validators.maxLength(100)]],
      city: ['', [Validators.required, Validators.maxLength(100)]],
      country: this.countryService.getFormGroup(),
      countryId: [null, [Validators.required]],
      countryText: [null],
      countryAlpha2Code: [null],
      state: this.stateService.getFormGroup(),
      stateId: [null],
      stateText: [null],
      stateAlpha2Code: [null],
      zipCode: ['', [Validators.pattern(unsignedIntPattern)]]
    });
  }
}
