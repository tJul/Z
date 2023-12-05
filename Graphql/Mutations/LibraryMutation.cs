using GraphQL;
using GraphQL.Types;
using SOPlabNEW.Data;
using SOPlabNEW.Graphql.graphTypes;
using SOPlabNEW.Models;

namespace SOPlabNEW.Graphql.Mutations {
    public class LibraryMutation : ObjectGraphType {
        private readonly ILibraryContext _db;

        [Obsolete]
        public LibraryMutation(ILibraryContext db) {
            _db = db;

            Field<BookGraphType>("createBook", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "BookTitle" },                                     
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "BookHolderId" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "LibraryId" }
                ),
                resolve: context => {

                    var title = context.GetArgument<string>("BookTitle");
                    var libraryId = context.GetArgument<int>("LibraryId");
                    var bookHolderId = context.GetArgument<int>("BookHolderId");

                    var library = db.GetLibraryById(libraryId);
                    var bookHolder = db.GetBookHolderById(bookHolderId);
                    var book = new Book() {

                       BookTitle = title,
                       LibraryId = libraryId,
                       BookHolderId = bookHolderId, 
                       Library = library,
                       BookHolder= bookHolder,
                    };
                    _db.CreateBook(book);
                    return book;
                }
                );
            Field<UserGraphType>("createUser", arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "FirstName" },
                     new QueryArgument<StringGraphType> { Name = "MiddleName" },
                     new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "LastName" }               
                 ),

                 resolve: context => {
                     var firstname = context.GetArgument<string>("FirstName");
                     var middlename = context.GetArgument<string>("MiddleName");
                     var lastname = context.GetArgument<string>("LastName");

                     var user = new User() {
                         FirstName = firstname,
                         MiddleName = middlename,
                         LastName = lastname
                     };

                     _db.CreateUser(user);
                     return user;
                 }
                 );
            Field<LibraryGraphType>("createLibrary", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "LibraryName" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Address" }
                    
                ),
                resolve: context => {

                    var name = context.GetArgument<string>("LibraryName");
                    var address = context.GetArgument<string>("Address");
                    
                    var lib = new Library() {
                        LibraryName = name,
                        Address = address
                       
                    };
                    _db.CreateLibrary(lib);
                    return lib;
                }
                );


            Field<BookGraphType>("deleteLibrary", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "libraryId" }
                ),
                 resolve: context => {
                     var libraryId = context.GetArgument<int>("libraryId");
                     var library = db.GetLibraryById(libraryId);
                     db.DeleteLibrary(library);
                     
                     return library;
                 }
                );


        }
    }
}
