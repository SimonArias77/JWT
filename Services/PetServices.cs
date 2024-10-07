using Microsoft.EntityFrameworkCore;
using RepasoJWT.Data;
using RepasoJWT.Models;
using RepasoJWT.Repositories;

namespace RepasoJWT.Services;
public class PetServices : IPetRepository
{
    private readonly ApplicationDbContext _context;

    public PetServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckExistence(int id)
    {
        return await _context.Pets.AnyAsync(p => p.Id == id);
    }

    public async Task Delete(int id)
    {
        var pet = await GetById(id);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<IEnumerable<Pet>> GetAll()
    {
        return await _context.Pets.ToListAsync();
    }

    public async Task<Pet?> GetById(int id)
    {
        return await _context.Pets.FindAsync(id);
    }
}
