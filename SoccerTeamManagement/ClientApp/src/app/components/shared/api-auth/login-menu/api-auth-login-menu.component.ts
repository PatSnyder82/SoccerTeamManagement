import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../../../../services/authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'sm-api-auth-login-menu',
  templateUrl: './api-auth-login-menu.component.html',
  styleUrls: ['./api-auth-login-menu.component.scss']
})
export class ApiAuthLoginMenuComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;

  constructor(private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }
}
