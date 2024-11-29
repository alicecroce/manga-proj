using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manga_project.SeedWork
{
    public interface IInterviewer<T>
    {
        T Create();
        T Update();
    }
}
