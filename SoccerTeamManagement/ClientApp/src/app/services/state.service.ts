import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { catchError, Observable } from 'rxjs';
import { IState } from '../interfaces/lookups/state';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class StateService extends BaseService<IState> {
  constructor(private formBuilder: FormBuilder, http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
    super(http, 'state/', baseUrl);
  }

  public getByCountry(id: number): Observable<IState[]> {
    return this.http.get<IState[]>(this.url + 'getstatesbycountry/' + id.toString())
      .pipe(catchError(this.handleError));
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      isDisabled: [null],
      sortOrder: [null],
      text: [null],
      value: [null],
      alpha2Code: [null],
      countryId: [0]
    });
  }
}
