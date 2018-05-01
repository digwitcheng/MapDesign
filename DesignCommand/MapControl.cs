using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.DesignCommand
{
    class MapControl
    {
        ElecMap elc;
        Stack<List<BaseCommand>> doneCommand;
        Stack<List<BaseCommand>> undoCommand;
        public MapControl(ElecMap elc)
        {
            this.elc = elc;
            doneCommand = new Stack<List<BaseCommand>>();
            undoCommand = new Stack<List<BaseCommand>>();
        }

        public void ExcuteCommand(List<BaseCommand> commands)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Execute(elc);
            }
            doneCommand.Push(commands);
        }
        public List<BaseCommand> UndoCommand()
        {
            if (!doneCommand.Any())
            {
                return null;
            }
            List<BaseCommand> lastCommands = doneCommand.Pop();
            for (int i = 0; i < lastCommands.Count; i++)
            {
                lastCommands[i].Undo(elc);
            }
            undoCommand.Push(lastCommands);
            return lastCommands;
        }
        public List<BaseCommand> CancelUndoCommand()
        {
            if (!undoCommand.Any())
            {
                return null;
            }
            List<BaseCommand> lastCommands = undoCommand.Pop();
            ExcuteCommand(lastCommands);
            return lastCommands;
        }

    }
}
