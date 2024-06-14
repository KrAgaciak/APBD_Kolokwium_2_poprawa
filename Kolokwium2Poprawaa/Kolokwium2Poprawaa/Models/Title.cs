using System.ComponentModel.DataAnnotations;

namespace Kolokwium2Poprawaa.Models;

public class Title
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public String Name { get; set; }
    
    public ICollection<Character_Titles> Character_Titles { get; set; } = new HashSet<Character_Titles>();
}