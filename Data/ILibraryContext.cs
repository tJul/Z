using SOPlabNEW.Models;

namespace SOPlabNEW.Data {
    public interface ILibraryContext {
        int CountBooks();
        int CountUsers();
        int CountLibraries();
        ICollection<Book> GetBooks();
        ICollection<Book> GetBooks(int index, int count);
        ICollection<User> GetUsers();
        ICollection<User> GetUsers(int index, int count);

        ICollection<Library> GetLibraries();
        ICollection<Library> GetLibraries(int index, int count);    
        ICollection<Book> GetTakenBooks(); 
        ICollection<Book> GetTakenBooksById(int userId);     
        
        ICollection<Library> GetLibsByBookTitle(string title);
        ICollection<Book> GetLibraryBooks(int libId);
        ICollection<Book> GetAvailableLibraryBooks(int libId);

        Book GetBookById(int bookId);
        Library GetLibraryById(int libraryId);  
        User GetUserById(int userId);
        User GetBookHolderById(int bookId);
        void CreateBook(Book book);
        void UpdateBook(Book book);

        
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        
        void CreateLibrary(Library library);
        void UpdateLibrary(Library library);
        void DeleteLibrary(Library library);


    }
}
