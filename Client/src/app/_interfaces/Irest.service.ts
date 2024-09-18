import { Observable, Subscription } from "rxjs";

export interface IRestService {
  get(): Subscription;
  add(T: any): Observable<any>;
  update(T: any): Observable<any>;
  deactivate(T: any): Observable<any>;
}
