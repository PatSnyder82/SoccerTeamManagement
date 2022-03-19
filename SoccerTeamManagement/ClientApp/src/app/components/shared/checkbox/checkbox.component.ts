import { Component, ElementRef, forwardRef, Input, ViewChild } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'sm-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckboxComponent),
      multi: true
    }
  ]
})
export class CheckboxComponent implements ControlValueAccessor {
  @ViewChild('checkbox', { static: false }) checkBoxElementRef: ElementRef;
  //#region Properties
  @Input('text') public text: string;
  @Input('color') private color: string;
  public isChecked: boolean;
  private isDisabled: boolean;
  private isTouched: boolean;

  public onChange: any = () => {};
  public onTouched: any = () => {};

  //#endregion

  //#region Constructor

  constructor() {
    this.isDisabled = false;
    this.isTouched = false;
  }

  //#endregion

  //#region ControlValueAccessor Implementation

  public writeValue(checked: boolean): void {
    this.isChecked = checked;
  }

  public registerOnChange(onChange: any): void {
    this.onChange = onChange;
  }

  public registerOnTouched(onTouched: any): void {
    this.onTouched = onTouched;
  }

  //setDisabledState(isDisabled: boolean): void {
  //  this.isDisabled = isDisabled;
  //}

  //#endregion

  //#region Events

  //public onClick(isChecked: boolean): void {
  //  console.log("Checkbox OnClick Hit with value: " + isChecked);

  //  this._markAsTouched();

  //  if (!this.isDisabled) {
  //    this.isChecked = isChecked;
  //    this.onChange(isChecked);
  //  }
  //}

  public onModelChange(isChecked: boolean) {
    this.isChecked = isChecked;

    this.onChange(isChecked);
  }
  //#endregion

  //#region Methods

  //private _markAsTouched(): void {
  //  if (!this.isTouched) {
  //    this._onTouched();
  //    this.isTouched = true;
  //  }
  //}

  //#endregion
}
