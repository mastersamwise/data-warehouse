// import { Component } from '@angular/core';
// import { PokemonEvent } from '../../../classes/Pokemon/PokemonEvent';
// import { PokemonService } from '../../services/pokemon.service';
// import { CommonModule } from '@angular/common';

// @Component({
//   selector: 'app-pokemon-list',
//   imports: [CommonModule],
//   templateUrl: './pokemon-list.html',
//   styleUrl: './pokemon-list.css'
// })
// export class PokemonList {
//   public pokemonEvents: PokemonEvent[] = [];

//   constructor(private pokemonService: PokemonService) {
//     // intentionally left blank
//   }

//   loadEvents(): void {
//     this.pokemonService.getPokemonEvents().subscribe({
//       next: (data: PokemonEvent[]) => {
//         this.pokemonEvents = data;
//         console.log('Events loaded successfully: ', this.pokemonEvents);
//       },
//       error: (error: any) => {
//         console.error('There was an error loading the events:', error);
//       }
//     });
//   }
// }


import { Component, OnInit, inject } from '@angular/core';
import { TableModule } from 'primeng/table';
import { PokemonService } from '../../services/pokemon.service';
import { PopoverTokenSections } from '@primeuix/themes/types/popover';
import { PokemonEvent } from '../../../classes/Pokemon/PokemonEvent';

interface Column {
    field: string;
    header: string;
}

@Component({
    selector: 'app-pokemon-list',
    templateUrl: './pokemon-list.html',
    imports: [TableModule],
    providers: [PokemonService
    ]
})
export class PokemonList
 {
    private pokemonService = inject(PokemonService);
    public pokemonEvents!: PokemonEvent[];
    cols!: Column[];

    loadEvents() {
        this.pokemonService.getPokemonEvents().subscribe({
          next: (data: PokemonEvent[]) => {
            this.pokemonEvents = data;
            console.log('Events loaded successfully: ', this.pokemonEvents);
          },
          error: (error: any) => {
            console.error('There was an error loading the events:', error);
          }}
        );

        this.cols = [
            { field: 'eventID', header: 'Event ID' },
            { field: 'eventName', header: 'Event Name' },
            { field: 'startDate', header: 'Start Date' },
            { field: 'endDate', header: 'End Date' },
            { field: 'description', header: 'Description' }
        ];
    }
}
