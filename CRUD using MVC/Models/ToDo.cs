using System.ComponentModel.DataAnnotations;

namespace CRUD_using_MVC.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        [Required(ErrorMessage = "To Do name is required")]
        public string Name { get; set; }
        public bool IsFinished { get; set; }
        public string? Description { get; set; }
        public DateTime createdDate { get; set; }
    }
}
