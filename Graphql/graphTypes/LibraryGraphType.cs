using GraphQL.Types;
using SOPlabNEW.Models;

namespace SOPlabNEW.Graphql.graphTypes {
    public class LibraryGraphType : ObjectGraphType<Library> {

        public LibraryGraphType() {
            Name = "Library";
            Field(u => u.Address);
            Field(u => u.LibraryName);

        }
    }
}
