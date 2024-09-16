import { inject, Injectable, signal } from '@angular/core';
import { IRestService } from '../_interfaces/Irest.service';
import { catchError, map, Observable, Observer, throwError, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { UserDto } from '../_models/UserDto';
import { RolesDto } from '../_models/RolesDto';
import { UserAddDto } from '../_models/UserAddDto';
import { UserAddResponseDto } from '../_models/UserAddResponseDto';

@Injectable()
export class UserService implements IRestService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  users = signal<UserDto[]>([]); // Changed to array of UserDto
  roles = signal<RolesDto[]>([]);


  get(): Subscription {
    return this.http.get<UserDto[]>(this.baseUrl + 'User/Users').pipe(
      map(userDtos => {
        if (userDtos && userDtos.length > 0) {
          this.setUsers(userDtos);
        }
      }),
      catchError(error => {
        console.error('Failed to get Users:', error);
        return throwError(() => new Error('Failed to get Users, please try again later.'));
      })
    ).subscribe();
  }

  getRoles(): Subscription {
    return this.http.get<RolesDto[]>(this.baseUrl + 'User/Roles').pipe(
      map(roleDtos => {
        if (roleDtos && roleDtos.length > 0) {
          this.setRoles(roleDtos);
        }
      }),
      catchError(error => {
        console.error('Failed to get Roles:', error);
        return throwError(() => new Error('Failed to get Roles, please try again later.'));
      })
    ).subscribe();
  }

  add(userAddDto: UserAddDto): Observable<UserAddResponseDto> {
    return this.http.post<UserAddResponseDto>(this.baseUrl + 'User/User', userAddDto);
  }


  update(T: any): Promise<Observable<void>> {
    throw new Error('Method not implemented.');
  }
  delete(T: any): Promise<Observable<void>> {
    throw new Error('Method not implemented.');
  }

  setUsers(users: UserDto[]) {
    this.cleanUsers();
    // localStorage.setItem('users', JSON.stringify(users));
    this.users.set(users);
  }

  cleanUsers() {
    this.users.set([]);
  }

  setRoles(roles: RolesDto[]) {
    this.roles.set(roles);
  }

  cleanRoles() {
    this.roles.set([]);
  }


}
