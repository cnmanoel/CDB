import { Component } from '@angular/core';
import { CdbCalculatorComponent } from './cdb-calculator/cdb-calculator.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [CdbCalculatorComponent]
})
export class AppComponent {
  title = 'CDBWeb';
}