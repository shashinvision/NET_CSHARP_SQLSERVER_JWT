import { Observable } from "rxjs";

export interface IRestStatusService {
  activate(T: any): Observable<any>;
}
