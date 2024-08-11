import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent implements OnInit {
  employee: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    position: ''
  }

  isEditing: boolean = false;

  ngOnInit(): void {
      this.route.paramMap.subscribe((result) => {
        const id = result.get('id');

        if(id){
          this.isEditing = true;
          this.employeeSerivice.getEmployee(Number(id))
          .subscribe({
            next: (result) => this.employee = result,
            error: (error) => {
              console.error(error);
              this.errorMessage = "Error loading employee";
            }
          })
        } 
      });
  }

  errorMessage: string = "";
  constructor(private employeeSerivice: EmployeeService, private router: Router, private route: ActivatedRoute){}

  onSubmit() : void{

    if(this.isEditing){
      this.employeeSerivice.editEmployee(this.employee)
      .subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error(error);
          this.errorMessage = `Error occurred during editing: ${error.status}`;
        }
      })
    } else {
      this.employeeSerivice.createEmployee(this.employee)
      .subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: (error) => {
          console.error(error);
          this.errorMessage = `Error occurred during creation: ${error.status}`;
        }
      });
    }
  }
}
