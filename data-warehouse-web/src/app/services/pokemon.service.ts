import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PokemonEvent } from '../../classes/Pokemon/PokemonEvent';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  private url: string = 'https://localhost:4208/Pokemon';

  constructor(private http: HttpClient) { }

  getPokemonEvents(): Observable<any> {
    return this.http.get(`${this.url}/GetPokemonEvents`);
  }

  updatePokemonEvent(pokemonEvent: PokemonEvent): Observable<any> {
    return this.http.post(`${this.url}/UpdatePokemonEvent`, pokemonEvent);
  }

  addPokemonEvent(pokemonEvent: PokemonEvent): Observable<any> {
    return this.http.post(`${this.url}/AddPokemonEvent`, pokemonEvent);
  }

  deletePokemonEvent(eventID: number): Observable<any> {
    return this.http.post(`${this.url}/DeletePokemonEvent`, eventID);
  }
}
