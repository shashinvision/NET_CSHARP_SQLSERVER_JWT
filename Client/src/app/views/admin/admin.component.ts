import { Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { ContentHeaderComponent } from '../../components/shared/content-header/content-header.component';
import { Table, TableModule } from 'primeng/table';
import { UserService } from '../../_services/user.service';
import { UserDto } from '../../_models/UserDto';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [ContentHeaderComponent, TableModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css',
  providers: [UserService]
})
export class AdminComponent implements OnInit {

  private userService = inject(UserService);
  title: string = 'Admin Dashboard IVR';
  item: string = 'Admin';
  itemActive: string = 'Dashoard Admin';
  users = this.userService.users;

  // Access the table component using ViewChild
  @ViewChild('table') table!: Table;

  async ngOnInit(): Promise<void> {
    await this.getUsers();
  }

  // Method to handle global filtering
  applyFilterGlobal(event: any) {
    const filterValue = event.target.value;
    if (this.table) {  // Check if table exists before calling the filterGlobal method
      this.table.filterGlobal(filterValue, 'contains');
    }
  }


  async getUsers() : Promise<void> {
    let usersResponse = await this.userService.get()
    usersResponse.subscribe();
  }
}

