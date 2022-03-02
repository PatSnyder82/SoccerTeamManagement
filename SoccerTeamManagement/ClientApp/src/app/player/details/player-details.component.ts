import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { Player } from '../../interfaces/player';
import { CountryLookup } from '../../interfaces/countryLookup';
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
  countries: CountryLookup[];

  title: string;
  form: FormGroup;
  errorStateMatcher = new ErrorStateMatcher;

  //#endregion

  //#region Constructor

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    const unsignedInt999Pattern = new RegExp('^[1-9]\\d{0,2}$');

    this.form = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      nickName: new FormControl('', Validators.required),
      height: new FormControl('', [Validators.required, Validators.min(0), Validators.max(999), Validators.pattern(unsignedInt999Pattern)]),
      weight: new FormControl('', [Validators.required, Validators.min(0), Validators.max(9999), Validators.pattern(unsignedInt999Pattern)]),
      foot: new FormControl('', Validators.required),
      flareRating: new FormControl('', [Validators.required, Validators.min(1), Validators.max(5)]),
      nationId: new FormControl('', Validators.required),
      readonly: new FormControl('true'),
      dateOfBirth: new FormControl(new Date(), Validators.required)
      /*//Phone
      countryCode: new FormControl('', Validators.required),
      areaCode: new FormControl('', Validators.required),
      extension: new FormControl('', Validators.required),
      number: new FormControl('', Validators.required),
      phoneType: new FormControl('', Validators.required),
      //Address
      addressLine1: new FormControl('', Validators.required),
      addressLine2: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      state: new FormControl('', Validators.required),
      zipCode: new FormControl('', Validators.required),
      //Photo
      image: new FormControl('', Validators.required),
      //Nation
      nation: new FormControl('', Validators.required),
      //Attributes
      //Teams
      teams: new FormControl('', Validators.required),
      positions: new FormControl('', Validators.required),
      parents: new FormControl('', Validators.required),*/
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
    var url = this.baseUrl + "api/CountryLookup/";

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
