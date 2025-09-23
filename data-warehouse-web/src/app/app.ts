import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomTable } from './components/custom-table/custom-table';
import { NavBar } from './components/nav-bar/nav-bar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,
    CustomTable,
    NavBar
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('data-warehouse-web');
}
