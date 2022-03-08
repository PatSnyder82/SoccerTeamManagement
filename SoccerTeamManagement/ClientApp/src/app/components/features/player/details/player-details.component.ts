import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { IPlayer } from '../../../../interfaces/player';
import { ICountry } from '../../../../interfaces/lookups/country';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { IState } from '../../../../interfaces/lookups/state';
import { IImage } from '../../../../interfaces/image';

@Component({
  selector: 'sm-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.scss']
})
export class PlayerDetailsComponent implements OnInit {
  //#region Properties
  id: number;
  player: IPlayer;
  countries: ICountry[];
  states: IState[];
  image = {} as IImage;
  imageFile: File
  addressFormName: string;

  title: string;
  form: FormGroup;
  //#endregion

  //#region Constructor

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {
    this.addressFormName = 'address';
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(100)]],
      lastName: ['', [Validators.required, Validators.maxLength(100)]],
      nickName: ['', [Validators.maxLength(100)]],
      height: ['', [Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]],
      weight: ['', [Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]],
      foot: ['', [Validators.required]],
      flareRating: ['', [Validators.required, Validators.min(1), Validators.max(5)]],
      countryId: ['', [Validators.required]],
      readonly: ['true'],
      dateOfBirth: [new Date(), [Validators.required]],
      phone: this.formBuilder.group({
        countryCode: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        areaCode: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        extension: ['', [Validators.pattern(unsignedIntPattern)]],
        number: ['', [Validators.required, Validators.pattern(unsignedIntPattern)]],
        phoneType: ['', [Validators.required]]
      })
      /*//Photo
      image: new FormControl('', Validators.required),
      //Attributes
      //Teams
      teams: new FormControl('', Validators.required),
      positions: new FormControl('', Validators.required),
      parents: new FormControl('', Validators.required)*/
    });

    this.form.disable();
    this.form.controls['readonly'].enable();
  }

  //#endregion

  //#region Events

  ngOnInit() {
    this.imageFile = null;
    this.loadCountries();
    this.loadData();
  }

  onFileSelected(event) {
    this.image.caption = "IMAGE CAPTION....BAM!";
    this.imageFile = event.target.files[0] as File;
  }

  onReadonlyChange($event: MatSlideToggleChange) {
    if ($event.checked) {
      this.form.disable();
      this.form.controls['readonly'].enable();
      this.form.get(this.addressFormName).disable();
    }
    else {
      this.form.enable();
      this.form.get(this.addressFormName).enable();
    }
  }

  onSubmit() {
    if (this.imageFile !== null && this.imageFile.size > 0) {
      console.log('Returned successfully from uploadImage() - In onSubmit()');
      var player = (this.id) ? this.player : <IPlayer>{};

      player.firstName = this.form.get("firstName").value;
      player.lastName = this.form.get("lastName").value;
      player.nickName = this.form.get("nickName").value;
      player.height = +this.form.get("height").value;
      player.weight = +this.form.get("weight").value;
      player.foot = this.form.get("foot").value;
      player.flareRating = +this.form.get("flareRating").value;
      player.countryId = +this.form.get("countryId").value;
      player.dateOfBirth = this.form.get("dateOfBirth").value;
      player.phone.areaCode = this.form.controls.phone.get("areaCode").value;
      player.phone.countryCode = this.form.controls.phone.get("countryCode").value;
      player.phone.extension = this.form.controls.phone.get("extension").value;
      player.phone.number = this.form.controls.phone.get("number").value;
      player.phone.phoneType = this.form.controls.phone.get("phoneType").value;
      player.address.addressLine1 = this.form.controls.address.get("addressLine1").value;
      player.address.addressLine2 = this.form.controls.address.get("addressLine2").value;
      player.address.city = this.form.controls.address.get("city").value;
      player.address.countryId = this.form.controls.address.get("countryId").value;
      player.address.stateId = +this.form.controls.address.get("stateId").value;
      player.address.zipCode = this.form.controls.address.get("zipCode").value;

      const url = this.baseUrl + "api/players/" + this.player.id;

      this.http.put<IPlayer>(url, player)
        .subscribe(() => {
          this.router.navigate(['/players']);
        }, error => console.error(error));
    }
  }

  onUploadImage() {
    const url = this.baseUrl + "api/images/";

    let formData = new FormData();
    formData.append('file', this.imageFile);
    formData.append('image', JSON.stringify(this.image));

    this.http.post<number>(url, formData)
      .subscribe(result => {
        this.player.imageId = result;
      }, error => console.error(error));
  }

  //#endregion

  //#region Methods

  deleteImage() {
    const url = this.baseUrl + "api/images/";

    return this.http.delete<IImage>(url + this.image.id.toString())
      .subscribe(result => {
        console.log(result);
      }, error => console.error(error));
  }

  loadCountries() {
    // fetch all the countries from the server
    var url = this.baseUrl + "api/Country/";

    var params = new HttpParams()
      .set("pageIndex", "0")
      .set("pageSize", "9999")
      .set("sortColumn", "SortOrder")
      .set("sortOrder", "ASC");

    this.http.get<any>(url, { params }).subscribe(result => {
      this.countries = result.data;
    }, error => console.error(error));
  }

  loadData() {
    // retrieve the ID from the 'id'
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');

    var url = this.baseUrl + "api/Players/" + this.id;

    this.http.get<IPlayer>(url).subscribe(result => {
      this.player = result;

      this.title = "Edit - " + this.player.firstName + " " + this.player.lastName;

      this.form.patchValue(this.player);
    }, error => console.error(error));
  }

  //#endregion
}
