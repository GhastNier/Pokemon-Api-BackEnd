import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {}

  getPokemon(pokemon: string): Observable<any> {
    const url = `https://pokeapi.co/api/v2/pokemon/${pokemon}`;
    return this.http.get<any>(url);
  }
}
