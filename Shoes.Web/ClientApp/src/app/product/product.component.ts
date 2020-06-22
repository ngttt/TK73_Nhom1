import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $ : any;

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
   products: any = {
     data:[],
     totalRecord: 0,
     page:0,
     size:5,
     TotalPage:0
   }

   product:any = {
    productId : 1,
    productName : "Laptop Asus",
    categoryId : 1,
    supplierId : 1,
    unitPrice : 15000000,
    unitInStock:20,
    color:"trắng",
    image: "aaaaaaa"
  }
  isEdit: boolean = true;

  constructor( private http: HttpClient,@Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchProduct(1);
  }
  searchProduct(cPage){
    let x = {
      page : cPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/api/Productss/search-product',x).subscribe(result=>{
      this.products = result;
      this.products = this.products.data;
      
    },error=>console.error(error));
    
  }
  searchNext(){
   
    if(this.products.page < this.products.totalPage){
      let nextPage = this.products.page +1;
      let x = {
        page : nextPage,
        size :5,
        keyword:""
      }
      this.http.post('https://localhost:44355/'+'api/Productss/search-product',x).subscribe(result=>{
        this.products = result;
        this.products = this.products.data;
        
      },error=>console.error(error));

  }
  else{
    alert("Bạn đang ở trang cuối cùng");
  }
 }
 searchPrevious(){
  if(this.products.page>1){
    let nextPage = this.products.page -1;
    let x = {
      page : nextPage,
      size :5,
      keyword:""
    }
    this.http.post('https://localhost:44355/'+'api/Productss/search-product',x).subscribe(result=>{
      this.products = result;
      this.products = this.products.data;
      
    },error=>console.error(error));

}
else{
  alert("Bạn đang ở trang đầu tiên");
}
}
openModal(isNew, index) {
  if(isNew) {
    this.isEdit = false;
    this.product = {
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
    this.product = index;
  }
  //mở popup bằng jquery
  $('#exampleModal').modal("show");
}
// Tajo hàm để làm nút add
addProduct() {
  var x = this.product;
  this.http.post('https://localhost:44355/api/Productss/create-product',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.product = res.data;
  this.isEdit = true;
  this.searchProduct(1);
  alert("New products have been added successfully!");
  }  
  }, error => console.error(error));
}

// Tạo hàm làm nút save
updateProduct() {
  var x = this.product;
  this.http.post('https://localhost:44355/api/Productss/update-product',x).subscribe(result => {
  var res:any = result;
  if(res.success) {
  this.product = res.data;
  this.isEdit = false;
  this.searchProduct(1);
  alert("New products have been saved successfully!");
  }  
  }, error => console.error(error));
}

deleteProduct(p) 
{
  var r = confirm("Are you sure to delete this product")
  if(r == true) {
    // this.product = this.products.data[p];
    // var x = this.product;
    this.http.post('https://localhost:44355/api/Productss/delete-product', p).subscribe(result => {
      var res : any = result;
      if(res.success) {
        this.searchProduct(1);
        alert("Product has been deleted successfully");
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

