import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { catchError, Observable } from 'rxjs';
import { ITeamPlayer } from '../interfaces/joins/team-player';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TeamPlayerService extends BaseService<ITeamPlayer> {
  constructor(private formBuilder: FormBuilder, http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
    super(http, 'teamPlayer/', baseUrl);
  }

  delete(id: number): Observable<boolean> {
    throw new Error('Method not implemented.');
  }
  getById(id: number): Observable<ITeamPlayer> {
    throw new Error('Method not implemented.');
  }
  updateMany(items: ITeamPlayer[]): Observable<ITeamPlayer[]> {
    return this.http.put<ITeamPlayer[]>(this.url, items)
      .pipe(catchError(this.handleError));
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({});
  }
}
