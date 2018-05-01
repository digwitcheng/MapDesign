using AGV_V1._0.Agv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    internal abstract class BaseCommand : ICommand
    {
        public int X { get;  set; }
        public int Y { get;  set; }
        public Direction Dir { get; set; }

        public abstract void Execute(ElecMap elc);
        public abstract void Undo(ElecMap elc);
    }
}
