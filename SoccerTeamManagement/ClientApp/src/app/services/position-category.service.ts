import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { IEntity } from '../interfaces/entity';
import { IPositionCategory } from '../interfaces/lookups/position-category';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PositionCategoryService extends BaseService<IPositionCategory> {
  constructor(private formBuilder: FormBuilder, http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
    super(http, 'position-category/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      isDisabled: [null],
      sortOrder: [null],
      text: [null],
      value: [null]
    });
  }
}
