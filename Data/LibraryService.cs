using Microsoft.EntityFrameworkCore;
using SOPlabNEW.Models;

namespace SOPlabNEW.Data {
    public class LibraryService : ILibraryContext {
        private readonly LibraryContext _context;
        public LibraryService(LibraryContext context) {
            _context = context;
        }
        public int CountBooks() => _context.Books.Count();

        public int CountLibraries() => _context.Libraries.Count();


        public int CountUsers() => _context.Users.Count();

        public void CreateBook(Book book) {
            _context.Add(book);
            _context.SaveChanges();
        }

        public void CreateLibrary(Library library) {
            _context.Add(library);
            _context.SaveChanges();
        }

        public void CreateUser(User user) {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void DeleteLibrary(Library library) {
            _context.Remove(library);
            _context.SaveChanges();
        }

        public void DeleteUser(User user) {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public ICollection<Library> GetLibraries() => _context.Libraries.ToList();

        public ICollection<Book> GetAvailableLibraryBooks(int libId) {       
            return _context.Books.Where(b => b.Library.Id == libId && b.BookHolder == null).ToList();
        }

        public Book GetBookById(int bookId) => _context.Books.Find(bookId);
        

        public User GetBookHolderById(int bookId) => _context.Users.Find(bookId);


        public ICollection<Book> GetBooks() => _context.Books.ToList();

        public ICollection<Book> GetBooks(int index, int count) => _context.Books.Skip(index).Take(count).ToList();

        public ICollection<Library> GetLibraries(int index, int count) => _context.Libraries.Skip(index).Take(count).ToList();

        public ICollection<Book> GetLibraryBooks(int libId) {
            return _context.Books.Where(b => b.Library.Id == libId).ToList();
        }

        public Library GetLibraryById(int libraryId) => _context.Libraries.Where(u => u.Id == libraryId).FirstOrDefault();

        public ICollection<Library> GetLibsByBookTitle(string title) => _context.Libraries.Where(u => u.Books.Any(b => b.BookTitle == title)).ToList();

        public ICollection<Book> GetTakenBooks() {
            return _context.Books.Where(b => b.BookHolder != null).ToList();
        }

        public ICollection<Book> GetTakenBooksById(int userId) {
            return _context.Books.Where(b => b.BookHolder.Id == userId).ToList();
        }

        public User GetUserById(int userId) => _context.Users.Where(u => u.Id == userId).FirstOrDefault();

        public ICollection<User> GetUsers() => _context.Users.ToList();

        public ICollection<User> GetUsers(int index, int count) => _context.Users.Skip(index).Take(count).ToList();

        public void UpdateBook(Book book) {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void UpdateLibrary(Library library) {
            _context.Libraries.Update(library);
            _context.SaveChanges();
        }

        public void UpdateUser(User user) {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

       
    }
}
