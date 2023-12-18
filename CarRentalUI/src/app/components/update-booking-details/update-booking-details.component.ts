import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesService } from 'src/app/Service/services.service';

@Component({
  selector: 'app-update-booking-details',
  templateUrl: './update-booking-details.component.html',
  styleUrls: ['./update-booking-details.component.css']
})
export class UpdateBookingDetailsComponent implements OnInit {
  agreementCollection: any = [];
  id: any;
  route = "getCarAgreement";
  route2 = "EditAgreement";

  agreementData = new FormGroup({
    rentalStartDate: new FormControl(''),
    rentalEndDate: new FormControl('')
  });

  constructor(
    private service: ServicesService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe
  ) {
    this.id = this.activatedRoute.snapshot.params['id'];
    console.warn(this.id);
  }

  ngOnInit(): void {
    this.service.getAgreement(this.route).subscribe((result: any) => {
      console.warn("Result", result);
      result.forEach((object: any) => {
        if (this.id == object.id) {
          this.agreementCollection.push(object);
        }
      });
      console.warn("Agreement Data", this.agreementCollection);
      
      if (this.agreementCollection.length > 0) {
        this.agreementData.patchValue({
          rentalStartDate: this.agreementCollection[0].rentalStartDate,
          rentalEndDate: this.agreementCollection[0].rentalEndDate
        });
      }
    });
  }

  Submit() {
    console.warn("Updated Data", this.agreementData.value);
    this.service.updateAgreement(this.agreementData.value, this.route2).subscribe(() => {
      // Handle success or any further actions
    });
  }
}
