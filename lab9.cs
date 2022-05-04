using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            AppContext context = new AppContext();
            context.Database.EnsureCreated();
            IQueryable<Book> books = from book in context.Books
                                     where book.EditionYear > 2019
                                     select book;
            Console.WriteLine(string.Join("\n", books));

            var list = from book in context.Books
                       join author in context.Authors
                       on book.EditionYear > 2019
                       select new { BookAuthor = author.Name, Title = book.Title }; //obiekt klasy anonimowej
            Console.WriteLine(string.Join("\n", list));
            foreach(var item in list)
            {
                Console.WriteLine(item.BookAuthor);
            }
            list = context.Authors.Join(
                context.Books.Where(books=))


                string xml = "<books>" +
             "<book>" + "<book" +
             "" +
             "" +
             ">"
             XDocument doc = XDocument.Parse(xml);
            doc.Elements("book")
        }
    }

    WebClient client = new WebClient();
    client.Headers.Add("Accept, application/xml");
        client.DownloadString(http://api.nbp.pl/api/exchangerates/tables/b/2016-03-30/)
        Console.WriteLine(xml);
        //Przetwórz xml na listę (IEnumerable) obiektów z polami Code, Bid i Ask
        WebClient
        xDocument = 

        
    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int EditionYear { get; set; }
        public int AuthorId { get; set; }

        public record Author
        {
            public int Id { get; set; }
            public string Name;
        }
    }
    public class DatabaseContext : DbContext
    {
        public DbSet<Bok> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DATASOURCE=C:\\ondrive\\OneDrive - Wyższa Szkoła Ekonomii i Informatyki w Krakowie\\WSEI - obiektówka\\database\\sqlbase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Book>()
                .ToTable("books")
                .HasData(
              new Book() {Id = 1 , AuthorId = 1, EditionYear = 2020, Title = "c#" },
              new Book() {Id = 2 , AuthorId = 1 , EditionYear 2021, Title = "ASP.NET" }.,
              new Book() {Id = 2 , AuthorId = 2 , EditionYear 2014, Title = "ASP.NET" }.,
              new Book() {Id = 2 , AuthorId = 3 , EditionYear 2017, Title = "ASP.NET" }.,
        }


    }
