
// https://primeng.org/table#filter-basic
import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
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
import { DatePipe } from '@angular/common';
import { DatePicker } from "primeng/datepicker";
import { MatNoDataRow } from "@angular/material/table";

export type ColumnType = 'text' | 'date' | 'textarea' | 'numeric';

interface Column {
    field: keyof PokemonEvent;
    header: string;
    type: ColumnType;
    width: string;
    isEditable: boolean;
}

const pokemonColumns: Column[] = [
  { field: 'eventID', header: 'Event ID', type: 'numeric', width: '75px', isEditable: false},
  { field: 'isEventActive', header: 'Is Active', type: 'text', width: '75px', isEditable: false},
  { field: 'eventName', header: 'Event Name', type: 'text', width: '150px', isEditable: true },
  { field: 'eventType', header: 'Event Type', type: 'text', width: '150px', isEditable: true },
  { field: 'startDate', header: 'Start Date', type: 'date', width: '115px', isEditable: true },
  { field: 'endDate', header: 'End Date', type: 'date', width: '115px', isEditable: true },
  { field: 'serialCode', header: 'Code', type: 'text', width: '150px', isEditable: true },
  { field: 'description', header: 'Description', type: 'textarea', width: '150px', isEditable: true }
];

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.html',
  imports: [
    ButtonModule,
    ConfirmDialog,
    DatePipe,
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
    ToolbarModule,
    DatePicker,
    MatNoDataRow
],
  providers: [
    DatePipe,
    MessageService,
    PokemonService
  ],
  styleUrl: './pokemon-list.css'
})
export class PokemonList
 {
    private pokemonService = inject(PokemonService);
    private messageService = inject(MessageService);
    private changeDetector = inject(ChangeDetectorRef);
    private datePipe = inject(DatePipe);
    private editingRowKeys: { [key: string]: boolean } = {};

    public pokemonEvents!: PokemonEvent[];
    public clonedPokemonEvents!: PokemonEvent[];
    public selectedPokemonEvent: any = {};
    public selectedColumns: Column[] = pokemonColumns;
    public cols: Column[] = [... pokemonColumns];
    public isEditDialogVisible: boolean = false;

    public EDIT_WIDTH: string = '50px';

    ngOnInit() {
      this.loadEvents();
    }

    loadEvents() {
        this.pokemonService.getPokemonEvents().subscribe({
          next: (data: PokemonEvent[]) => {
            this.pokemonEvents = data;
            this.clonedPokemonEvents = [... data];
            this.changeDetector.markForCheck();
            console.log('Events loaded successfully: ', this.pokemonEvents);
          },
          error: (error: any) => {
            console.error('There was an error loading the events:', error);
          }}
        );

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
            const i = this.clonedPokemonEvents.findIndex(e => e.eventID == pokemonEvent.eventID);
            delete this.clonedPokemonEvents[i];
            this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Pokemon Event is updated' });
        //} else {
            // this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Invalid Price' });
        //}
    }

    onRowEditCancel(pokemonEvent: PokemonEvent) {
        const i = this.pokemonEvents.findIndex(e => e.eventID == pokemonEvent.eventID);
        this.pokemonEvents[i] = pokemonEvent;
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
        teraType: '',
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

    showEditDialog(pokemonEvent: any) {
      this.selectedPokemonEvent = {... pokemonEvent};
      this.isEditDialogVisible = true;
    }

    savePokemonEventChange(pokemonEvent: PokemonEvent) {
      const i = this.pokemonEvents.findIndex(e => e.eventID == pokemonEvent.eventID);
      this.pokemonEvents[i] = pokemonEvent;
      this.isEditDialogVisible = false;
    }
}
