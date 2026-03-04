
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

import { Dialog } from 'primeng/dialog';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { TextareaModule } from 'primeng/textarea';
import { Tag } from 'primeng/tag';
import { InputNumber } from 'primeng/inputnumber';
import { AuditInfo } from '../../../classes/Common/AuditInfo';

interface Column {
    field: string;
    header: string;
    type: string;
    width: string;
    isEditable: boolean;
}

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.html',
  imports: [
    ButtonModule,
    ConfirmDialog,
    Dialog,
    FormsModule,
    IconFieldModule,
    InputIconModule,
    InputNumber,
    InputTextModule,
    MultiSelectModule,
    RippleModule,
    SelectModule,
    TableModule,
    Tag,
    TagModule,
    TextareaModule,
    ToastModule,
    ToolbarModule
  ],
  providers: [
    MessageService,
    PokemonService
  ],
  styleUrl: './pokemon-list.css'
})
export class PokemonList
 {
    private pokemonService = inject(PokemonService);
    private messageService = inject(MessageService);

    public pokemonEvents!: PokemonEvent[];
    public clonedPokemonEvents!: PokemonEvent[];
    cols!: Column[];
    editingRowKeys: { [key: string]: boolean } = {};

    ngOnInit() {
      this.loadEvents();
    }

    loadEvents() {
        this.pokemonService.getPokemonEvents().subscribe({
          next: (data: PokemonEvent[]) => {
            this.pokemonEvents = data;
            this.clonedPokemonEvents = [... data];
            console.log('Events loaded successfully: ', this.pokemonEvents);
          },
          error: (error: any) => {
            console.error('There was an error loading the events:', error);
          }}
        );

        this.cols = [
            { field: 'eventID', header: 'Event ID', type: 'numeric', width: '25px', isEditable: false},
            { field: 'eventName', header: 'Event Name', type: 'text', width: '50px', isEditable: true },
            { field: 'startDate', header: 'Start Date', type: 'date', width: '50px', isEditable: true },
            { field: 'endDate', header: 'End Date', type: 'date', width: '50px', isEditable: true },
            { field: 'description', header: 'Description', type: 'text', width: '75px', isEditable: true }
        ];
    }

    clearTable(pokemonEvents: PokemonEvent[]) {
      pokemonEvents = [];
    }

    onRowEditInit(pokemonEvent: PokemonEvent) {
        this.clonedPokemonEvents[pokemonEvent.eventID] = { ...pokemonEvent };
    }

    onRowEditSave(pokemonEvent: PokemonEvent) {
       if (pokemonEvent.isNew) {
        pokemonEvent.isNew = false;
      }
        //if (pokemonEvent.price > 0) {
            delete this.clonedPokemonEvents[pokemonEvent.eventID];
            this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Pokemon Event is updated' });
        //} else {
            // this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Invalid Price' });
        //}
    }

    onRowEditCancel(pokemonEvent: PokemonEvent) {
        this.pokemonEvents[pokemonEvent.eventID] = this.clonedPokemonEvents[pokemonEvent.eventID];
        delete this.clonedPokemonEvents[pokemonEvent.eventID];
    }

    addRow() {
      const lastIndex = this.pokemonEvents.length - 1;
      const newRow: PokemonEvent = {
        eventID: this.pokemonEvents[lastIndex].eventID + 1,
        eventName: '',
        isEventActive: true,
        startDate: new Date(),
        endDate: new Date(),
        description: '',
        eventType: '',
        serialCode: '',
        auditInfo: new AuditInfo(new Date(), '', new Date(), '', false),
        isNew: true
      };

      this.pokemonEvents = [newRow, ...this.pokemonEvents];

      this.editingRowKeys[newRow.eventID!] = true;
    }

    saveRow(pokemonEvent: PokemonEvent) {
      if (pokemonEvent.isNew) {
        pokemonEvent.isNew = false;
      }
      this.onRowEditSave(pokemonEvent);
    }

    cancelRow(pokemonEvent: PokemonEvent, index: number) {
      if (pokemonEvent.isNew) {
        this.pokemonEvents.splice(index, 1);
        this.pokemonEvents = [...this.pokemonEvents];
      }
    }

    updatePokemonEvent(pokemonEvent: PokemonEvent) {

    }
}
