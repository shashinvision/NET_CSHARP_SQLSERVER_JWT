import { Observable } from "rxjs";

export interface IRestService {
  get(): Observable<void>;
  add(T: any): Observable<any>;
  update(T: any): Promise<Observable<void>>;
  delete(T: any): Promise<Observable<void>>;
}
