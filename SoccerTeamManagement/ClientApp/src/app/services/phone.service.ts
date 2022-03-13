import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPhone } from '../interfaces/phone';
import { BaseService } from './base.service';
import { CountryService } from './country.service';
import { StateService } from './state.service';

@Injectable({
  providedIn: 'root'
})
export class PhoneService extends BaseService<IPhone> {
  constructor(private formBuilder: FormBuilder, http: HttpClient, @Inject('BASE_URL') protected baseUrl: string, private stateService: StateService, private countryService: CountryService) {
    super(http, 'phone/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    return this.formBuilder.group({
      id: [0],
      countryCode: ['', [Validators.required, Validators.maxLength(10), Validators.pattern(unsignedIntPattern)]],
      areaCode: ['', [Validators.maxLength(10), Validators.pattern(unsignedIntPattern)]],
      extension: ['', [Validators.maxLength(10), Validators.pattern(unsignedIntPattern)]],
      number: ['', [Validators.required, Validators.maxLength(20), Validators.pattern(unsignedIntPattern)]],
      phoneType: [1, [Validators.required]]
    });
  }
}
