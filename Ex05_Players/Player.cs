namespace Ex05_Players
{
    using System;
    using Ex05_Players.Enums;

    public class Player
    {
        private string m_name;
        private int? m_amountOfPoints;
        private char m_firstTempFlippedCellValue;
        private int m_FirstCellRowToFlip;
        private int m_FirstCellColumnToFlip;
        private char m_secondTempFlippedCellValue;
        private int m_SecondCellRowToFlip;
        private int m_SecondCellColumnToFlip;
        private ePlayerType? m_playerType;

        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                bool isNameCorrect = validateMame(value);
                if (isNameCorrect)
                {
                    m_name = value;
                }
                else
                {
                    m_name = null;
                }
            }
        }

        public int AmountOfPoints
        {
            get
            {
                return (int)m_amountOfPoints;
            }

            set
            {
                bool isamountOfPointsCorrect = validateAmountOfPoints(value);
                if (isamountOfPointsCorrect)
                {
                    m_amountOfPoints = value;
                }
                else
                {
                    m_amountOfPoints = null;
                }
            }
        }

        public ePlayerType? PlayerType
        {
            get
            {
                return m_playerType;
            }

            set
            {
                m_playerType = value;
            }
        }

        public char FirstTempFlippedCellValue
        {
            get
            {
                return m_firstTempFlippedCellValue;
            }

            set
            {
                m_firstTempFlippedCellValue = value;
            }
        }

        public int FirstCellRowToFlip
        {
            get
            {
                return m_FirstCellRowToFlip;
            }

            set
            {
                m_FirstCellRowToFlip = value;
            }
        }

        public int FirstCellColumnToFlip
        {
            get
            {
                return m_FirstCellColumnToFlip;
            }

            set
            {
                m_FirstCellColumnToFlip = value;
            }
        }

        public char SecondTempFlippedCellValue
        {
            get
            {
                return m_secondTempFlippedCellValue;
            }

            set
            {
                m_secondTempFlippedCellValue = value;
            }
        }

        public int SecondCellRowToFlip
        {
            get
            {
                return m_SecondCellRowToFlip;
            }

            set
            {
                m_SecondCellRowToFlip = value;
            }
        }

        public int SecondCellColumnToFlip
        {
            get
            {
                return m_SecondCellColumnToFlip;
            }

            set
            {
                m_SecondCellColumnToFlip = value;
            }
        }

        private bool validateMame(string name)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("The name is not correct!");
                isValid = false;
            }

            return isValid;
        }

        private bool validateAmountOfPoints(int value)
        {
            bool isValid = true;
            if (value < 0)
            {
                Console.WriteLine("Amount of points can't be smaller than zero!");
                isValid = false;
            }

            return isValid;
        }
    }
}
