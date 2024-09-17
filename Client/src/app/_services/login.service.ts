import { computed, inject, Injectable, signal } from '@angular/core';
import { LoginDto } from '../_models/LoginDto';
import { HttpClient } from '@angular/common/http';
import { LoginResponseDto } from '../_models/LoginResponseDto';
import { map, catchError, throwError, Observable } from 'rxjs';
import { IloginService } from '../_interfaces/Ilogin.service';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class LoginService implements IloginService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  currentUser = signal<LoginResponseDto | null>(null);
  roles = computed(() => {
    const user = this.currentUser();
    if (user && user.user_jwt) {
      try {
        const jwtPayload = JSON.parse(atob(user.user_jwt.split('.')[1]));
        const role = jwtPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        return Array.isArray(role) ? role : [role];
      } catch (error) {
        console.error('Failed to parse JWT:', error);
        return [];
      }
    }
    return [];
  });

  constructor() {
    this.checkCurrentUser();
  }

  async login(loginDto: LoginDto): Promise<Observable<void>> {
    return await this.http.post<LoginResponseDto>(this.baseUrl + 'Auth/login', loginDto).pipe(
      map(loginResponseDto => {
        if (loginResponseDto) {
          this.setCurrentUser(loginResponseDto);
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

  refreshToken() {
     this.http.post<LoginResponseDto>(this.baseUrl + 'Auth/refreshtoken', { refreshToken: localStorage.getItem('refreshToken') }).subscribe(
      loginResponseDto => {
        if (loginResponseDto) {
          this.setCurrentUser(loginResponseDto);
        }
      }
    );
  }



}
