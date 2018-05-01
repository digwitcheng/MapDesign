using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    interface ICommand
    {
        void Execute(ElecMap elc);
        void Undo(ElecMap elc);
    }
}
