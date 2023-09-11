namespace Ex05_GameManager.Initialization
{
    using System;
    using Ex05_Boards;
    using Ex05_Boards.Enums;

    internal class BoardInitializtion
    {
        private const int k_AmountOfDimensions = 2;
        private const string k_HeightString = "height";
        private const string k_WidthString = "width";
        private Board m_board;

        public Board Board { get => m_board; set => m_board = value; }

        public BoardInitializtion()
        {
            initializeBoard();
        }

        private void initializeBoard()
        {
            int[] size;
            do
            {
                size = setBoardSize();
                if ((size[(int)eBoardDimensionIndex.columnIndex] *
                     size[(int)eBoardDimensionIndex.rowIndex]) % 2 != 0)
                {
                    Console.WriteLine("board size must be even!");
                }
            }
            while ((size[(int)eBoardDimensionIndex.columnIndex] *
                      size[(int)eBoardDimensionIndex.rowIndex]) % 2 != 0);

            Board = new Board(size[(int)eBoardDimensionIndex.columnIndex], size[(int)eBoardDimensionIndex.rowIndex]);
            Board.Height = size[(int)eBoardDimensionIndex.columnIndex];
            Board.Width = size[(int)eBoardDimensionIndex.rowIndex];
        }

        private int[] setBoardSize()
        {
            int[] size = new int[k_AmountOfDimensions];
            string[] dimensions = new string[k_AmountOfDimensions];
            dimensions[(int)eBoardDimensionIndex.columnIndex] = k_HeightString;
            dimensions[(int)eBoardDimensionIndex.rowIndex] = k_WidthString;

            for (int i = 0; i < k_AmountOfDimensions; i++)
            {
                string userInput;
                do
                {
                    userInput = getSizeInput(dimensions[i]);
                    if (userInput == string.Empty)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                while (userInput == string.Empty);
                size[i] = int.Parse(userInput);
            }

            return size;
        }

        private string getSizeInput(string dimension)
        {
            //TODO: handle using forms
            //Ex02_View.Draw.CustomizedClearScreen(2000);
            Console.WriteLine(
                "Enter the {0} of the board (values {1} - {2} are allowed): ",
                dimension,
                (int)eBoardAllowedDimensions.MinAllowedSize,
                (int)eBoardAllowedDimensions.MaxAllowedSize);

            string userSizeInput = Console.ReadLine();
            bool isValid = !string.IsNullOrEmpty(userSizeInput) &
                           isNumber(userSizeInput) &
                           isRightValues(userSizeInput);

            return isValid ? userSizeInput : string.Empty;
        }

        private bool isRightValues(string i_SizeValue)
        {
            int value;
            bool isValid = false;
            if (isNumber(i_SizeValue))
            {
                value = int.Parse(i_SizeValue);
                isValid = (value >= (int)eBoardAllowedDimensions.MinAllowedSize &&
                           value <= (int)eBoardAllowedDimensions.MaxAllowedSize) ?
                           true : false;
            }

            return isValid;
        }

        private bool isNumber(string i_value)
        {
            bool isNumber = int.TryParse(i_value, out int result);
            return isNumber;
        }
    }
}
