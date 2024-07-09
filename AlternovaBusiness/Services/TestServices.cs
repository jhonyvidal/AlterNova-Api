using AlternovaBusiness.DTOs;
using AlternovaBusiness.Interfaces;
using AlternovaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternovaBusiness.Services
{
    public class TestServices: ITest
    {
        private readonly AppDbContext _context;

        public TestServices(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TestEntitie> Get() => _context.Test.ToList();

        public TestEntitie Get(int id) => _context.Test.FirstOrDefault(d => d.Id == id);

        public TestEntitie Post(TestEntitie request)
        {
            _context.Test.Add(request);
            _context.SaveChanges();
            return request;
        }

        public void Delete(int id)
        {
            var itemToRemove = _context.Test.FirstOrDefault(d => d.Id == id);
            if (itemToRemove != null)
            {
                _context.Test.Remove(itemToRemove);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se encontró el elemento con el ID especificado.");
            }
        }

        public void Update(int id, TestEntitie request)
        {
            var itemToUpdate = _context.Test.FirstOrDefault(d => d.Id == id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Nombre = request.Nombre;
                itemToUpdate.Apellido = request.Apellido;
                itemToUpdate.Email = request.Email;
                itemToUpdate.Genero = request.Genero;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se encontró el elemento con el ID especificado.");
            }
        }
    }
}
