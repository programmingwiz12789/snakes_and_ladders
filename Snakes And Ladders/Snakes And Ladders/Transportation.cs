namespace Snakes_And_Ladders
{
    internal class Transportation
    {
        private int startRow, startCol, endRow, endCol;

        public Transportation(int startRow, int startCol, int endRow, int endCol)
        {
            this.startRow = startRow;
            this.startCol = startCol;
            this.endRow = endRow;
            this.endCol = endCol;
        }

        public int StartRow { get => startRow; set => startRow = value; }
        public int StartCol { get => startCol; set => startCol = value; }
        public int EndRow { get => endRow; set => endRow = value; }
        public int EndCol { get => endCol; set => endCol = value; }
    }
}
