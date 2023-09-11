namespace Ex05_Players
{
    using System;

    public class ComputerPlayer : Player
    {
        private const string k_ComputerName = "COMPUTER";
        private const int k_SmallLetterInAscii = 97;
        private const int k_NumberInAscii = 49;
        private static char m_ColumnIndexAlreadyFlipped = ' ';
        private static char m_RowIndexAlreadyFlipped = ' ';

        public ComputerPlayer(int i_amountOfPoints)
        {
            Name = k_ComputerName;
            AmountOfPoints = i_amountOfPoints;
        }

        public string GetRandomPlaceOnBoard(int i_Height, int i_Width, char[,] i_FlippedCells)
        {
            Random rnd = new Random();
            char[] chars = new char[2];

            char columnIndex = '-';
            char rowIndex = '-';
            do
            {
                columnIndex = (char)(rnd.Next(0, i_Width) + k_SmallLetterInAscii);
                rowIndex = (char)(rnd.Next(0, i_Height) + k_NumberInAscii);

                if (columnIndex != m_ColumnIndexAlreadyFlipped || rowIndex != m_RowIndexAlreadyFlipped)
                {
                    m_ColumnIndexAlreadyFlipped = columnIndex;
                    m_RowIndexAlreadyFlipped = rowIndex;
                }

                chars[0] = columnIndex;
                chars[1] = rowIndex;
            }
            while (i_FlippedCells[rowIndex - k_NumberInAscii, columnIndex - k_SmallLetterInAscii] != '\0' &&
                   columnIndex == m_ColumnIndexAlreadyFlipped &&
                   rowIndex == m_RowIndexAlreadyFlipped);

            return new string(chars);
        }
    }
}
