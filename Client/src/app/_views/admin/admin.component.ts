import { Component } from '@angular/core';
import { ContentHeaderComponent } from '../../_components/shared/content-header/content-header.component';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [ContentHeaderComponent],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
title: string = 'Admin Dashboard IVR';
item: string = 'Admin';
itemActive: string = 'Dashoard Admin';

}
