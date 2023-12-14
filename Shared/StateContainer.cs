using RepositorioTCC.Data;
namespace RepositorioTCC.Shared;
public class StateContainer
{

    public User? user { get; set; }
    public void AtualizaUser(User valor)
    {
        this.user = valor;
    }
}

