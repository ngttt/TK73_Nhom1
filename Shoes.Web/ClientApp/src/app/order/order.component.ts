import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $ : any;

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
   orders: any = {
     data:[],
     totalRecord: 0,
     page:0,
     size:5,
     TotalPage:0
   }

   order:any = {
    orderId : 1,
    employeeId : "test",
    orderDate : "test",
    shipName : "test",
    city: "test",
    note : "test"
  }
  isEdit: boolean = true;

  constructor( private http: HttpClient,@Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchOrder(1);
  }
  searchOrder(cPage){
    let x = {
      page : cPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/api/Orders/search-order',x).subscribe(result=>{
      this.orders = result;
      this.orders = this.orders.data;
      
    },error=>console.error(error));
    
  }
  searchNext(){
   
    if(this.orders.page < this.orders.totalPage){
      let nextPage = this.orders.page +1;
      let x = {
        page : nextPage,
        size :5,
        keyword:""
      }
      this.http.post('https://localhost:44355/'+'api/Orders/search-order',x).subscribe(result=>{
        this.orders = result;
        this.orders = this.orders.data;
        
      },error=>console.error(error));

  }
  else{
    alert("Bạn đang ở trang cuối cùng");
  }
 }
 searchPrevious(){
  if(this.orders.page>1){
    let nextPage = this.orders.page -1;
    let x = {
      page : nextPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/'+'api/Orders/search-order',x).subscribe(result=>{
      this.orders = result;
      this.orders = this.orders.data;
      
    },error=>console.error(error));

}
else{
  alert("Bạn đang ở trang đầu tiên");
}
}
openModal(isNew, index) {
  if(isNew) {
    this.isEdit = false;
    this.order = {
      productName : "",
      categoryId : 1,
      supplierId : 1,
      unitPrice : "",
      unitInStock:"",
      color:"",
      image: ""
    }
  }
  else {
    this.isEdit = true;
    this.order = index;
  }
  //mở popup bằng jquery
  $('#exampleModal').modal("show");
}
// Tajo hàm để làm nút add
addOrder() {
  var x = this.order;
  this.http.post('https://localhost:44355/api/Orders/create-order',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.order = res.data;
  this.isEdit = false;
  this.searchOrder(1);
  alert("New order have been added successfully!");
  }  
  }, error => console.error(error));
}

// Tạo hàm làm nút save
updateOrder() {
  var x = this.order;
  this.http.post('https://localhost:44355/api/Orders/update-order',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.order = res.data;
  this.isEdit = true;
  this.searchOrder(1);
  alert("New order have been saved successfully!");
  }  
  }, error => console.error(error));
}
deleteOrder(p) 
{
  var r = confirm("Are you sure to delete this order")
  if(r == true) {
    this.http.post('https://localhost:44355/api/Orders/delete-orders', p).subscribe(result => {
      var res : any = result;
      if(res.success) {
        this.searchOrder(1);
        alert("Order has been deleted successfully");
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

