import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/Service/services.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-booking-page',
  templateUrl: './booking-page.component.html',
  styleUrls: ['./booking-page.component.css']
})
export class BookingPageComponent implements OnInit {
  email: any;
  id: any;
  route = "getCars";
  route2 = "AddCarAgreement";
  route3 = "getCarAgreement"
  collection:any=[]
  Carcollectiondata: any = [];
  formError: string | null = null;

  constructor(private service: ServicesService, private router: ActivatedRoute) {
    
    const userdata = sessionStorage.getItem('username');
    if (userdata) {
      const userData = JSON.parse(userdata);
      this.email = userData.email;
    }
    console.log(userdata);
    console.log(this.email);

    this.id = this.router.snapshot.params['id'];
    this.carForm.controls['CarId'].setValue(this.id);
    this.carForm.controls['UserEmail'].setValue(this.email);

    this.service.getAgreement(this.route3).subscribe((result:any)=>{
      console.log("result", result);
      this.collection = result;
    })
  }

  ngOnInit(): void {
    console.warn(this.router);
    console.log("Id is", this.id);
    this.service.getCars(this.route).subscribe((result: any) => {
      console.warn("get product call", result);
      result.forEach((object: any) => {
        console.warn("Object Id", object.vehicle_Id);
        if (this.id == object.vehicle_Id) {
          console.log(object);
          this.Carcollectiondata.push(object);
        } else {
          console.log("Nooooooooooooooooo");
        }
      });
      console.log("received collection data", this.Carcollectiondata);
    });
  }

  carForm = new FormGroup({
    RentalStartDate: new FormControl('', [Validators.required]),
    RentalEndDate: new FormControl('', [Validators.required]),
    CarId: new FormControl(),
    UserEmail: new FormControl(),
  });

  Submit() {
    const startDate = new Date(this.carForm.value.RentalStartDate as string);
    const endDate = new Date(this.carForm.value.RentalEndDate as string);
    const today = new Date();

    if (startDate < today) {
      this.formError = 'Start date must be greater than or equal to today.';
    } else if (endDate < startDate) {
      this.formError = 'End date must be greater than or equal to the start date.';
    } else {
      this.formError = null;

    if (this.carForm.valid) {
      this.service.AddAgreement(this.carForm.value, this.route2).subscribe(() => {
      })
      console.warn("Form Data",this.carForm)     
    }
}
}
}
