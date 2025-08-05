using System.ComponentModel.DataAnnotations;

namespace CQRS.BlazorUI.Models;

public class TodoItem
{
    [Required(ErrorMessage = "Todo is required.")]
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
}