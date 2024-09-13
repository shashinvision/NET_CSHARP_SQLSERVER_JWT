import { Observable } from "rxjs";

export interface IRestService {
  get(): Promise<Observable<void>>;
  add(T: any): Promise<Observable<void>>;
  update(T: any): Promise<Observable<void>>;
  delete(T: any): Promise<Observable<void>>;
}
