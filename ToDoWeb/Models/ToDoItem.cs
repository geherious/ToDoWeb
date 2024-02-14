using System.ComponentModel.DataAnnotations;

namespace ToDoWeb.Models
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string? Description { get; set; }
        public DateTime Created { get; set; }

    }
}
