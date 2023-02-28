import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {PokemonMainImpl} from "../interfaces/pokemons.interface";
import {ObjectId} from "mongodb";


@Injectable({
  providedIn: 'root'
})
export class PokemonsService {
  private apiUrl = 'https://localhost:7027/Pkmn';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json',
    })
  };

  constructor(private http: HttpClient) {
  }

  initPokemon(page: number): Observable<PokemonMainImpl[]> {
    return this.http.get<any>(`${this.apiUrl}?page=${page}`, this.httpOptions).pipe(
      map(data => data.map((data: { _Id: ObjectId; height: number; natDex: number; name: string; sprite: string; weight: number; favorite: boolean; }) => new PokemonMainImpl(
        data._Id,
        data.favorite,
        data.height,
        data.name,
        data.natDex,
        data.sprite,
        data.weight
      )))
    );
  }

  getPokemon(natDex: number): Observable<PokemonMainImpl> {
    return this.http.get<any>(`${this.apiUrl}/${natDex}`, this.httpOptions).pipe(
      map(data => new PokemonMainImpl(
        data._id,
        data.favorite,
        data.height,
        data.name,
        data.natDex,
        data.sprite,
        data.weight
      ))
    );
  }

  updatePokemonFavorite(natDex: number) {
    return this.http.put<any>(`${this.apiUrl}/${natDex}/update/favorite`, {}, this.httpOptions);
  }

  checkFavorite(natDex:number) {
    return this.http.get<any>(`${this.apiUrl}/${natDex}/favorite`, this.httpOptions);
  }
}
