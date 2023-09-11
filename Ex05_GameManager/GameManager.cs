namespace Ex05_GameManager
{
    using System;
    using Ex05_GameManager.Initialization;
    using Ex05_Boards;
    using Ex05_Players;
    using Ex05_Players.Enums;
    using Ex05_Boards.Enums;

    public class GameManager
    {
        private const int k_AmountOfCellsToFlipEachRound = 2;
        private const int k_smallLetterInAscii = 97;
        private const int k_numberInAscii = 49;
        private static eNumberedPlayers m_currentPlayer;
        private static PlayersInitializtion m_players;
        private static BoardInitializtion m_board;

        public GameManager()
        {
            initializeGame();
        }

        private void initializeGame()
        {
            m_players = new PlayersInitializtion();
            m_board = new BoardInitializtion();
            //startGameRounds();
        }

        #region Manage game rounds

        private void startGameRounds()
        {
            string input = string.Empty;

            while (true)
            {
                if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    input = manageRounds();
                }
            }
        }

        private string manageRounds()
        {
            string input;
            m_currentPlayer = eNumberedPlayers.FirstPlayer;
            int numOfFlips = 0;

            while (true)
            {
                if (numOfFlips == 1)
                {
                    //Ex02_View.Draw.DrawBoard(m_board.Board.Height, m_board.Board.Width, Cells.TempFlippedCells);
                }
                else
                {
                    //Ex02_View.Draw.DrawBoard(m_board.Board.Height, m_board.Board.Width, Cells.TempFlippedCells);
                    Cells.InitializeTempFlippedCells(m_board.Board.Height, m_board.Board.Width, 0, 0, true);
                    //Ex02_View.Draw.DrawBoard(m_board.Board.Height, m_board.Board.Width, Cells.FlippedCells);
                }

                showCurrentPlayer(m_players.PlayersList[(int)m_currentPlayer]);
                input = getCoordinateFromPlayer(m_players.PlayersList[(int)m_currentPlayer]);

                switch (input.Length)
                {
                    case 1:
                        input = checkIfQuit(input);
                        break;
                    case 2:
                        if (manageFlips(input, m_players.PlayersList[(int)m_currentPlayer], numOfFlips))
                        {
                            numOfFlips++;
                            numOfFlips = numOfFlips == k_AmountOfCellsToFlipEachRound ? 0 : numOfFlips;
                        }

                        break;
                    default:
                        Console.WriteLine("Invakid Input: can accept one charactor or two only!");
                        break;
                }

                if (input == "Q")
                {
                    break;
                }
            }

            return input;
        }

        private bool manageFlips(string i_Input, Player i_Player, int i_FlipNumber)
        {
            bool isValid = validateFlipInput(i_Input);

            if (isValid)
            {
                int rowToFlip = i_Input[(int)eBoardDimensionIndex.rowIndex] - k_numberInAscii;
                int columnToFlip = i_Input[(int)eBoardDimensionIndex.columnIndex] - k_smallLetterInAscii;
                Cells.InitializeTempFlippedCells(
                                                 m_board.Board.Height,
                                                 m_board.Board.Width,
                                                 rowToFlip,
                                                 columnToFlip,
                                                 false);

                if (i_FlipNumber != k_AmountOfCellsToFlipEachRound - 1)
                {
                    i_Player.FirstTempFlippedCellValue = Cells.CellsWithValues[rowToFlip, columnToFlip];
                    i_Player.FirstCellRowToFlip = rowToFlip;
                    i_Player.FirstCellColumnToFlip = columnToFlip;
                }
                else
                {
                    i_Player.SecondTempFlippedCellValue = Cells.CellsWithValues[rowToFlip, columnToFlip];
                    i_Player.SecondCellRowToFlip = rowToFlip;
                    i_Player.SecondCellColumnToFlip = columnToFlip;
                    if (i_Player.FirstTempFlippedCellValue == i_Player.SecondTempFlippedCellValue)
                    {
                        Cells.InitializeFlippedCells(
                                                     m_board.Board.Height,
                                                     m_board.Board.Width,
                                                     i_Player.FirstCellRowToFlip,
                                                     i_Player.FirstCellColumnToFlip,
                                                     i_Player.SecondCellRowToFlip,
                                                     i_Player.SecondCellColumnToFlip,
                                                     false);

                        i_Player.AmountOfPoints++;

                        if (Cells.IsAllFlipped(m_board.Board.Height, m_board.Board.Width))
                        {
                            setWinner();
                            Cells.InitializeFlippedCells(
                                                         m_board.Board.Height,
                                                         m_board.Board.Width,
                                                         0,
                                                         0,
                                                         0,
                                                         0,
                                                         true);
                            for (int i = 0; i < m_players.PlayersList.Count; i++)
                            {
                                m_players.PlayersList[i].AmountOfPoints = 0;
                            }

                            m_board = new BoardInitializtion();
                        }
                    }
                    else
                    {
                        m_currentPlayer = m_currentPlayer == eNumberedPlayers.FirstPlayer ?
                                                         eNumberedPlayers.SecondPlayer :
                                                         eNumberedPlayers.FirstPlayer;
                    }
                }
            }

            return isValid;
        }

        private void setWinner()
        {
            Player winner = m_players.PlayersList[(int)eNumberedPlayers.FirstPlayer].AmountOfPoints >
                            m_players.PlayersList[(int)eNumberedPlayers.SecondPlayer].AmountOfPoints ?
                            m_players.PlayersList[(int)eNumberedPlayers.FirstPlayer] :
                            m_players.PlayersList[(int)eNumberedPlayers.SecondPlayer];

            //Ex02_View.Messages.ShowTheWinner(winner, m_players.PlayersList);
        }

        private bool validateFlipInput(string i_Input)
        {
            return checkFirstLetterAndThenNumber(i_Input) &
                   checkInputRow(i_Input, true) &
                   checkInputColumn(i_Input, true) &
                   checkIfAlreadyFlipped(i_Input);
        }

        private string getCoordinateFromPlayer(Player i_Player)
        {
            string input = string.Empty;
            if (i_Player is RegularPlayer)
            {
                Console.WriteLine("Enter cell coordinate (first enter small letter and then the number and press enter):");
                input = Console.ReadLine();
            }

            if (i_Player is ComputerPlayer)
            {
                input = (i_Player as ComputerPlayer).GetRandomPlaceOnBoard(
                                                                            m_board.Board.Height,
                                                                            m_board.Board.Width,
                                                                            Cells.TempFlippedCells,
                                                                            Cells.FlippedCells);
            }

            return input;
        }

        private string checkIfQuit(string i_UserInput)
        {
            if (i_UserInput != "Q")
            {
                Console.WriteLine("Invalid input: you can insert only one character which is Q when you want to exit the game!");
            }

            return i_UserInput == "Q" ? "Q" : string.Empty;
        }

        private void showCurrentPlayer(Player i_Player)
        {
            Console.WriteLine("{0} turn (Score: {1})", i_Player.Name, i_Player.AmountOfPoints);
        }

        private bool checkFirstLetterAndThenNumber(string i_Input)
        {
            bool isValid = true;
            if (i_Input[(int)eBoardDimensionIndex.columnIndex] - k_smallLetterInAscii < 0 ||
                i_Input[(int)eBoardDimensionIndex.columnIndex] - k_smallLetterInAscii > 25)
            {
                isValid = false;
                Console.WriteLine("Invalid input: the letter and number are not written as requiered!");
            }

            return isValid;
        }

        private bool checkInputRow(string i_Input, bool i_ShowErrorMessage)
        {
            bool isValid = true;
            int value = i_Input[(int)eBoardDimensionIndex.columnIndex] - k_smallLetterInAscii;
            if (value < 0 ||
                value >= m_board.Board.Width)
            {
                if (i_ShowErrorMessage)
                {
                    Console.WriteLine("Invalid Input: column coordinate out of range!");
                }

                isValid = false;
            }

            return isValid;
        }

        private bool checkInputColumn(string i_Input, bool i_ShowErrorMessage)
        {
            bool isValid = true;
            int value = Convert.ToInt32(i_Input[(int)eBoardDimensionIndex.rowIndex]) - k_numberInAscii;
            if (value < 0 ||
                value >= m_board.Board.Height)
            {
                if (i_ShowErrorMessage)
                {
                    Console.WriteLine("Invalid Input: row coordinate out of range!");
                }

                isValid = false;
            }

            return isValid;
        }

        private bool checkIfAlreadyFlipped(string i_Input)
        {
            int row = i_Input[(int)eBoardDimensionIndex.rowIndex] - k_numberInAscii;
            int column = i_Input[(int)eBoardDimensionIndex.columnIndex] - k_smallLetterInAscii;

            bool isValid = checkInputColumn(i_Input, false) & checkInputRow(i_Input, false);

            if (isValid)
            {
                if (Cells.TempFlippedCells[row, column] != '\0' ||
                    Cells.FlippedCells[row, column] != '\0')
                {
                    Console.WriteLine("Invalid input: The cell already flipped!");
                    isValid = false;
                }
            }

            return isValid;
        }

        #endregion
    }
}
