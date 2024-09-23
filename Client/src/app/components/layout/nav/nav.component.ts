import { Component } from '@angular/core';
import {  RouterModule } from '@angular/router';
import { LoginService } from '../../../_services/login.service';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent  {
  login: LoginService;
  constructor(loginService: LoginService) {
    this.login = loginService;
  }

}
