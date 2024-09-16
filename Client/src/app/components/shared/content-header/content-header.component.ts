import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-content-header',
  standalone: true,
  imports: [],
  templateUrl: './content-header.component.html',
  styleUrl: './content-header.component.css'
})
export class ContentHeaderComponent {

  @Input() title = '';
  @Input() item = '';
  @Input() itemActive = '';


}