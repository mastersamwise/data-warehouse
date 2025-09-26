import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomTable } from './components/custom-table/custom-table';
import { NavBar } from './components/nav-bar/nav-bar';
import { PokemonList } from './components/pokemon-list/pokemon-list';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [
    CommonModule,
    // CustomTable,
    NavBar,
    PokemonList,
    RouterOutlet,
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('data-warehouse-web');
}
