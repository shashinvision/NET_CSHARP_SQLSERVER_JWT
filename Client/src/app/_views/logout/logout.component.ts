import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../_services/login.service';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {
  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit(): void {
    this.loginService.logout();
    this.router.navigate(['/login']);
  }
}
