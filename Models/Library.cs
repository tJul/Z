using System.Text.Json.Serialization;

namespace SOPlabNEW.Models {
    public class Library {
        public Library() {            
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string LibraryName { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
