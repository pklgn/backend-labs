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
        private static int _padValue = 10;

		private enum ProgramCommand
		{
			CreateBoard,
			CreateColumn,
			RenameColumn,
			RemoveColumn,
			AddCard,
			RemoveCard,
			PrintBoard,
            SwitchBoard,
            MoveColumn,
			Help,
			Skip,
			Exit,
		}

        private static Dictionary<ProgramCommand, string> _commandName = new Dictionary<ProgramCommand, string>
        {
            { ProgramCommand.CreateBoard, "create_board" },
            { ProgramCommand.CreateColumn, "create_column" },
            { ProgramCommand.RenameColumn, "rename_column" },
            { ProgramCommand.RemoveColumn, "remove_column" },
            { ProgramCommand.AddCard, "add_card" },
            { ProgramCommand.RemoveCard, "remove_card" },
            { ProgramCommand.PrintBoard, "print_board" },
            { ProgramCommand.SwitchBoard, "switch_board" },
            { ProgramCommand.MoveColumn, "move_column" },
            { ProgramCommand.Help, "help" },
            { ProgramCommand.Exit, "exit" },
        };

        private static Dictionary<ProgramCommand, string> _commandDescription = new Dictionary<ProgramCommand, string>
        {
            { ProgramCommand.CreateBoard, "Create a new board and select it as current" },
            { ProgramCommand.CreateColumn, "Create a new column in the current board" },
            { ProgramCommand.RenameColumn, "Rename specified column. If specified column was not found do nothing" },
            { ProgramCommand.AddCard, "Add new card in specieifed column" },
            { ProgramCommand.RemoveCard, "Remove specified card. If specified column or card was not found do nothing" },
            { ProgramCommand.PrintBoard, "Print the current board" },
            { ProgramCommand.SwitchBoard, "Switch the current board" },
            { ProgramCommand.MoveColumn, "Change column position" },
            { ProgramCommand.Exit, "Type to exit program" },
        };



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

			if (commandString == _commandName[ProgramCommand.CreateBoard])
			{
				return ProgramCommand.CreateBoard;
			}
			else if (commandString == _commandName[ProgramCommand.CreateColumn])
			{
				return ProgramCommand.CreateColumn;
			}
			else if (commandString == _commandName[ProgramCommand.RenameColumn])
			{
				return ProgramCommand.RenameColumn;
			}
			else if (commandString == _commandName[ProgramCommand.RemoveColumn])
			{
				return ProgramCommand.RemoveColumn;
			}
			else if (commandString == _commandName[ProgramCommand.AddCard])
			{
				return ProgramCommand.AddCard;
			}
			else if (commandString == _commandName[ProgramCommand.RemoveCard])
			{
				return ProgramCommand.RemoveCard;
			}
			else if (commandString == _commandName[ProgramCommand.PrintBoard])
			{
				return ProgramCommand.PrintBoard;
			}
            else if (commandString == _commandName[ProgramCommand.SwitchBoard])
            {
                return ProgramCommand.SwitchBoard;
            }
            else if (commandString == _commandName[ProgramCommand.Help])
			{
				return ProgramCommand.Help;
			}
			else if (commandString == _commandName[ProgramCommand.Exit])
			{
				return ProgramCommand.Exit;
			}

			return ProgramCommand.Skip;
		}

		private static void CreateBoard()
		{
            _activeBoardIndex = _boards.Count();
            string boardName = ReadConsoleParam("Please, specify the name of your board: ");
            int boardIndex = _boards.FindIndex(board => board.Title == boardName);
            if (boardIndex != -1)
            {
                Console.WriteLine("Board with this title already exists");

                return;
            }
            _boards.Add(new Board(boardName));
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

		private static string ReadConsoleParam(string prompt, bool canSkip = false)
		{
			string param;
			do
			{
				Console.WriteLine(prompt);

				param = Console.ReadLine().Trim();
			} while (param.Length == 0 && !canSkip);

			return param;
		}

		private static void RenameColumn()
		{
            if (_boards.Count() == 0)
            {
                Console.WriteLine("There is no boards. Create board at first");

                return;
            }
            string oldColumnName = ReadConsoleParam("Select column by old name: ");
			string newColumnName = ReadConsoleParam("Enter new column name: ");
			if (!_boards[_activeBoardIndex].RenameColumn(oldColumnName, newColumnName))
			{
				Console.WriteLine($"Cannot rename column {oldColumnName} in current board");

                return;
			}

			Console.WriteLine("Successfully renamed");

			return;
		}

		private static void RemoveColumn()
        {
            if (_boards.Count() == 0)
            {
                Console.WriteLine("At first you should create board and column");

                return;
            }

            string columnName = ReadConsoleParam("Enter column name that you'd like to remove: ");

            if (!_boards[_activeBoardIndex].RemoveColumn(columnName))
            {
                Console.WriteLine("Column was uccessfuly removed");

                return;
            }
            Console.WriteLine($"Cannot remove ${columnName} from current board");

            return;
        }

        private static void AddCard()
        {
            if (_boards.Count() == 0)
            {
                Console.WriteLine("At first you should create board and column");
                CreateBoard();
                CreateColumn();
            }

            string columnName = ReadConsoleParam("Enter column name where you'd like to place your card: ");

            BoardColumn boardColumn = _boards[_activeBoardIndex].FindBoardColumn(columnName);
            if (boardColumn == null)
            {
                Console.WriteLine("Cannot find specified board column   ");

                return;
            }

            string cardName = ReadConsoleParam("Now enter card name: ");
            string cardDescription = ReadConsoleParam("Also enter card description: ", true);
            BoardCard.PriorityType priority;
            do
            {
                string cardPriority = ReadConsoleParam("And specify card priority (not important/minor/common/major):");
                priority = BoardCard.GetPriorityTypeFromString(cardPriority);
            } while (priority == BoardCard.PriorityType.NoPriority);

            boardColumn.AppendCard(new BoardCard(cardName, cardDescription, priority));
            Console.WriteLine("Card was successfully added");

            return;
        }

        private static void RemoveCard()
        {
            if (_boards.Count() == 0)
            {
                Console.WriteLine("At first you should create board");

                return;
            }

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
                Console.WriteLine($"There is no columns in {_boards[_activeBoardIndex].Title} board");
            }
            foreach (BoardColumn column in columns)
            {
                PrintColumn(column);
            }
        }

        private static void PrintColumn(BoardColumn column)
        {
            Console.WriteLine($"===== {column.Title} =====");
            if (column.GetBoardCards().Count == 0)
            {
                Console.WriteLine("There is no cards");

                return;
            }

            foreach (BoardCard card in column.GetBoardCards())
            {
                PrintCard(card);
            }

            return;
        }

        private static void PrintCard(BoardCard card)
        {
            Console.WriteLine($"Name:\t\t{card.Name}");
            Console.WriteLine($"Description:\t{card.Description}");
            Console.WriteLine($"Priority:\t{BoardCard.GetPriorityTypeToString(card.Priority)}");

            return;
        }

        private static void PrintHelp()
        {
            foreach (KeyValuePair<ProgramCommand, string> command in _commandDescription)
            {
                Console.WriteLine(_commandName[command.Key].PadRight(_padValue) + "\t\t" + command.Value);
            }

            return;
        }

        private static void PrintHint()
        {
            Console.WriteLine("Unknown command. Use help to see all available commands");

            return;
        }

        private static void SwitchBoard()
        {
            if (_boards.Count() == 0)
            {
                Console.WriteLine("There is no board to switch. Try to create board at first");

                return;
            }

            Console.WriteLine($"There is (are) {_boards.Count()} board(s)");
            foreach (Board board in _boards)
            {
                Console.WriteLine($"- {board.Title}");

            }

            string boardName = ReadConsoleParam("Enter one of these board title");
            int boardIndex = _boards.FindIndex(board => board.Title == boardName);

            if (boardIndex == -1)
            {
                Console.WriteLine("There is no such board");

                return;
            }

            _activeBoardIndex = boardIndex;
            Console.WriteLine($"Current board was successfully switched to {_boards[_activeBoardIndex].Title}");

            return;
        }

        private static void MoveColumn()
        {
            if (_boards[_activeBoardIndex].GetBoardColumns().Count == 0)
            {
                Console.WriteLine("There is no columns");

                return;
            }

            Console.WriteLine($"You can choose indexes from 0 to {_boards[_activeBoardIndex].GetBoardColumns().Count}");

            string columnName = ReadConsoleParam("Enter column name to move");


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
                    RenameColumn();
                    break;
                case ProgramCommand.SwitchBoard:
                    SwitchBoard();
                    break;
                case ProgramCommand.Skip:
                    PrintHint();
                    break;
            }

            return;
        }
    }
}
