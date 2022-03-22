import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ILeague } from '../interfaces/league';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})

export class LeagueService extends BaseService<ILeague> {
  constructor(
    private formBuilder: FormBuilder,
    http: HttpClient, @Inject('BASE_URL') protected baseUrl: string
  ) {
    super(http, 'league/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({});
  }
}
