using System.ComponentModel.DataAnnotations;

namespace Kolokwium2Poprawaa.DTOs;

public class NewBackpackDTO
{
    [Required]
    public int ammount { get; set; }
    [Required]
    public int itemId { get; set; }
    [Required]
    public int characterId  { get; set; }
}