import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $ : any;

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employees:any = {
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0
  }

  employee : any = {
    employeeId: 1,
    firstName : "test",
    lastName : "test",
    country : "test"
  }

  isEdit: boolean = true;

  constructor( private http: HttpClient,@Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchEmployee(1);
  }
  searchEmployee(cPage){
    let x = {
      page : cPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/api/Employees/search-employees',x).subscribe(result=>{
      this.employees = result;
      this.employees = this.employees.data;
      
    },error=>console.error(error));
    
  }
  searchNext(){
   
    if(this.employees.page < this.employees.totalPage){
      let nextPage = this.employees.page +1;
      let x = {
        page : nextPage,
        size :5,
        keyword:""
      }
      this.http.post('https://localhost:44355/'+'api/Employees/search-employees',x).subscribe(result=>{
        this.employees = result;
        this.employees = this.employees.data;
        
      },error=>console.error(error));

  }
  else{
    alert("Bạn đang ở trang cuối cùng");
  }
 }
 searchPrevious(){
  if(this.employees.page>1){
    let nextPage = this.employees.page -1;
    let x = {
      page : nextPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/'+'api/Employees/search-employees',x).subscribe(result=>{
      this.employees = result;
      this.employees = this.employees.data;
      
    },error=>console.error(error));

}
else{
  alert("Bạn đang ở trang đầu tiên");
}
}
openModal(isNew, index) {
  if(isNew) {
    this.isEdit = false;
    this.employee = {
      employeeId: 1,
      firstName : "",
      lastName : "",
      country : ""
    }
  }
  else {
    this.isEdit = true;
    this.employee = index;
  }
  //mở popup bằng jquery
  $('#exampleModal').modal("show");
}
// Tajo hàm để làm nút add
addEmployee() {
  var x = this.employee;
  this.http.post('https://localhost:44355/api/Employees/create-employees',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.employee = res.data;
  this.isEdit = false;
  this.searchEmployee(1);
  alert("New employee have been added successfully!");
  }  
  }, error => console.error(error));
}

// Tạo hàm làm nút save
updateEmployee() {
  var x = this.employee;
  this.http.post('https://localhost:44355/api/Employees/update-employees',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.employee = res.data;
  this.isEdit = true;
  this.searchEmployee(1);
  alert("New employee have been saved successfully!");
  }  
  }, error => console.error(error));
}
deleteEmployee(p) 
{
  var r = confirm("Are you sure to delete this employee")
  if(r == true) {
    // this.product = this.products.data[p];
    // var x = this.product;
    this.http.post('https://localhost:44355/api/Employees/delete-employees', p).subscribe(result => {
      var res : any = result;
      if(res.success) {
        this.searchEmployee(1);
        alert("Employee has been deleted successfully");
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error);
      alert(error)
  });
}
}
}
