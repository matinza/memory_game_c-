namespace Ex05_Boards
{
    using System;

    public static class Cells
    {
        private static char[,] m_CellsWithValues;
        private static char[,] m_FlippedCells;
        private static string[,] m_ColorsOfTheCells;

        public static char[,] CellsWithValues { get => m_CellsWithValues; set => m_CellsWithValues = value; }

        public static char[,] FlippedCells { get => m_FlippedCells; set => m_FlippedCells = value; }

        public static string[,] ColorsOfTheCells { get => m_ColorsOfTheCells; set => m_ColorsOfTheCells = value; }

        public static void InitializeCellsWithValues(int i_Height, int i_Width)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random rnd = new Random();
            char randomizedChar;
            int randomizedRow;
            int randomizedColumn;

            //TODO : replace the clear screen with form
            //Ex02_View.Draw.CustomizedClearScreen(2000);
            Console.WriteLine("Initializing board...");

            for (int i = 0; i < m_CellsWithValues.Length; i += 2)
            {
                while (true)
                {
                    randomizedChar = getRandomCharacter(chars, rnd);
                    if (!isExistInMatix(i_Height, i_Width, randomizedChar))
                    {
                        break;
                    }
                }

                for (int t = 0; t < 2; t++)
                {
                    while (true)
                    {
                        randomizedRow = rnd.Next(m_CellsWithValues.GetLength(0));
                        randomizedColumn = rnd.Next(m_CellsWithValues.GetLength(1));

                        if (m_CellsWithValues[randomizedRow, randomizedColumn] == '\0')
                        {
                            m_CellsWithValues[randomizedRow, randomizedColumn] = randomizedChar;
                            break;
                        }
                    }
                }
            }

            //TODO : replace the clear screen with form
            //Ex02_View.Draw.CustomizedClearScreen(2000);
        }


        public static void InitializeFlippedCells(
                                                  int i_Height,
                                                  int i_Width,
                                                  int i_FirstCellRowToFlip,
                                                  int i_FirstCellColumnToFlip,
                                                  int i_SecondCellRowToFlip,
                                                  int i_SecondCellColumnToFlip,
                                                  bool i_shouldIitializeToEmpty)
        {
            for (int i = 0; i < i_Height; i++)
            {
                for (int j = 0; j < i_Width; j++)
                {
                    if (i_shouldIitializeToEmpty)
                    {
                        //m_FlippedCells[i, j] = m_EmptyCells[i, j];
                    }
                    if (i == i_FirstCellRowToFlip && j == i_FirstCellColumnToFlip)
                    {
                        m_FlippedCells[i_FirstCellRowToFlip, i_FirstCellColumnToFlip] =
                        m_CellsWithValues[i_FirstCellRowToFlip, i_FirstCellColumnToFlip];
                    }

                    if (i == i_SecondCellRowToFlip && j == i_SecondCellColumnToFlip)
                    {
                        m_FlippedCells[i_SecondCellRowToFlip, i_SecondCellColumnToFlip] =
                        m_CellsWithValues[i_SecondCellRowToFlip, i_SecondCellColumnToFlip];
                    }
                    else
                    {
                        m_FlippedCells[i, j] = m_FlippedCells[i, j];
                    }
                }
            }
        }

        public static void InitializeColorsToCells(
                                                   int i_Height,
                                                   int i_Width,
                                                   string i_DefaultColor = "100, 100, 100")
        {
            for (int i = 0; i < i_Height; i++)
            {
                for (int j = 0; j < i_Width; j++)
                {
                    ColorsOfTheCells[i, j] = i_DefaultColor;
                }
            }
        }

        public static bool IsAllFlipped(int i_Height, int i_Width)
        {
            bool isAllFlipped = true;
            for (int i = 0; i < i_Height; i++)
            {
                for (int j = 0; j < i_Width; j++)
                {
                    if (m_FlippedCells[i, j] == '\0')
                    {
                        isAllFlipped = false;
                        break;
                    }
                }
            }

            return isAllFlipped;
        }

        private static bool isExistInMatix(int i_Height, int i_Width, char valueToCheck)
        {
            bool isExist = false;
            for (int i = 0; i < i_Height; i++)
            {
                for (int j = 0; j < i_Width; j++)
                {
                    if (valueToCheck == m_CellsWithValues[i, j])
                    {
                        return true;
                    }
                }
            }

            return isExist;
        }

        private static char getRandomCharacter(char[] text, Random rnd)
        {
            int index = rnd.Next(text.Length);
            return text[index];
        }
    }
}
