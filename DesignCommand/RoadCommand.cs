﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    class RoadCommand : BaseCommand
    {
        int downDifficulty;
        int upDifficulty;
        int leftDifficulty;
        int rightDifficulty;
        bool isAbleCross;
        public RoadCommand(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Execute(ElecMap elc)
        {
            downDifficulty = elc.mapnode[X, Y].DownDifficulty;
            upDifficulty = elc.mapnode[X, Y].UpDifficulty;
            leftDifficulty = elc.mapnode[X, Y].LeftDifficulty;
            rightDifficulty = elc.mapnode[X, Y].RightDifficulty;
            isAbleCross = elc.mapnode[X, Y].IsAbleCross;

            elc.mapnode[X, Y].IsAbleCross = true;
            elc.mapnode[X, Y].DownDifficulty = MapNode.DEFAULT_DIFFICULTY;
            elc.mapnode[X, Y].UpDifficulty = MapNode.DEFAULT_DIFFICULTY;
            elc.mapnode[X, Y].RightDifficulty = MapNode.DEFAULT_DIFFICULTY;
            elc.mapnode[X, Y].LeftDifficulty = MapNode.DEFAULT_DIFFICULTY;
        }

        public override void Undo(ElecMap elc)
        {
            elc.mapnode[X, Y].IsAbleCross = isAbleCross;
            elc.mapnode[X, Y].DownDifficulty = downDifficulty; 
            elc.mapnode[X, Y].UpDifficulty = upDifficulty;
            elc.mapnode[X, Y].RightDifficulty = rightDifficulty;
            elc.mapnode[X, Y].LeftDifficulty = leftDifficulty;
        }
    }
}
