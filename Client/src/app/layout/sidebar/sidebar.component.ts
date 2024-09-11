import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../_services/login.service';
import { Router, NavigationEnd, RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  login: LoginService;
  private _router: Router;
  private currentUrl!: string;

  constructor(loginService: LoginService, _router: Router) {
    this.login = loginService;
    this._router = _router;
  }

  ngOnInit(): void {
    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.currentUrl = event.url;
      }
    });

  }

}
