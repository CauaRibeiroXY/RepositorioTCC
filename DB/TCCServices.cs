using Microsoft.EntityFrameworkCore;
namespace TccDB;

public class TccServices
{
    private readonly TCCDbContext _dbContext;

    public TccServices(TCCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarTccAsync(Tcc tcc)
    {
        _dbContext.Tccs.Add(tcc);
        await _dbContext.SaveChangesAsync();
    }

    // Método para obter todos os registros de Tccs
    public async Task<List<Tcc>> GetTccsAsync()
    {
        return await _dbContext.Tccs.ToListAsync();
    }
    public async Task<List<Tcc>> GetTccsAsync(string searchText)
{
    var query = _dbContext.Tccs.AsQueryable();
    if (!string.IsNullOrEmpty(searchText))
    {
        var searchTextUpper = searchText.ToUpper();

        query = query.Where(tcc =>
            tcc.Titulo.ToUpper().Contains(searchTextUpper) ||
            tcc.Ano.ToString().ToUpper().Contains(searchTextUpper));
    }

    return await query.ToListAsync();
}
    public async Task<Tcc> GetTccPorIdAsync(int id)
    {
        return await _dbContext.Tccs.FindAsync(id);
    }

    // Método para adicionar um novo Tcc
    public async Task AddTccAsync(Tcc tcc)
    {
        _dbContext.Tccs.Add(tcc);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AtualizarTccAsync(Tcc tcc)
    {
        _dbContext.Entry(tcc).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task ExcluirTccAsync(int id)
    {
        var tcc = await _dbContext.Tccs.FindAsync(id);

        if (tcc != null)
        {
            _dbContext.Tccs.Remove(tcc);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("TCC não encontrado", nameof(id));
        }
    }
    // Outros métodos conforme necessário, como obter um Tcc por ID, atualizar, excluir, etc.
}

