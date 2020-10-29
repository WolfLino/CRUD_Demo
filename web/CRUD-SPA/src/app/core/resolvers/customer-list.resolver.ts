import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Customer } from '../../shared/models/customer.model';
import { CustomerService } from '../services/customer.service';

@Injectable()
export class CustomerListResolver implements Resolve<Customer> {
    pageNumber = 1;
    pageSize = 20;

    constructor(private customerService: CustomerService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<Customer> {
        return this.customerService.getUsers();
    }
}
