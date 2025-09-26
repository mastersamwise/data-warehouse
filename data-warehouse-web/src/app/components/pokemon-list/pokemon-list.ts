import { Component } from '@angular/core';
import { PokemonEvent } from '../../../classes/Pokemon/PokemonEvent';
import { PokemonService } from '../../services/pokemon.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-pokemon-list',
  imports: [CommonModule],
  templateUrl: './pokemon-list.html',
  styleUrl: './pokemon-list.css'
})
export class PokemonList {
  public pokemonEvents: PokemonEvent[] = [];

  constructor(private pokemonService: PokemonService) {
    // intentionally left blank
  }

  loadEvents(): void {
    this.pokemonService.getPokemonEvents().subscribe({
      next: (data: PokemonEvent[]) => {
        this.pokemonEvents = data;
        console.log('Events loaded successfully: ', this.pokemonEvents);
      },
      error: (error: any) => {
        console.error('There was an error loading the events:', error);
      }
    });
  }

}
