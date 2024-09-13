import { Component, ViewChild } from '@angular/core';
import { ContentHeaderComponent } from '../../components/shared/content-header/content-header.component';
import { Table, TableModule } from 'primeng/table';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [ContentHeaderComponent, TableModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  // Method to handle global filtering
  applyFilterGlobal(event: any) {
    const filterValue = event.target.value;
    if (this.table) {  // Check if table exists before calling the filterGlobal method
      this.table.filterGlobal(filterValue, 'contains');
    }
  }
  title: string = 'Admin Dashboard IVR';
  item: string = 'Admin';
  itemActive: string = 'Dashoard Admin';

  cars: any[] = [];

  // Access the table component using ViewChild
  @ViewChild('table') table!: Table;

  constructor() {
    this.cars = [
      { brand: 'Toyota', year: 2018, color: 'Blue', vin: 'ABC123' },
      { brand: 'Ford', year: 2017, color: 'Black', vin: 'DEF456' },
      { brand: 'Chevrolet', year: 2016, color: 'White', vin: 'GHI789' },
      { brand: 'Honda', year: 2019, color: 'Red', vin: 'JKL012' },
    ];
  }

}
