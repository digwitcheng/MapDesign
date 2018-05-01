using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    class NoneCommand : BaseCommand
    {
        public NoneCommand(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        public override void Execute(ElecMap elc)
        {
        }

        public override void Undo(ElecMap elc)
        {
        }
    }
}
