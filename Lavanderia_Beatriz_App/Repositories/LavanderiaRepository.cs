using Lavanderia_Beatriz_App.Models;
using Lavanderia_Beatriz_App.Repositories.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data;

namespace Lavanderia_Beatriz_App.Repositories
{
    public class LavanderiaRepository : ILavanderiaRepository
    {
        private readonly LavanderiaContext _context;

        public LavanderiaRepository(LavanderiaContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var encargado = _context.EncargadosReceps.Find(id);
            if(encargado != null && encargado.Estado)
            {
                encargado.Estado = false;
            }  
            return _context.SaveChanges() > 0;
        }

        public List<EncargadosRecep> GetEncPorPuesto(int puesto)
        {
            return _context.EncargadosReceps
                .Where(e => e.IdPuesto == puesto).ToList();    
        }

        public List<EncargadosRecep> GetEncargados()
        {
            var result = _context.EncargadosReceps.Include(e => e.IdPuestoNavigation)
                .ToList();
            return result;
        }

        public bool Post(EncargadosRecep encargado)
        {
            encargado.Estado = true;
            _context.EncargadosReceps.Add(encargado);
            return _context.SaveChanges() > 0;
        }

        public bool Put(int id)
        {
            var encargado = _context.EncargadosReceps.Find(id);
            if(encargado.Estado && encargado != null && encargado.IdPuesto == 3)
            {
                encargado.IdPuesto = 2;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Put_Alias(int id, string alias, DateTime fechaNac)
        {
            var encargado = _context.EncargadosReceps.Find(id);
            if (encargado != null && encargado.Estado)
            {
                encargado.Alias = alias;
                encargado.FechaNacimiento = DateOnly.FromDateTime(fechaNac);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public object GetClientes()
        {
            var result = _context.Clientes
                .ToList();
            return result;
        }

        public object Post(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            return _context.SaveChanges() > 0;
        }

        public object Put(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return _context.SaveChanges() > 0;
        }

        public object PutNombre(int id, string nombre)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                cliente.Nombre = nombre;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public object Get_Acolchados()
        {
            var result = _context.Acolchados
                .ToList();
            return result;  
        }

        public object Post(Acolchado acolchado)
        {
            _context.Acolchados .Add(acolchado);
            return _context.SaveChanges() > 0;
        }

        public bool Put(int id, decimal precio)
        {
            var acolchado = _context.Acolchados.Find(id);
            if (acolchado != null)
            {
                acolchado.PrecioUnitario = precio;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
