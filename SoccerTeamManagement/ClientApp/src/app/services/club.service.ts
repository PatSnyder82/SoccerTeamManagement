import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { catchError, Observable } from 'rxjs';
import { IClub } from '../interfaces/club';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})

export class ClubService extends BaseService<IClub> {
  constructor(
    private formBuilder: FormBuilder,
    http: HttpClient, @Inject('BASE_URL') protected baseUrl: string
  ) {
    super(http, 'club/', baseUrl);
  }

  public getByLeague(id: number): Observable<IClub[]> {
    return this.http.get<IClub[]>(this.url + 'getclubsbyleague/' + id.toString())
      .pipe(catchError(this.handleError));
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({});
  }
}
