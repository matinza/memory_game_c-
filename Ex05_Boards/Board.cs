namespace Ex05_Boards
{
    public class Board
    {
        public Board(int i_Height, int i_Width)
        {
            Cells.CellsWithValues = new char[i_Height, i_Width];
            Cells.FlippedCells = new char[i_Height, i_Width];
            Cells.ColorsOfTheCells = new string[i_Height, i_Width];
            Cells.InitializeCellsWithValues(i_Height, i_Width);
            Cells.InitializeColorsToCells(i_Height, i_Width);
        }
    }
}
