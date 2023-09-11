namespace C22_EX05_Matan_204597082_Oleg_319274874
{
    public static class BoardSize
    {
        // $G$ CSS-999 (-3) Static members should be in the form of s_PascalCase.
        private static string[] k_BoardSizes = {
                                         "4 X 4",
                                         "4 X 5",
                                         "4 X 6",
                                         "5 X 4",
                                         "5 X 6",
                                         "6 X 4",
                                         "6 X 5",
                                         "6 X 6"};
        // $G$ CSS-999 (-3) Static members should be in the form of s_PascalCase.
        private static int m_Index = 0;

        public static string GetNextSize()
        {
            if(m_Index >= k_BoardSizes.Length-1)
            {
                m_Index = 0;
            }
            else
            {
                m_Index++;
            }
            string boardSize = k_BoardSizes[m_Index];

            return boardSize;
        }

        public static string GetCurrentSize()
        {
            return k_BoardSizes[m_Index];
        }
    }
}
