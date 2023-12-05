using GraphQL.Types;
using SOPlabNEW.Data;
using SOPlabNEW.Graphql.Mutations;
using SOPlabNEW.Graphql.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SOPlabNEW.Graphql.Schemas {
    public class LibrarySchema : Schema {
        public LibrarySchema (ILibraryContext db){

            Query = new LibraryQuery(db);
            Mutation = new LibraryMutation(db);
        }
    }
}
