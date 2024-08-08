import { Component, OnInit } from '@angular/core';
import { Book } from '../../book';
import { CommonModule } from '@angular/common';
import { BookService } from '../book.service';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})

export class BookListComponent implements OnInit{

  books: Book[] = [] 

  constructor(private bookService: BookService){}

  ngOnInit() { //Lifecycle hook
      this.getBooks();
  }
  
  getBooks(): void{
    this.bookService.getBooks().subscribe(booksFromApi => this.books = booksFromApi);
  }
}
