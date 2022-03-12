import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ICountry } from '../interfaces/lookups/country';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends BaseService<ICountry> {
  constructor(private formBuilder: FormBuilder, http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
    super(http, 'country/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      isDisabled: [null],
      sortOrder: [null],
      text: [null],
      value: [null],
      alpha2Code: [null],
      alpha3Code: [null]
    });
  }
}
