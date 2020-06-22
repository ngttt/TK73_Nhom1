import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    TotalPage: 0
  }

  category: any = {
    categoryId: "1",
    categoryName: "Nguyen"
  }

  isEdit: boolean = true;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchCategory(1);
  }
  searchCategory(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post('https://localhost:44355/api/Categories/search-categories', x).subscribe(result => {
      this.categories = result;
      this.categories = this.categories.data;

    }, error => console.error(error));

  }
  searchNext() {

    if (this.categories.page < this.categories.totalPage) {
      let nextPage = this.categories.page + 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post('https://localhost:44355/' + 'api/Categories/search-categories', x).subscribe(result => {
        this.categories = result;
        this.categories = this.categories.data;

      }, error => console.error(error));

    }
    else {
      alert("Bạn đang ở trang cuối cùng");
    }
  }
  searchPrevious() {
    if (this.categories.page > 1) {
      let nextPage = this.categories.page - 1;
      let x = {
        page: nextPage,
        size: 5,
        keyword: ""
      }
      this.http.post('https://localhost:44355/' + 'api/Categories/search-categories', x).subscribe(result => {
        this.categories = result;
        this.categories = this.categories.data;

      }, error => console.error(error));

    }
    else {
      alert("Bạn đang ở trang đầu tiên");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.category = {
        categoryId: 1,
        categoryName: ""
      }
    }
    else {
      this.isEdit = true;
      this.category = index;
    }
    //mở popup bằng jquery
    $('#exampleModal').modal("show");
  }
  // Tajo hàm để làm nút add
  addCategory() {
    var x = this.category;
    this.http.post('https://localhost:44355/api/Categories/create-categories', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.category = res.data;
        console.log(res.data);
        this.isEdit = false;
        this.searchCategory(1);
        alert("New category have been added successfully!");
      }
    }, error => console.error(error));
  }

  // Tạo hàm làm nút save
  updateCategory() {
    var x = this.category;
    this.http.post('https://localhost:44355/api/Categories/update-categories', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.category = res.data;
        console.log(res.data);
        this.isEdit = true;
        this.searchCategory(1);
        alert("New category have been saved successfully!");
      }
    }, error => console.error(error));
  }
  deleteCategory(p) 
  {
    var r = confirm("Are you sure to delete this category")
    if(r == true) {
      // this.product = this.products.data[p];
      // var x = this.product;
      this.http.post('https://localhost:44355/api/Categories/delete-categories', p).subscribe(result => {
        var res : any = result;
        if(res.success) {
          this.searchCategory(1);
          alert("Category has been deleted successfully");
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
