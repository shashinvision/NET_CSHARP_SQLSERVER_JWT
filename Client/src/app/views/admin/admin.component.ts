import { Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, Validators } from '@angular/forms';
import { ContentHeaderComponent } from '../../components/shared/content-header/content-header.component';
import { Table, TableModule } from 'primeng/table';
import { UserService } from '../../_services/user.service';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { UserAddDto } from '../../_models/UserAddDto';
import { UserDto } from '../../_models/UserDto';
import { RolesDto } from '../../_models/RolesDto';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, FormsModule, ContentHeaderComponent, TableModule, DialogModule, ToastModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css',
  providers: [UserService, MessageService]
})
export class AdminComponent implements OnInit {

  private userService = inject(UserService);
  private messageService = inject(MessageService);

  showError(message: string = '') {
    this.messageService.add({severity:'error', summary: 'Error', detail: message});
}


  title: string = 'Admin Dashboard IVR';
  item: string = 'Admin';
  itemActive: string = 'Dashoard Admin';
  users = signal<UserDto[]>([]); // Changed to array of UserDto
  roles = signal<RolesDto[]>([]);
  email = new FormControl('', [
    Validators.required,
    Validators.email
  ]);

  displayModal = false;
  public name: string = '';
  public password: string = '';
  public passwordConfirm: string = '';
  public role_id: number = 0;

  // Access the table component using ViewChild
  @ViewChild('table') table!: Table;

  async ngOnInit(): Promise<void> {
    await this.getUsers();
    await this.getRoles();
  }

  // Method to handle global filtering
  applyFilterGlobal(event: any) {
    const filterValue = event.target.value;
    if (this.table) {  // Check if table exists before calling the filterGlobal method
      this.table.filterGlobal(filterValue, 'contains');
    }
  }

  getUsers() {
    this.userService.get();
    this.users = this.userService.users;
  }

  async newUser() {

    if (this.name == '') return this.showError("Name is required");
    if (this.name && !/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(this.name)) return this.showError("Invalid email");
    if (this.password == '') return this.showError("Password is required");
    if (this.password.length < 8) return this.showError("Password must be at least 8 characters long");
    if (this.password != this.passwordConfirm) return this.showError("Passwords do not match");
    if (this.role_id == 0) return this.showError("Role is required");

    let userAddDto = new UserAddDto();

    userAddDto.name = this.name;
    userAddDto.role_id = this.role_id;
    userAddDto.password = this.password;

    this.userService.add(userAddDto).subscribe({
      next: async (response) => {
        console.log('User added successfully:', response);
        this.displayModal = false;
        this.getUsers();  // Refresh users after adding a new one
      },
      error: (err) => {
        console.error('Failed to add user:', err);
        alert('Failed to add user, please try again.');
      }
    });
  }

  getRoles() {
    this.userService.getRoles();
    this.roles = this.userService.roles;
  }

  cleanModalAdd() {
    this.name = '';
    this.password = '';
    this.passwordConfirm = '';
    this.role_id = 0;
  }

}

