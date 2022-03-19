import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { PhoneType } from '../../../../enum/phone-type';

@Component({
  selector: 'sm-phone-modal',
  templateUrl: './phone-modal.component.html',
  styleUrls: ['./phone-modal.component.scss']
})
export class PhoneModalComponent implements OnInit, OnDestroy {
  //#region Properties

  controls;
  errorMessage: string;
  form: FormGroup;
  phoneType: PhoneType;
  subscriptions: Subscription[];
  title: string;

  //#endregion

  //#region Constructor

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PhoneModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FormGroup
  ) {
    this.errorMessage = '';
    this.phoneType = {} as PhoneType;
    this.subscriptions = new Array<Subscription>();
    this.title = "Phone";
  }

  //#endregion

  //#region Events

  public ngOnDestroy(): void {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  public ngOnInit(): void {
    this.form = this.data;

    this.controls = this._initializeControlReferences();
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onSubmit(): void {
    if (this.form?.valid) {
      this.dialogRef.close({ data: this.form.value as FormGroup })
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  //#endregion

  //#region Methods

  private _initializeControlReferences() {
    return {
      id: this.form.get('id'),
      countryCode: this.form.get('countryCode'),
      areaCode: this.form.get('areaCode'),
      extension: this.form.get('extension'),
      number: this.form.get('number'),
      phoneType: this.form.get('phoneType')
    };
  }

  //#endregion
}
