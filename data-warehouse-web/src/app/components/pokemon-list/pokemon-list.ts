
// https://primeng.org/table#filter-basic
import { Component, OnInit, inject } from '@angular/core';
import { TableModule } from 'primeng/table';
import { PokemonService } from '../../services/pokemon.service';
import { PopoverTokenSections } from '@primeuix/themes/types/popover';
import { PokemonEvent } from '../../../classes/Pokemon/PokemonEvent';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';

import { FormsModule } from '@angular/forms';
import { SelectModule } from 'primeng/select';
import { MultiSelectModule } from 'primeng/multiselect';
import { TagModule } from 'primeng/tag';
import { InputTextModule } from 'primeng/inputtext';

import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { SelectItem, MessageService } from 'primeng/api';

interface Column {
    field: string;
    header: string;
    type: string;
    isEditable: boolean;
}

@Component({
    selector: 'app-pokemon-list',
    templateUrl: './pokemon-list.html',
    imports: [
      ButtonModule,
      FormsModule,
      IconFieldModule,
      InputIconModule,
      InputTextModule,
      MultiSelectModule,
      RippleModule,
      SelectModule,
      TableModule,
      TagModule,
      ToastModule,
    ],
    providers: [
      MessageService,
      PokemonService
    ]
})
export class PokemonList
 {
    private pokemonService = inject(PokemonService);
    private messageService = inject(MessageService);

    public pokemonEvents!: PokemonEvent[];
    public clonedPokemonEvents!: PokemonEvent[];
    cols!: Column[];

    ngOnInit() {
      this.loadEvents();
    }

    loadEvents() {
        this.pokemonService.getPokemonEvents().subscribe({
          next: (data: PokemonEvent[]) => {
            this.pokemonEvents = data;
            this.clonedPokemonEvents = data;
            console.log('Events loaded successfully: ', this.pokemonEvents);
          },
          error: (error: any) => {
            console.error('There was an error loading the events:', error);
          }}
        );

        this.cols = [
            { field: 'eventID', header: 'Event ID', type: 'numeric', isEditable: false},
            { field: 'eventName', header: 'Event Name', type: 'text', isEditable: true },
            { field: 'startDate', header: 'Start Date', type: 'date', isEditable: true },
            { field: 'endDate', header: 'End Date', type: 'date', isEditable: true },
            { field: 'description', header: 'Description', type: 'text', isEditable: true }
        ];
    }

    clearTable(pokemonEvents: PokemonEvent[]) {
      pokemonEvents = [];
    }

    onRowEditInit(pokemonEvent: PokemonEvent) {
        this.clonedPokemonEvents[pokemonEvent.eventID] = { ...pokemonEvent };
    }

    onRowEditSave(pokemonEvent: PokemonEvent) {
        //if (pokemonEvent.price > 0) {
            delete this.clonedPokemonEvents[pokemonEvent.eventID];
            this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Product is updated' });
        //} else {
            // this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Invalid Price' });
        //}
    }

    onRowEditCancel(pokemonEvent: PokemonEvent) {
        this.pokemonEvents[pokemonEvent.eventID] = this.clonedPokemonEvents[pokemonEvent.eventID];
        delete this.clonedPokemonEvents[pokemonEvent.eventID];
    }

    updatePokemonEvent(pokemonEvent: PokemonEvent) {

    }
}
