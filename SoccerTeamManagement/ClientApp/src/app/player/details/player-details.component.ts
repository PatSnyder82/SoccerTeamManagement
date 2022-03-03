import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { Player } from '../../interfaces/player';
import { Country } from '../../interfaces/lookups/country';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.scss']
})
export class PlayerDetailsComponent implements OnInit {
  //#region Properties
  id: number;
  player: Player;
  countries: Country[];

  title: string;
  form: FormGroup;
  errorStateMatcher = new ErrorStateMatcher;

  //#endregion

  //#region Constructor

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');
    const unsignedIntPattern = new RegExp('^[1-9]\\d{0,8}$');

    this.form = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      nickName: new FormControl('', Validators.maxLength(100)),
      height: new FormControl('', [Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]),
      weight: new FormControl('', [Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]),
      foot: new FormControl('', Validators.required),
      flareRating: new FormControl('', [Validators.required, Validators.min(1), Validators.max(5)]),
      nationId: new FormControl('', Validators.required),
      readonly: new FormControl('true'),
      dateOfBirth: new FormControl(new Date(), Validators.required),
      phone: new FormGroup({
        countryCode: new FormControl('', [Validators.required, Validators.pattern(unsignedIntPattern)]),
        areaCode: new FormControl('', [Validators.required, Validators.pattern(unsignedIntPattern)]),
        extension: new FormControl('', Validators.pattern(unsignedIntPattern)),
        number: new FormControl('', [Validators.required, Validators.pattern(unsignedIntPattern)]),
        phoneType: new FormControl('', Validators.required)
      }),
      address: new FormGroup({
        addressLine1: new FormControl('', [Validators.required, Validators.maxLength(100)]),
        addressLine2: new FormControl('', Validators.maxLength(100)),
        city: new FormControl('', [Validators.required, Validators.maxLength(100)]),
        country: new FormControl('', Validators.required),
        state: new FormControl('', Validators.maxLength(100)),
        zipCode: new FormControl('', Validators.pattern(unsignedIntPattern))
      })
      /*//Photo
      image: new FormControl('', Validators.required),
      //Nation
      nation: new FormControl('', Validators.required),
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
    this.loadCountries();
    this.loadData();
  }

  onSubmit() {
    var player = (this.id) ? this.player : <Player>{};

    player.firstName = this.form.get("firstName").value;
    player.lastName = this.form.get("lastName").value;
    player.nickName = this.form.get("nickName").value;
    player.height = +this.form.get("height").value;
    player.weight = +this.form.get("weight").value;
    player.foot = this.form.get("foot").value;
    player.flareRating = +this.form.get("flareRating").value;
    player.nationId = +this.form.get("nationId").value;
    player.dateOfBirth = this.form.get("dateOfBirth").value;
    player.phone.areaCode = this.form.controls.phone.get("areaCode").value;
    player.phone.countryCode = this.form.controls.phone.get("countryCode").value;
    player.phone.extension = this.form.controls.phone.get("extension").value;
    player.phone.number = this.form.controls.phone.get("number").value;
    player.phone.phoneType = this.form.controls.phone.get("phoneType").value;
    player.address.addressLine1 = this.form.controls.address.get("addressLine1").value;
    player.address.addressLine2 = this.form.controls.address.get("addressLine2").value;
    player.address.city = this.form.controls.address.get("city").value;
    player.address.country = this.form.controls.address.get("country").value;
    player.address.state = this.form.controls.address.get("state").value;
    player.address.zipCode = this.form.controls.address.get("zipCode").value;

    const url = this.baseUrl + "api/players/" + this.player.id;

    this.http.put<Player>(url, player)
      .subscribe(() => {
        this.router.navigate(['/players']);
      }, error => console.error(error));
  }

  //#endregion

  //#region Methods

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

    this.http.get<Player>(url).subscribe(result => {
      this.player = result;
      this.title = "Edit - " + this.player.firstName + " " + this.player.lastName;
      console.log(this.player);
      this.form.patchValue(this.player);
    }, error => console.error(error));
  }

  readonlySlideChange($event: MatSlideToggleChange) {
    if ($event.checked) {
      this.form.disable();
      this.form.controls['readonly'].enable();
    }
    else {
      this.form.enable();
    }
  }

  //#endregion
}
