import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { ICountry } from '../interfaces/lookups/country';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends BaseService<ICountry> {
  constructor(http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
    super(http, 'country/', baseUrl);
  }
}
