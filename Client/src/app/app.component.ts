import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {
  SidebarComponent
} from './layout/sidebar/sidebar.component';
import { ContentComponent
} from './layout/content/content.component';
import { FooterComponent } from './layout/footer/footer.component';
import { NavComponent } from './layout/nav/nav.component';
import { ControlComponent } from './layout/control/control.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet , SidebarComponent, ContentComponent, FooterComponent, NavComponent, ControlComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Client';
}
