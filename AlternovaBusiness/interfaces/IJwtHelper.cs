using AlternovaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternovaBusiness.interfaces
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(User user);
    }
}
