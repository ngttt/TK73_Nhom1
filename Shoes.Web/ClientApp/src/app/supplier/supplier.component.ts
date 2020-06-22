import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $ : any;

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {

  suppliers:any = {
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0
  }

  supplier: any = {
    suppliersId: 1,
    suppliersName : "test",
    city: "test"
  }

  isEdit: boolean = true;

  constructor( private http: HttpClient,@Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchSupplier(1);
  }
  searchSupplier(cPage){
    let x = {
      page : cPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/api/Suppliers/search-supplier',x).subscribe(result=>{
      this.suppliers = result;
      this.suppliers = this.suppliers.data;
      
    },error=>console.error(error));
    
  }
  searchNext(){
   
    if(this.suppliers.page < this.suppliers.totalPage){
      let nextPage = this.suppliers.page +1;
      let x = {
        page : nextPage,
        size :5,
        keyword:""
      }
      this.http.post('https://localhost:44355/'+'api/Suppliers/search-supplier',x).subscribe(result=>{
        this.suppliers = result;
        this.suppliers = this.suppliers.data;
        
      },error=>console.error(error));

  }
  else{
    alert("Bạn đang ở trang cuối cùng");
  }
 }
 searchPrevious(){
  if(this.suppliers.page>1){
    let nextPage = this.suppliers.page -1;
    let x = {
      page : nextPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/'+'api/Suppliers/search-supplier',x).subscribe(result=>{
      this.suppliers = result;
      this.suppliers = this.suppliers.data;
      
    },error=>console.error(error));

}
else{
  alert("Bạn đang ở trang đầu tiên");
}
}
openModal(isNew, index) {
  if(isNew) {
    this.isEdit = false;
    this.supplier = {
      suppliersId : 1,
      suppliersName : "",
      city:""
    }
  }
  else {
    this.isEdit = true;
    this.supplier = index;
  }
  //mở popup bằng jquery
  $('#exampleModal').modal("show");
}
// Tajo hàm để làm nút add
addSupplier() {
  var x = this.supplier;
  this.http.post('https://localhost:44355/api/Suppliers/create-supplier',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.supplier = res.data;
  this.isEdit = false;
  this.searchSupplier(1);
  alert("New supplier have been added successfully!");
  }  
  }, error => console.error(error));
}

// Tạo hàm làm nút save
updateSupplier() {
  var x = this.supplier;
  this.http.post('https://localhost:44355/api/Suppliers/update-supplier',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.supplier = res.data;
  this.isEdit = true;
  this.searchSupplier(1);
  alert("New supplier have been saved successfully!");
  }  
  }, error => console.error(error));
}
deleteSupplier(p) 
{
  var r = confirm("Are you sure to delete this suplier")
  if(r == true) {
    this.http.post('https://localhost:44355/api/Suppliers/delete-suppliers', p).subscribe(result => {
      var res : any = result;
      if(res.success) {
        this.searchSupplier(1);
        alert("Suplier has been deleted successfully");
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
