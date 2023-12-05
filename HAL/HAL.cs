using SOPlabNEW.Models;
using System.ComponentModel;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SOPlabNEW.HALR {
    public static class HAL {
        public static dynamic ToResource(this Library lib) {
            var resource = lib.ToDynamic();
            resource._links = new {
                self = new { href = $"/api/lib/{lib.Id}" },
                //books = new { href = $"/api/book/{lib.Books}" },
                
            };
            return resource;
        }

        public static dynamic ToResource(this Book book) {
            var resource = book.ToDynamic();
            resource._links = new {
                self = new { href = $"/api/book/{book.Id}" },
                holders = new { href = $"/api/user/GetBookHoldersById{book.Id}" },
                libraries = new { href = $"/api/user/GetAvailableLibByBookId{book.Id}" }
            };
            return resource;
        }

        public static dynamic ToResource(this User user) {
            var resource = user.ToDynamic();
            resource._links = new {
                self = new { href = $"/api/user/{user.Id}" },
                takenBooks = new { href = $"/api/book/GetTakenBooksById/{user.Id}" }
            };
            return resource;
        }

        public static dynamic ToDynamic(this object value) {
            var result = new ExpandoObject();
            var properties = TypeDescriptor.GetProperties(value.GetType());
            foreach (PropertyDescriptor property in properties) {
                if (!Ignore(property))
                    result.TryAdd(property.Name, property.GetValue(value));
            }
            return result;
        }
        private static bool Ignore(this PropertyDescriptor property) {
            return property.Attributes.OfType<JsonIgnoreAttribute>().Any();
        }

        public static dynamic Paginate(string baseUrl, int index, int count, int total) {
            dynamic links = new ExpandoObject();
            links.self = new { href = baseUrl };
            if (index + count < total) {
                links.final = new { href = $"{baseUrl}?index={total - (total % count)}&count={count}" };
                links.next = new { href = $"{baseUrl}?index={index + count}" };
            }
            if (index > 0) {
                links.first = new { href = $"{baseUrl}?index=0" };
                links.prev = new { href = $"{baseUrl}?index={index - count}" };
            }
            return links;
        }

    }
}
