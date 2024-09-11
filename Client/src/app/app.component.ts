import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {
  SidebarComponent
} from './layout/sidebar/sidebar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { NavComponent } from './layout/nav/nav.component';
import { ControlComponent } from './layout/control/control.component';
import { LoginService } from './_services/login.service';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet , SidebarComponent, FooterComponent, NavComponent, ControlComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Client';
  isLoggedIn = false;
  _loginService: LoginService;

  constructor(loginService : LoginService) {
    this._loginService = loginService;
  }
}
