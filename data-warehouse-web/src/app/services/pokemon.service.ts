import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICoreDwCrudService } from './ICoreDwCrudService';
import { ICoreDwRow } from '../../classes/Common/ICoreDwRow';
import { PokemonEvent } from '../../classes/Pokemon/PokemonEvent';

@Injectable({
  providedIn: 'root'
})
export class PokemonService implements ICoreDwCrudService {

  constructor(private http: HttpClient) { }

  saveData(rowData: PokemonEvent): Observable<any> {
    throw new Error('Method not implemented.');
  }

  updateData(rowData: PokemonEvent): Observable<any> {
    throw new Error('Method not implemented.');
  }

  deleteData(rowData: PokemonEvent): Observable<any> {
    throw new Error('Method not implemented.');
  }

  getData(): Observable<any> {
    throw new Error('Method not implemented.');
  }

  getDataByID(): Observable<any> {
    throw new Error('Method not implemented.');
  }

  private getPokemonEvents(): Observable<any> {
    return this.http.get('https://localhost:4208/Pokemon/GetPokemonEvents');
  }
}
