using System.ComponentModel.DataAnnotations;

namespace PracticeTest.Entities
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string genre { get; set; }

        public int ISBN { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
