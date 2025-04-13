import { Component } from '@angular/core';
import {MatSidenavModule} from '@angular/material/sidenav';
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [MatSidenavModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

}
