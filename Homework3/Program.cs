using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
    {
        public class Book
        {
            public string Title { get; set; }
            public Author Author { get; set; }
            public Category Category { get; set; }
            public int Year { get; set; }

            public Book(string title, Author author, Category category, int year)
            {
                Title = title;
                Author = author;
                Category = category;
                Year = year;
            }
        }

        public class Author
        {
            public string Name { get; set; }
            public string Biography { get; set; }

            public Author(string name, string biography)
            {
                Name = name;
                Biography = biography;
            }
        }

        public sealed class Category
        {
            public string CategoryName { get; set; }
            public string Description { get; set; }

            public Category(string categoryName, string description)
            {
                CategoryName = categoryName;
                Description = description;
            }
        }

        public static class LibraryManager
        {
            private static List<Book> books = new List<Book>();

            // adding books
            public static void AddBook(Book book)
            {
                books.Add(book);
            }

            //removing books
            public static void RemoveBook(string title)
            {
                books.RemoveAll(book => book.Title == title);
            }

            //listing all the books
            public static void ListAllBooks()
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Name}, Category: {book.Category.CategoryName}, Year: {book.Year}");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. Remove Book");
                    Console.WriteLine("3. List All Books");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddBook();
                            break;
                        case 2:
                            RemoveBook();
                            break;
                        case 3:
                            ListAllBooks();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }

            static void AddBook()
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter Author Name: ");
                string authorName = Console.ReadLine();
                Console.Write("Enter Author Biography: ");
                string authorBio = Console.ReadLine();
                Console.Write("Enter Category Name: ");
                string categoryName = Console.ReadLine();
                Console.Write("Enter Category Description: ");
                string categoryDesc = Console.ReadLine();
                Console.Write("Enter Year: ");
                int year = int.Parse(Console.ReadLine());

                Author author = new Author(authorName, authorBio);
                Category category = new Category(categoryName, categoryDesc);
                Book book = new Book(title, author, category, year);

                LibraryManager.AddBook(book);
                Console.WriteLine("Book added successfully!");
            }

            static void RemoveBook()
            {
                Console.Write("Enter Title of the book to remove: ");
                string title = Console.ReadLine();

                LibraryManager.RemoveBook(title);
                Console.WriteLine("Book removed successfully!");
            }

            static void ListAllBooks()
            {
                Console.WriteLine("List of all books:");
                LibraryManager.ListAllBooks();
            }
        }
    }
