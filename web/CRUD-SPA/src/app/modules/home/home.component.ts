import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/shared/models/customer.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  customers: Array<Customer>;
  checks: Array<boolean>;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.customers = data.customers;
      this.checks = new Array<boolean>(this.customers.length);
    });
  }

  checkboxChange(e, i: number): void {
    this.checks[i] = e.target.checked;
  }

}
