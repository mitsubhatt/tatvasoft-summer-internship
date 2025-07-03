import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DemoService {

  private variable = ' ';

  constructor(private http: HttpClient) { }

  fetchData() {
    this.http.get('https://jsonplaceholder.typicode.com/todos/1').subscribe({
      next : (res) => {
        console.log(res);
      },
      error: (err) => {
        console.error(err);
      },
    });
  }
  }
