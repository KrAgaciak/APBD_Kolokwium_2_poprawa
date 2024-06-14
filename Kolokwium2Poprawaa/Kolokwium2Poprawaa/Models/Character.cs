using System.ComponentModel.DataAnnotations;

namespace Kolokwium2Poprawaa.Models;

public class Character
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public String FirstName { get; set; }
    [MaxLength(120)]
    public String LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    public ICollection<Backpack> Backpack { get; set; } = new HashSet<Backpack>();
    public ICollection<Character_Titles> Character_Titles { get; set; } = new HashSet<Character_Titles>();
}