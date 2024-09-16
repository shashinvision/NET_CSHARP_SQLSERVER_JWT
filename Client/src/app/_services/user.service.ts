import { inject, Injectable, signal } from '@angular/core';
import { IRestService } from '../_interfaces/Irest.service';
import { catchError, map, Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { UserDto } from '../_models/UserDto';

@Injectable()
export class UserService implements IRestService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  users = signal<UserDto[]>([]); // Changed to array of UserDto



  async get(): Promise<Observable<void>> {
    return await this.http.get<UserDto[]>(this.baseUrl + 'User/Users').pipe( // Changed to array of UserDto
      map(userDtos => {
        if (userDtos && userDtos.length > 0) {
          this.setUsers(userDtos);
        }
      }),
      catchError(error => {
        console.error('Login error:', error);
        return throwError(() => new Error('Failed to get Users, please try again later.'));
      })
    );
  }
  add(T: any): Promise<Observable<void>> {
    throw new Error('Method not implemented.');
  }
  update(T: any): Promise<Observable<void>> {
    throw new Error('Method not implemented.');
  }
  delete(T: any): Promise<Observable<void>> {
    throw new Error('Method not implemented.');
  }

  setUsers(users: UserDto[]) {
    this.cleanusers();
    // localStorage.setItem('users', JSON.stringify(users));
    this.users.set(users);
  }

  cleanusers() {
    this.users.set([]);
  }
}
