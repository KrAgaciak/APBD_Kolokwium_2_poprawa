namespace Kolokwium2Poprawaa.DTOs;

public class GetCharacterInfoDTO
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<GetBackpackItemDTO> backpackItem { get; set; } = null!;
    public ICollection<GetTitlesDTO> titles { get; set; } = null!;
}

public class GetBackpackItemDTO
{
    public String itemName { get; set; }
    public int itemWeight { get; set; }
    public int ammount { get; set; }
}

public class GetTitlesDTO
{
    public String title { get; set; }
    public DateTime aquiredAt { get; set; }
}