import { Component, inject } from '@angular/core';
import { LoginDto } from '../_models/LoginDto';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],  // Add HttpClientModule here
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']  // Corrected styleUrls
})
export class LoginComponent {
  private loginService = inject(LoginService);

  public username: string = '';
  public password: string = '';

  onSubmit() {
    const login: LoginDto = {
      name: this.username,
      password: this.password
    };
    this.loginService.login(login).subscribe(() => {
      console.log(localStorage.getItem('user'));
    });
  }
}
