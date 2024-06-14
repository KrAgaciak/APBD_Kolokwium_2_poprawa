using System.ComponentModel.DataAnnotations;

namespace Kolokwium2Poprawaa.Models;

public class Item
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public String Name { get; set; }
    public int Weight { get; set; }

    public ICollection<Backpack> Backpack { get; set; } = new HashSet<Backpack>();

}