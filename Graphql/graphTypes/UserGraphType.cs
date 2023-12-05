using SOPlabNEW.Models;
using System.Xml.Linq;
using GraphQL.Types;

namespace SOPlabNEW.Graphql.graphTypes {
    public class UserGraphType : ObjectGraphType<User> {
        public UserGraphType() {
            Name = "user";
            Field(u => u.FirstName);
            Field(u => u.LastName);
            Field(u => u.MiddleName);
        }
    }
}
