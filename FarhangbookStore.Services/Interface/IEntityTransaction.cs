using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface IEntityTransaction : IDisposable
    {
        void Commit();
        void RollBack();

        //void Dispose();
    }
}
