using GraphQL.Types;
using GraphQL;
using SOPlabNEW.Data;
using SOPlabNEW.Graphql.graphTypes;
using System.Net;
using SOPlabNEW.Models;

namespace SOPlabNEW.Graphql.Queries {
    public class LibraryQuery : ObjectGraphType{
        private readonly ILibraryContext _db;

        [Obsolete]
        public LibraryQuery(ILibraryContext db) {
            _db = db;
            Field<ListGraphType<BookGraphType>>("Books", "Return all books", 
                resolve: GetAllBooks);

            Field<BookGraphType>("Book", "Return book by id",
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }), 
                resolve: GetBook);

            Field<ListGraphType<UserGraphType>>("Users", "Return all users", 
                resolve: GetAllUsers);

            Field<UserGraphType>("User", "Return user by id", 
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }), 
                resolve: GetUser);

            Field<ListGraphType<LibraryGraphType>>("Libraries", "Return all librariess",
                resolve: GetAllLibraries);

            Field<LibraryGraphType>("Library", "Return library by id",
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: GetLibrary);

            Field<ListGraphType<BookGraphType>>("Taken_Books", "Return all taken books",
               resolve: GetTakenBooks);

            Field<BookGraphType>("Taken_Books_Id", "Return taken books by user id",
               new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "userId" }),
               resolve: GetTakenBooksById);

            Field<LibraryGraphType>("Libraries_By_Book_Title", "Return libraries where there is a book with title",
               new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" }),
               resolve: GetLibsByBookTitle);

            Field<BookGraphType>("Library_Books", "Return books that are located in a library by id",
              new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "libId" }),
              resolve: GetLibraryBooks);

            Field<BookGraphType>("Available_Books", "Return books that are available in a library by id",
              new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "libId" }),
              resolve: GetAvailableLibraryBooks);
        }
        
        private ICollection<Book> GetAllBooks(IResolveFieldContext<object> context) => _db.GetBooks();
        private ICollection<User> GetAllUsers(IResolveFieldContext<object> context) => _db.GetUsers();
        private ICollection<Library> GetAllLibraries(IResolveFieldContext<object> context) => _db.GetLibraries();

        private Book GetBook(IResolveFieldContext<object> context) => _db.GetBookById(context.GetArgument<int>("id"));
        private User GetUser(IResolveFieldContext<object> context) => _db.GetUserById(context.GetArgument<int>("id"));
        private Library GetLibrary(IResolveFieldContext<object> context) => _db.GetLibraryById(context.GetArgument<int>("id"));
        private ICollection<Library> GetLibsByBookTitle(IResolveFieldContext<object> context) => _db.GetLibsByBookTitle(context.GetArgument<string>("title"));
        private ICollection<Book> GetTakenBooksById(IResolveFieldContext<object> context) => _db.GetTakenBooksById(context.GetArgument<int>("userId"));
        private ICollection<Book> GetTakenBooks(IResolveFieldContext<object> context) => _db.GetTakenBooks();
        private ICollection<Book> GetLibraryBooks(IResolveFieldContext<object> context) => _db.GetLibraryBooks(context.GetArgument<int>("libId"));
        private ICollection<Book> GetAvailableLibraryBooks(IResolveFieldContext<object> context) => _db.GetAvailableLibraryBooks(context.GetArgument<int>("libId"));
    }
    
}
