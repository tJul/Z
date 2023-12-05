using System.Text.Json.Serialization;

namespace SOPlabNEW.Models {
    public class User {
        public User() {
            TakenBooks = new List<Book>();         
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [JsonIgnore]
        public ICollection<Book> TakenBooks { get; set; }
        
       
    }
}
