using Microsoft.EntityFrameworkCore;
using RepositorioTCC.Data;

namespace TccDB;
public class TCCDbContext : DbContext
{
    public TCCDbContext(DbContextOptions<TCCDbContext> options) : base(options)
    {
    }

    #region Propriedades
    public DbSet<Tcc> Sala { get; set; }
    public DbSet<User> User { get; set; }
    #endregion

    public DbSet<Tcc> Tccs { get; set; } // Adicione esta linha para representar a entidade Tcc no banco de dados

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais podem ser adicionadas aqui, se necessário
        modelBuilder.Entity<Tcc>().HasKey(t => t.Id);
        // Outras configurações de entidade podem ser adicionadas conforme necessário
    }
}
