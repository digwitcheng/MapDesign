using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    class ObserveCommand : BaseCommand
    {
        public ObserveCommand(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Execute(ElecMap elc)
        {
            elc.mapnode[X, Y].IsAbleCross = false;
        }

        public override void Undo(ElecMap elc)
        {
            elc.mapnode[X, Y].IsAbleCross = true;
        }
    }
}
