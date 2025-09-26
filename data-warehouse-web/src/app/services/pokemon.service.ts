import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  constructor(private http: HttpClient) { }

  getPokemonEvents(): Observable<any> {
    return this.http.get('https://localhost:4208/Pokemon/GetPokemonEvents');
  }
}
