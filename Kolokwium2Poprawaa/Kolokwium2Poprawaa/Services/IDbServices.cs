using Kolokwium2Poprawaa.Models;

namespace Kolokwium2Poprawaa.Services;

public interface IDbServices
{
    public Task<ICollection<Character>> GetCharacterData(int characterId);
    public Task<bool> DoesCharacterExist(int clientID);

}