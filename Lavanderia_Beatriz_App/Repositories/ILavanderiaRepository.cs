using Lavanderia_Beatriz_App.Models;

namespace Lavanderia_Beatriz_App.Repositories
{
    public interface ILavanderiaRepository
    {
        List<EncargadosRecep> GetEncPorPuesto(int estado);
        List<EncargadosRecep> GetEncargados();
        bool Post(EncargadosRecep encargado);
        bool Put(int id);
        bool Delete(int id);
        bool Put_Alias(int id, string alias, DateTime fechaNac);
        object GetClientes();
        object Post(Cliente cliente);
        object Put(Cliente cliente);
        object PutNombre(int id, string nombre);
        object Get_Acolchados();
        object Post(Acolchado acolchado);
        bool Put(int id, decimal precio);
    }
}
