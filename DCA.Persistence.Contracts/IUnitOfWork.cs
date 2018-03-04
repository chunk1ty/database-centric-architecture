using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DCA.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
