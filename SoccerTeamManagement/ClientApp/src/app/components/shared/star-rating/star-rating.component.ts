import { Component, Input } from '@angular/core';
import { IconDefinition } from '@fortawesome/fontawesome-common-types';
import { faStar as fasStar } from '@fortawesome/free-solid-svg-icons';
import { faStar as farStar } from '@fortawesome/free-regular-svg-icons';
import { AbstractControl, ControlValueAccessor, NG_VALIDATORS, NG_VALUE_ACCESSOR, ValidationErrors, Validator } from '@angular/forms';

@Component({
  selector: 'sm-star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: StarRatingComponent
    },
    {
      provide: NG_VALIDATORS,
      multi: true,
      useExisting: StarRatingComponent
    }
  ]
})
export class StarRatingComponent implements ControlValueAccessor, Validator {
  //#region Properties

  @Input('color') private color: string;
  //private rating: number;
  public starIcon: IconDefinition[];
  private isDisabled: boolean;
  private isTouched: boolean;

  //#endregion

  //#region Constructor

  constructor() {
    this.isDisabled = false;
    this.isTouched = false;
    this.starIcon = [farStar, farStar, farStar, farStar, farStar]
  }

  //#endregion

  //#region Validator Implementation

  validate(control: AbstractControl): ValidationErrors {
    const rating = control.value;

    if (rating <= 0) {
      return { mustBePositive: { rating } };
    }
  }

  //#endregion

  //#region ControlValueAccessor Implementation

  public writeValue(rating: number): void {
    this._setStars(rating);
  }

  public registerOnChange(onChange: any): void {
    this._onChange = onChange;
  }

  public registerOnTouched(onTouched: any): void {
    this._onTouched = onTouched;
  }

  public setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  //#endregion

  //#region Events

  private _onChange = (rating) => { };

  public onClick(rating: number): void {
    this._markAsTouched();

    if (!this.isDisabled) {
      this._setStars(rating);
      this._onChange(rating);
    }
  }

  private _onTouched = () => { };

  //#endregion

  //#region Methods

  private _markAsTouched(): void {
    if (!this.isTouched) {
      this._onTouched();
      this.isTouched = true;
    }
  }

  private _setStars(rating = 0): void {
    let starType = fasStar;

    if (rating > 0 && rating <= 6) {
      for (let i = 0; i < 5; i++) {
        this.starIcon[i] = starType;
        if (rating === i + 1) {
          starType = farStar;
        }
      }
    }
  }

  //#endregion
}
