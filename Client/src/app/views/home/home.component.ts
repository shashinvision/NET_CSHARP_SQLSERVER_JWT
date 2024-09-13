import { Component } from '@angular/core';
import { ContentHeaderComponent } from "../../components/shared/content-header/content-header.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ContentHeaderComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  title: string = 'User Dashboard IVR';
  item: string = 'User';
  itemActive: string = 'Dashoard';
}
