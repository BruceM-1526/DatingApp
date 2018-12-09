import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private http: HttpClient) {}
  values: any;
  url: string;

  ngOnInit() {
    this.url = 'http://localhost:5000/api/values';
    this.getValues();
  }

  registerToggle() {
    this.registerMode = true;
  }

  getValues() {
    // observarable stream of data
    this.http.get(this.url).subscribe(
      response => {
        this.values = response;
      },
      error => {
      }
    );
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
