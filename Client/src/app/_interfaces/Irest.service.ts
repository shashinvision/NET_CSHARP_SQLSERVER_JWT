import { Observable, Subscription } from "rxjs";

export interface IRestService {
  get(): Subscription;
  add(T: any): Observable<any>;
  update(T: any): Promise<Observable<void>>;
  delete(T: any): Promise<Observable<void>>;
}
