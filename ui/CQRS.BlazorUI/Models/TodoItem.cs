using System.ComponentModel.DataAnnotations;

namespace CQRS.BlazorUI.Models;

public class TodoItem
{
    public int Id { get; set; }
    [Required(ErrorMessage = "To-do is required.")]
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
}