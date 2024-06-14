using Kolokwium2Poprawaa.Database;
using Kolokwium2Poprawaa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2Poprawaa.Services;

public class DbServices : IDbServices
{
    private readonly DatabaseContext _context;
    public DbServices(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Character>> GetCharacterData(int characterId)
    {
        return await _context.Character
            .Include(e => e.Backpack)
                .ThenInclude(i=> i.Item)
            .Include(e => e.Character_Titles)
                .ThenInclude(ct => ct.Title)
            .Where(e => characterId == null || e.ID == characterId)
            .ToListAsync();
    }

    public async Task<bool> DoesCharacterExist(int clientID)
    {
        return await _context.Character.AnyAsync(e => e.ID == clientID);
    }
    
    public async Task<bool> DoesItemExist(int itemID)
    {
        return await _context.Item.AnyAsync(e => e.ID == itemID);
    }
    
    public async Task<bool> EnoughWeightCapacity(int itemID, int characterId)
    {
        var item = await _context.Item.FirstAsync(e => e.ID == itemID);
        var character = await _context.Character.FirstAsync(c => c.ID == characterId);

        var itemWeight = item.Weight;
        var weightLeft = character.MaxWeight - character.CurrentWeight;

        if (itemWeight > weightLeft)
        {
            return true;
        }
        return false;
    }
    
    public async Task AddNewItem(int itemID, int characterID)
    {
        await _context.AddAsync(new Backpack{ItemId = itemID, CharacterId = characterID, Amount = 1});
        await _context.SaveChangesAsync();
    }
    
    public async Task<Item?> GetItemById(int characterID)
    {
        return await _context.Item.FirstOrDefaultAsync(e => e.ID == characterID);
    }
    
}