import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values: any;
  url: string;

  constructor(private http: HttpClient) {
    this.url = 'http://localhost:5000/api/values';
  }

  ngOnInit() { // life cycle hook
    this.getValues();
  }

  getValues() { // observarable stream of data
    this.http.get(this.url).subscribe(
      (response) => {
        this.values = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
