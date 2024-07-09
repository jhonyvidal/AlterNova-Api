using AlternovaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternovaBusiness.Interfaces
{
    public interface ITest
    {
        public IEnumerable<TestEntitie> Get();
        public TestEntitie Get(int id);
        public TestEntitie Post(TestEntitie request);
        public void Delete(int id);
        public void Update(int id, TestEntitie request);
    }
}
