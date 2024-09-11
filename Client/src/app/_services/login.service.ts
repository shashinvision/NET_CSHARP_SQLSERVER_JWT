import { inject, Injectable, signal } from '@angular/core';
import { LoginDto } from '../_models/LoginDto';
import { HttpClient } from '@angular/common/http';
import { LoginResponseDto } from '../_models/LoginResponseDto';
import { map, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private http = inject(HttpClient);
  baseUrl = 'http://localhost:5093/api/';
  currentUser = signal<LoginResponseDto | null>(null);

  constructor() {
    this.checkCurrentUser();
  }


  login(loginDto: LoginDto) {
    return this.http.post<LoginResponseDto>(this.baseUrl + 'Auth/login', loginDto).pipe(
      map(user => {
        if (user) {
          this.setCurrentUser(user);
        }
      }),
      catchError(error => {
        console.error('Login error:', error);
        return throwError(() => new Error('Failed to login, please try again later.'));
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  setCurrentUser(user: LoginResponseDto) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
    console.log(this.currentUser());
  }

  checkCurrentUser() {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      this.currentUser.set(JSON.parse(storedUser));
    }
  }
}
