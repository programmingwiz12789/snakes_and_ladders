namespace Snakes_And_Ladders
{
    internal class Player
    {
        private int diceNum, srcRow, srcCol, dirRow, dirCol, tempDirCol, destRow, destCol;

        public Player(int diceNum, int srcRow, int srcCol, int dirRow, int dirCol)
        {
            this.diceNum = diceNum;
            this.srcRow = srcRow;
            this.srcCol = srcCol;
            this.dirRow = dirRow;
            this.dirCol = dirCol;
            tempDirCol = 0;
            destRow = -1;
            destCol = -1;
        }

        public int DiceNum { get => diceNum; set => diceNum = value; }
        public int SrcRow { get => srcRow; set => srcRow = value; }
        public int SrcCol { get => srcCol; set => srcCol = value; }
        public int DirRow { get => dirRow; set => dirRow = value; }
        public int DirCol { get => dirCol; set => dirCol = value; }
        public int TempDirCol { get => tempDirCol; set => tempDirCol = value; }
        public int DestRow { get => destRow; set => destRow = value; }
        public int DestCol { get => destCol; set => destCol = value; }

        public bool checkDestValid(int minCol, int maxCol)
        {
            int destRow = srcRow, destCol = srcCol, dirCol = this.dirCol, ctr = 0;
            while (ctr < diceNum)
            {
                if (destCol + dirCol >= minCol && destCol + dirCol <= maxCol)
                {
                    destCol += dirCol;
                }
                else
                {
                    destRow--;
                    if (destRow < 0)
                    {
                        return false;
                    }
                    dirCol = -dirCol;
                }
                ctr++;
            }
            return true;
        }

        public void setDest(int minCol, int maxCol)
        {
            int destRow = srcRow, destCol = srcCol, dirCol = this.dirCol, ctr = 0;
            while (ctr < diceNum)
            {
                if (destCol + dirCol >= minCol && destCol + dirCol <= maxCol)
                {
                    destCol += dirCol;
                }
                else
                {
                    destRow--;
                    dirCol = -dirCol;
                }
                ctr++;
            }
            this.destRow = destRow;
            this.destCol = destCol;
        }
    }
}
