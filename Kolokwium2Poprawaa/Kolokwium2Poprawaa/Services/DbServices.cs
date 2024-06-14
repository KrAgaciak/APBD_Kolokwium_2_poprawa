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
    
}