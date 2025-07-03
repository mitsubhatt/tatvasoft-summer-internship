import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DemoService } from '../services/demo.service';

@Component({
  selector: 'app-demo',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './demo.component.html',
  styleUrl: './demo.component.css'
})
export class DemoComponent {

  name = '';

  constructor(private demoService: DemoService) { }

//   ngOnInit() {
//     setTimeout(() => {
//       this.name = 'xyz';
//     }, 2000);

  ngOnInit() {
    this.demoService.fetchData();
  }
}

