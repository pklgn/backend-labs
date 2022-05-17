using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumBoard;

namespace ScrumBoardConsole
{
	class Program
	{
		private enum ProgramCommand
		{
			CreateBoard,
			CreateColumn,
			RenameColumn,
			RemoveColumn,
			AddCard,
			RemoveCard,
			PrintBoard,
			Help,
			Skip,
			Exit,
		}


		static void Main(string[] args)
		{
		}

		private ProgramCommand ReadCommand()
		{
			string commandString = Console.ReadLine().Trim();

			if (commandString == "create_board")
			{
				return ProgramCommand.CreateBoard;
			}
			else if (commandString == "create_column")
			{
				return ProgramCommand.CreateColumn;
			}
			else if (commandString == "rename_column")
			{
				return ProgramCommand.RenameColumn;
			}
			else if (commandString == "remove_column")
			{
				return ProgramCommand.RemoveColumn;
			}
			else if (commandString == "add_card")
			{
				return ProgramCommand.AddCard;
			}
			else if (commandString == "remove_card")
			{
				return ProgramCommand.RemoveCard;
			}
			else if (commandString == "print_board")
			{
				return ProgramCommand.PrintBoard;
			}
			else if (commandString == "help")
			{
				return ProgramCommand.Help;
			}
			else if (commandString == "exit")
			{
				return ProgramCommand.Exit;
			}

			return ProgramCommand.Skip;
		}

		private Board CreateBoard()
        {
            Console.WriteLine("Please, specify the name of your board: ");

            string title = Console.ReadLine().Trim();
            return new Board("test");
        }

        private BoardColumn CreateBoardColumn(string name)
        {
            return new BoardColumn(name);
        }
	}
}
