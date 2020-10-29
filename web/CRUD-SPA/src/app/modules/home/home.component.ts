import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/shared/models/customer.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  customers: Array<Customer>;

  constructor() { }

  ngOnInit(): void {
    this.customers = [
      { id: 1, name: 'Ulisses', dateOfBirth: new Date() }
    ];
  }

}
