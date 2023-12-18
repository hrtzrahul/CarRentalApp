import { Component , OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/Service/services.service';

@Component({
  selector: 'app-update-car-details',
  templateUrl: './update-car-details.component.html',
  styleUrls: ['./update-car-details.component.css']
})
export class UpdateCarDetailsComponent implements OnInit{
  route = "editCar"
  route2 = "getCars"
  carCollection:any = []
  answer:any 

  addCars = new FormGroup({
    vehicle_Id : new FormControl(''),
    maker: new FormControl('', [Validators.required, Validators.maxLength(20)]),
    model: new FormControl('', [Validators.required, Validators.maxLength(20)]),
    rentalPrice: new FormControl('', [Validators.required]),
    year: new FormControl('', [Validators.min(1886)]),
    color: new FormControl(''),
    transmissionType: new FormControl(''),
    numberOfDoors: new FormControl('', [Validators.min(1)]),
    fuelType: new FormControl(''),
    mileage: new FormControl('', [Validators.min(0)]),
    lastMaintenanceDate: new FormControl(''),
  });
  constructor(private service : ServicesService, private activatedRoute : ActivatedRoute){
  }
ngOnInit(): void {
  const id = this.activatedRoute.snapshot.params['id'];
  this.addCars.patchValue({
    vehicle_Id: id
  });
  this.service.getCars(this.route2).subscribe((result: any) => {
    this.carCollection = result;
    for (let data of this.carCollection) {
      if (id == data.Vehicle_Id) {
        this.answer = data;
        this.addCars = new FormGroup({
          vehicle_Id: new FormControl(this.answer.vehicle_Id),
          maker: new FormControl(this.answer.maker),
          model: new FormControl(this.answer.model, [Validators.required, Validators.maxLength(20)]),
          rentalPrice: new FormControl(this.answer.rentalPrice),
          year: new FormControl(this.answer.year),
          color: new FormControl(this.answer.color),
          transmissionType: new FormControl(this.answer.transmissionType),
          numberOfDoors: new FormControl(this.answer.numberOfDoors),
          fuelType: new FormControl(this.answer.fuelType),
          mileage: new FormControl(this.answer.mileage),
          lastMaintenanceDate: new FormControl(this.answer.lastMaintenanceDate),
        });
      }
    }
  });
  
}
  Submit(){
    this.service.updateCar(this.addCars.value, this.route).subscribe(()=>{
      this.carCollection = this.route

    })
  }





  get Maker(): FormControl {
    return this.addCars.get("maker") as FormControl;
  }

  get Model(): FormControl {
    return this.addCars.get("model") as FormControl;
  }

  get RentalPrice(): FormControl {
    return this.addCars.get("rentalPrice") as FormControl;
  }

  get Year(): FormControl {
    return this.addCars.get("year") as FormControl;
  }

  get Color(): FormControl {
    return this.addCars.get("color") as FormControl;
  }

  get TransmissionType(): FormControl {
    return this.addCars.get("transmissionType") as FormControl;
  }

  get NumberOfDoors(): FormControl {
    return this.addCars.get("numberOfDoors") as FormControl;
  }

  get FuelType(): FormControl {
    return this.addCars.get("fuelType") as FormControl;
  }


  get Mileage(): FormControl {
    return this.addCars.get("mileage") as FormControl;
  }

  get LastMaintenanceDate(): FormControl {
    return this.addCars.get("lastMaintenanceDate") as FormControl;
  }
}
