using AGV_V1._0.Agv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    class AddDireCommand :BaseCommand
    {
        int downDifficulty;
        int upDifficulty;
        int leftDifficulty;
        int rightDifficulty;

        public AddDireCommand(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Execute(ElecMap elc)
        {
           if( elc.mapnode[X, Y].IsAbleCross ==false)
            {
                return;
            }
            downDifficulty = elc.mapnode[X, Y].DownDifficulty;
            upDifficulty = elc.mapnode[X, Y].UpDifficulty;
            leftDifficulty = elc.mapnode[X, Y].LeftDifficulty;
            rightDifficulty = elc.mapnode[X, Y].RightDifficulty;
            switch (Dir)
            {
               case Direction.Down:elc.mapnode[X, Y].DownDifficulty = MapNode.DEFAULT_DIFFICULTY;
                    break;
                case Direction.Up:
                    elc.mapnode[X, Y].UpDifficulty = MapNode.DEFAULT_DIFFICULTY;
                    break;
                case Direction.Right:
                    elc.mapnode[X, Y].RightDifficulty = MapNode.DEFAULT_DIFFICULTY;
                    break;
                case Direction.Left:
                    elc.mapnode[X, Y].LeftDifficulty = MapNode.DEFAULT_DIFFICULTY;
                    break;
                default:break;
            }
        }

        public override void Undo(ElecMap elc)
        {
            if (elc.mapnode[X, Y].IsAbleCross == false)
            {
                return;
            }
            switch (Dir)
            {
                case Direction.Down:
                    elc.mapnode[X, Y].DownDifficulty = downDifficulty;
                    break;
                case Direction.Up:
                    elc.mapnode[X, Y].UpDifficulty = upDifficulty;
                    break;
                case Direction.Right:
                    elc.mapnode[X, Y].RightDifficulty = rightDifficulty;
                    break;
                case Direction.Left:
                    elc.mapnode[X, Y].LeftDifficulty = leftDifficulty;
                    break;
                default: break;
            }
        }
    }
}
