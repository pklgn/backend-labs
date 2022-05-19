using System;
using System.Collections.Generic;
using System.Linq;
using ScrumBoard;

namespace ScrumBoardConsole
{
	class Program
	{
		private static List<Board> _boards = new List<Board>();
		private static int _activeBoardIndex = -1;

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
            ProgramCommand command = ProgramCommand.Skip;
            while (command != ProgramCommand.Exit)
            {
                command = ReadCommand();
                ProcessCommand(command);
            }
            return;
		}

		private static ProgramCommand ReadCommand()
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

		private static void CreateBoard()
		{
            _activeBoardIndex = _boards.Count();
            _boards.Add(new Board(ReadConsoleParam("Please, specify the name of your board: ")));
            Console.WriteLine("Board was successfully created");

            return;
		}

		private static void CreateColumn()
		{
            if (_boards.Count() == 0)
            {
                Console.WriteLine("There is no boards");
                CreateBoard();
            }
            if (_boards[_activeBoardIndex].AppendColumn(new BoardColumn(ReadConsoleParam("Enter column name: "))))
            {
                Console.WriteLine("Column was added");

                return;
            }
            Console.WriteLine("Cannot create new column due to column limit");

            return;
		}

		private static string ReadConsoleParam(string prompt)
		{
			string param;
			do
			{
				Console.WriteLine(prompt);

				param = Console.ReadLine().Trim();
			} while (param.Length == 0);

			return param;
		}

		private static void RenameColumn()
		{
			string oldColumnName = ReadConsoleParam("Select column by old name: ");
			string newColumnName = ReadConsoleParam("Enter new column name: ");
			if (!_boards[_activeBoardIndex].RenameColumn(oldColumnName, newColumnName))
			{
				Console.WriteLine("Cannot rename column ", oldColumnName, " in current board");

				return;
			}

			Console.WriteLine("Successfully renamed");

			return;
		}

		private static void RemoveColumn()
        {
            string name = ReadConsoleParam("Enter column name that you'd like to remove: ");
            BoardColumn boardColumn = _boards[_activeBoardIndex].GetBoardColumns().Find(column => column.Title == name);

            if (!_boards[_activeBoardIndex].GetBoardColumns().Remove(boardColumn))
            {
                Console.WriteLine("Column was uccessfuly removed");

                return;
            }
            Console.WriteLine("Cannot remove ", name, " from current board");

            return;
        }

        private static void AddCard()
        {
            string columnName = ReadConsoleParam("Enter column name where you'd like to place your card: ");
            string cardName = ReadConsoleParam("Now enter card name: ");
            string cardDescription = ReadConsoleParam("Also enter card description: ");
            string cardPriority = ReadConsoleParam("And specify card priority (not important/minor/common/major):");
            BoardCard.PriorityType priority = BoardCard.GetPriorityTypeFromString(cardPriority);

            BoardColumn boardColumn = _boards[_activeBoardIndex].GetBoardColumns().Find(column => column.Title == columnName);
            if (boardColumn.Title == "")
            {
                Console.WriteLine("Cannot find specified board column");

                return;
            }

            boardColumn.AppendCard(new BoardCard(cardName, cardDescription, priority));
            Console.WriteLine("Card was successfully added");

            return;
        }

        private static void RemoveCard()
        {
            string columnName = ReadConsoleParam("Enter column name where the card was placed: ");
            string cardName = ReadConsoleParam("Now enter card name: ");

            BoardColumn boardColumn = _boards[_activeBoardIndex].GetBoardColumns().Find(column => column.Title == columnName);
            if (boardColumn.Title == "")
            {
                Console.WriteLine("Cannot find specified board column");

                return;
            }

            if (!boardColumn.RemoveCard(cardName))
            {
                Console.WriteLine("Cannot find specified card in column");

                return;
            }
            Console.WriteLine("Successfully removed");

            return;
        }

        private static void PrintBoard()
        {
            if (_boards.Count() == 0)
            {
                Console.WriteLine("There is no board to print");

                return;
            }
            Console.WriteLine(_boards[_activeBoardIndex].Title);
            List<BoardColumn> columns = _boards[_activeBoardIndex].GetBoardColumns();
            if (columns.Count() == 0)
            {
                Console.WriteLine("There is no columns in ", _boards[_activeBoardIndex].Title, " board");
            }
            foreach (BoardColumn column in columns)
            {
                PrintColumn(column);
            }
        }

        private static void PrintColumn(BoardColumn column)
        {
            Console.WriteLine($"================== {column.Title} ==================");
            foreach (BoardCard card in column.GetBoardCards())
            {
                PrintCard(card);
            }

            return;
        }

        private static void PrintCard(BoardCard card)
        {
            Console.WriteLine("Name: ", card.Name);
            Console.WriteLine("Description: ", card.Description);
            Console.WriteLine("Priority: ", BoardCard.GetPriorityTypeToString(card.Priority));

            return;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("help");

            return;
        }

        private static void ProcessCommand(ProgramCommand command)
        {
            switch (command)
            {
                case ProgramCommand.CreateBoard:
                    CreateBoard();
                    break;
                case ProgramCommand.AddCard:
                    AddCard();
                    break;
                case ProgramCommand.CreateColumn:
                    CreateColumn();
                    break;
                case ProgramCommand.Exit:
                    break;
                case ProgramCommand.Help:
                    PrintHelp();
                    break;
                case ProgramCommand.PrintBoard:
                    PrintBoard();
                    break;
                case ProgramCommand.RemoveCard:
                    RemoveCard();
                    break;
                case ProgramCommand.RemoveColumn:
                    RemoveColumn();
                    break;
                case ProgramCommand.RenameColumn:
                    RemoveColumn();
                    break;
                case ProgramCommand.Skip:
                    break;
            }

            return;
        }
    }
}
