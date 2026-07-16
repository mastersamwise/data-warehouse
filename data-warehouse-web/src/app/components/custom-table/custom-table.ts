
// https://primeng.org/table#filter-basic
import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, inject } from '@angular/core';
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
  selector: 'app-custom-table',
  templateUrl: './custom-table.html',
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
  styleUrl: './custom-table.css'
})
export class CustomTable
 {
    private pokemonService = inject(PokemonService);
    private messageService = inject(MessageService);
    private changeDetector = inject(ChangeDetectorRef);
    private datePipe = inject(DatePipe);
    private editingRowKeys: { [key: string]: boolean } = {};

    public pokemonEvents!: PokemonEvent[];
    public clonedPokemonEvents!: PokemonEvent[];
    public selectedPokemonEvent: any = {};
    //public selectedColumns: Column[] = pokemonColumns;
    public cols: Column[] = [... pokemonColumns];
    public isEditDialogVisible: boolean = false;

    public EDIT_WIDTH: string = '50px';

    @Input() public buttonAddLabel: string = "Add Item";

    @Input() public rowKey: string = "id";
    @Input() public editMode: string = "row";
    @Input() public allColumns: any[] = [];
    @Input() public selectedColumns: any[] = [];
    @Input() public numRowsToDisplay: number = 25;
    @Input() public rowsPerPageOptions: number[] = [25, 50, 100];
    @Input() public isScrollable: string = "true";
    @Input() public scrollDirection: string = "horizontal";
    @Input() public sortMode: string = "multiple";
    @Input() public areColumnsResizable: string = "true";
    @Input() public shouldShowRowHover: string = "true"

    @Input() public dialogHeader: string = "Edit Item";
    @Input() public dialogEditHeader: string = "Update the item info";

    @Output() public rowAdded = new EventEmitter<void>(); 
    @Output() public rowSaved = new EventEmitter<void>(); 

    addRow(): void {
      new this.rowAdded().emit();
    }

    saveRow(): void {
      this.rowSaved.emit();
    }


}
