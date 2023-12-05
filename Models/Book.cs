using System.Text.Json.Serialization;

namespace SOPlabNEW.Models {
    public class Book {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public int? BookHolderId { get; set; }
        [JsonIgnore]

        public User BookHolder { get; set; }
        public int LibraryId { get; set; }

        [JsonIgnore]
        public Library Library { get; set; }
    }
}
