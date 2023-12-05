using GraphQL.Types;
using SOPlabNEW.Models;

namespace SOPlabNEW.Graphql.graphTypes {
    public sealed class BookGraphType : ObjectGraphType<Book> {

        public BookGraphType() {
            Name = "Book";
            Field(u => u.BookTitle);
            Field(u => u.LibraryId);
            Field(u => u.BookHolderId, nullable:true);
            Field(u => u.BookHolder, type: typeof(UserGraphType)).Description("Текущий читатель, взявший книгу");
            Field(u => u.Library, type: typeof(LibraryGraphType)).Description("Библиотека, владеющая данной книгой");
        }
    }
}
