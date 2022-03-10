import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { IImage } from '../interfaces/image';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  protected api: string;
  protected endpoint: string;
  public url: string;
  protected version: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.api = 'api/';
    this.version = ''; //TODO: update backend API to include version 'v1/' in url path
    this.endpoint = 'images/';

    this.url = this.baseUrl + this.api + this.version + this.endpoint;
  }

  public create(image: IImage, file: File): Observable<number> {
    let formData = new FormData();
    formData.append('file', file);
    formData.append('image', JSON.stringify(image));

    return this.http.post<number>(this.url, formData)
      .pipe(catchError(this.handleError));
  }

  public delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + id.toString())
      .pipe(catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    return throwError(err.message || "server error");
  }
}
