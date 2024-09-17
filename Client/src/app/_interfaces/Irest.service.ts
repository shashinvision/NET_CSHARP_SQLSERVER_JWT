import { Observable, Subscription } from "rxjs";

export interface IRestService {
  get(): Subscription;
  add(T: any): Observable<any>;
  update(T: any): Observable<any>;
  delete(T: any): Observable<any>;
}
