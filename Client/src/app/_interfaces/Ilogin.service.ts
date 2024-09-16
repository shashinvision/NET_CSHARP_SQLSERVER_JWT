import { Observable } from "rxjs";
import { LoginDto } from "../_models/LoginDto";
import { LoginResponseDto } from "../_models/LoginResponseDto";

export interface IloginService {
  login(loginDto: LoginDto): Promise<Observable<void>>;
  logout(): void;
  currentUser(): LoginResponseDto | null;
}