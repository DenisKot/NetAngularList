import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface ClientInfo {
  numberInLine: number;
  fullName: string;
  checkInTime: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public inServiceClients: ClientInfo[] = [];
  public inLineClients: ClientInfo[] = [];
  public fullName: string = "";

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getInService();
    this.getInLine();
  }

  getInService() {
    this.http.get<ClientInfo[]>('/api/client/inService').subscribe(
      (result) => {
        this.inServiceClients = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getInLine() {
    this.http.get<ClientInfo[]>('/api/client/inLine').subscribe(
      (result) => {
        this.inLineClients = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onAddButtonClick() {
    this.http.post(`/api/client/add?fullName=${this.fullName}`, null).subscribe(
      (result) => {
        this.fullName = "";
        this.getInLine();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onNextButtonClick() {
    let current = 0;
    if (this.inServiceClients.length > 0) {
      current = this.inServiceClients[0].numberInLine;
    }
    this.http.post(`/api/client/next?numberInLine=${current}`, null).subscribe(
      (result) => {
        this.getInService();
        this.getInLine();
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
