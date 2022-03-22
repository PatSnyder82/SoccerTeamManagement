import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { IPlayerPosition } from '../../../../interfaces/joins/player-position';
import { IPosition } from '../../../../interfaces/lookups/position';
import { PositionService } from '../../../../services/position.service';
import { CheckboxComponent } from '../../../shared/checkbox/checkbox.component';

@Component({
  selector: 'sm-pitch-positions-modal',
  templateUrl: './pitch-positions-modal.component.html',
  styleUrls: ['./pitch-positions-modal.component.scss']
})
export class PitchPositionsModalComponent implements OnInit, OnDestroy {
  //#region Properties
  controls;
  errorMessage: string;
  form: FormGroup;
  userInstructions: string;
  playerPositions: IPosition[];
  positions: IPosition[];
  subscriptions: Subscription[];
  title: string;

  //#endregion

  //#region Constructor

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PitchPositionsModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IPosition[],
    private snackBar: MatSnackBar,
    private positionService: PositionService
  ) {
    this.errorMessage = '';
    this.userInstructions = "Drag and drop selected positions to order.";
    this.playerPositions = data ? data as IPosition[] : [] as IPosition[];
    this.subscriptions = [] as Subscription[];
    this.title = "Positions";
  }

  //#endregion

  //#region Events

  public drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.playerPositions, event.previousIndex, event.currentIndex);
  }

  public ngOnDestroy(): void {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe);
    }
  }

  ngOnInit(): void {
    this.form = this._initializeFormGroup();
    this._intializeFormGroupValues();
    this._getPositions();
    this.controls = this._initializeControlReferences();
  }

  public onChange(control) {
    const isChecked = this.form.get(control).value;
    const position = this.positions.find(position => position.abbreviation.toLowerCase() === control) as IPosition;

    if (isChecked && position) {
      if (this.playerPositions.length < 5) {
        this._addPosition(position);
      }
      else {
        this.form.get(control).setValue(false);
        this.openToManyPositionsNotification();
      }
    }
    else if (!isChecked && position) {
      this._removePosition(position);
    }
  }

  public onClose(): void {
    this.dialogRef.close();
  }

  public onSubmit(): void {
    if (this.form?.valid) {
      this.dialogRef.close({ data: this.playerPositions as IPosition[] })
    }
    else {
      this.form.markAllAsTouched();
    }
  }

  public openToManyPositionsNotification() {
    this.snackBar.open("A max of 5 positions may be selected.", "Notification", { duration: 5000 });
  }

  //#endregion

  //#region Methods

  private _addPosition(position: IPosition): void {
    if (!this._playerHasPosition(position)) {
      this.playerPositions.push(position);
    }
  }

  private _removePosition(position: IPosition): void {
    if (this._playerHasPosition(position)) {
      this.playerPositions = this.playerPositions.filter(pp => !(pp.id === position.id))
    }
  }

  private _playerHasPosition(position: IPosition): boolean {
    if (this.playerPositions === undefined || this.playerPositions.length < 1) {
      return false;
    }

    if (Array.from(this.playerPositions).find(x => x.id === position.id)) {
      return true;
    }
    else {
      return false;
    }
  }

  private _getPositions(): void {
    if (!this.positions) {
      this.subscriptions.push(this.positionService.getAll()
        .subscribe(
          data => this.positions = data,
          error => this.errorMessage = error as string));
    }
  }

  private _initializeControlReferences() {
    return {
      lw: this.form.get('lw'),
      lf: this.form.get('lf'),
      cf: this.form.get('cf'),
      st: this.form.get('st'),
      rf: this.form.get('rf'),
      rw: this.form.get('rw'),
      cam: this.form.get('cam'),
      lm: this.form.get('lm'),
      cm: this.form.get('cm'),
      rm: this.form.get('rm'),
      lwb: this.form.get('lwb'),
      cdm: this.form.get('cdm'),
      rwb: this.form.get('rwb'),
      lb: this.form.get('lb'),
      cb: this.form.get('cb'),
      rb: this.form.get('rb'),
      sw: this.form.get('sw'),
      g: this.form.get('g'),
    };
  }

  private _initializeFormGroup() {
    return this.formBuilder.group({
      lw: [false],
      lf: [false],
      cf: [false],
      st: [false],
      rf: [false],
      rw: [false],
      cam: [false],
      lm: [false],
      cm: [false],
      rm: [false],
      lwb: [false],
      cdm: [false],
      rwb: [false],
      lb: [false],
      cb: [false],
      rb: [false],
      sw: [false],
      g: [false]
    });
  }

  private _intializeFormGroupValues() {
    if (this.playerPositions && this.playerPositions.length > 0) {
      this.playerPositions.forEach(position => {
        this.form.get(position.abbreviation.toLowerCase()).setValue(true);
      });
    }
  }
  //#endregion
}
