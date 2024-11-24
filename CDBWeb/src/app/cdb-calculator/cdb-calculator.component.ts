import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-cdb-calculator',
  templateUrl: './cdb-calculator.component.html',
  styleUrls: ['./cdb-calculator.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule]
})
export class CdbCalculatorComponent {
  initialValue: number = 0;
  months: number = 1;
  result: any;

  constructor(private http: HttpClient) {}

  calculateCDB() {
    const request = {
      initialValue: this.initialValue,
      months: this.months
    };

    this.http.post<any>('http://localhost:5050/api/cdb/calculate', request)
      .subscribe(response => {
        this.result = response;
      }, error => {
        console.error('Error calculating CDB', error);
      });
  }
}