using Application.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Interfaces
{
    public interface IDatabaseFactory:IDisposable
    {
        AppContext Get();
    }
}
