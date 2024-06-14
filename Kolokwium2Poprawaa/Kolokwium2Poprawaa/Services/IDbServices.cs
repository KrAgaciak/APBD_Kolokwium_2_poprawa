using Kolokwium2Poprawaa.Models;

namespace Kolokwium2Poprawaa.Services;

public interface IDbServices
{
    public Task<ICollection<Character>> GetCharacterData(int characterId);
    public Task<bool> DoesCharacterExist(int clientID);
    public Task<bool> DoesItemExist(int itemID);
    public Task<bool> EnoughWeightCapacity(int itemID, int characterId);
    public Task AddNewItem(int itemID, int characterID);
    public Task<Item?> GetItemById(int characterID);


}