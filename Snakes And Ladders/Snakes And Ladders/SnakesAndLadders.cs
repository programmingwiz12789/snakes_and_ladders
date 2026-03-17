using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snakes_And_Ladders
{
    public partial class SnakesAndLadders : Form
    {
        private const int NUM_ROWS = 10, NUM_COLS = 10, CELL_SIZE = 42, PIECE_SIZE = CELL_SIZE / 5, X_OFFSET = CELL_SIZE * 2 / 5, PLAYER_Y_OFFSET = CELL_SIZE / 5, OPP_Y_OFFSET = CELL_SIZE * 3 / 5, DURATION = 100, SPEED = 1;
        private Dictionary<string, Image> images;
        private Player player, opp;
        private int playerRollDiceCtr, oppRollDiceCtr;
        private Transportation[][] snakes, ladders;
        private Point[][] locations;
        private Point playerLoc, oppLoc;
        private bool gameOver;

        public SnakesAndLadders()
        {
            InitializeComponent();
        }

        private void SnakesAndLadders_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(570, 580);
            images = Utils.GetAllImages();
            playerRollDiceBtn.Enabled = true;
            playerRollDiceTimer.Enabled = true;
            playerMoveTimer.Enabled = true;
            oppRollDiceBtn.Enabled = true;
            oppRollDiceTimer.Enabled = true;
            oppMoveTimer.Enabled = true;
            refreshScreenTimer.Enabled = true;
            restartBtn.Enabled = true;
            int left = playerRollDiceBtn.Left, top = 30;
            locations = new Point[NUM_ROWS][];
            for (int i = 0; i < NUM_ROWS; i++)
            {
                locations[i] = new Point[NUM_COLS];
                for (int j = 0; j < NUM_COLS; j++)
                {
                    locations[i][j] = new Point(left, top);
                    left += CELL_SIZE;
                }
                left = playerRollDiceBtn.Left;
                top += CELL_SIZE;
            }
            DoubleBuffered = true;
            RandomizeGame();
        }

        private void RestartGame()
        {
            Random rn = new Random();
            playerRollDiceCtr = -1;
            player = new Player(rn.Next(1, 7), NUM_ROWS - 1, 0, 0, 1);
            playerRollDiceBtn.Image = images[$"dice{player.DiceNum}"];
            playerLoc = new Point(locations[player.SrcRow][player.SrcCol].X + X_OFFSET, locations[NUM_ROWS - 1][0].Y + PLAYER_Y_OFFSET);
            oppRollDiceCtr = -1;
            opp = new Player(rn.Next(1, 7), NUM_ROWS - 1, 0, 0, 1);
            oppRollDiceBtn.Image = images[$"dice{opp.DiceNum}"];
            oppLoc = new Point(locations[opp.SrcRow][opp.SrcCol].X + X_OFFSET, locations[NUM_ROWS - 1][0].Y + OPP_Y_OFFSET);
        }

        private void RandomizeGame()
        {
            RestartGame();
            Random rn = new Random();
            snakes = new Transportation[NUM_ROWS][];
            ladders = new Transportation[NUM_ROWS][];
            List<Point> pos = new List<Point>();
            for (int i = 0; i < NUM_ROWS; i++)
            {
                snakes[i] = new Transportation[NUM_COLS];
                ladders[i] = new Transportation[NUM_COLS];
                for (int j = 0; j < NUM_COLS; j++)
                {
                    snakes[i][j] = null;
                    ladders[i][j] = null;
                    if (i >= 1 && i <= NUM_ROWS - 2 && j >= 1 && j <= NUM_COLS - 2)
                    {
                        pos.Add(new Point(j, i));
                    }
                }
            }
            int snakesCnt = rn.Next(3, 5), laddersCnt = rn.Next(3, 5);
            for (int i = 1; i <= snakesCnt; i++)
            {
                int index = rn.Next(pos.Count);
                Point p = pos[index];
                int[] dCol = {-1, 0, 1};
                int idx = rn.Next(dCol.Length);
                snakes[p.Y][p.X] = new Transportation(p.Y, p.X, p.Y + 1, p.X + dCol[idx]);
                pos.RemoveAt(index);
                pos.Remove(new Point(p.X + dCol[idx], p.Y + 1));
                int[] dOuterRow = {-1, -1, 0, 1, 1, 1, 0, -1};
                int[] dOuterCol = {0, 1, 1, 1, 0, -1, -1, -1};
                for (int j = 0; j < 8; j++)
                {
                    if (p.X + dOuterCol[j] >= 0 && p.X + dOuterCol[j] <= NUM_COLS - 1)
                    {
                        pos.Remove(new Point(p.X + dOuterCol[j], p.Y + dOuterRow[j]));
                    }
                    if (p.X + dOuterCol[j] * 2 >= 0 && p.X + dOuterCol[j] * 2 <= NUM_COLS - 1)
                    {
                        pos.Remove(new Point(p.X + dOuterCol[j] * 2, p.Y + dOuterRow[j] * 2));
                    }
                }
            }
            for (int i = 1; i <= laddersCnt; i++)
            {
                int index = rn.Next(pos.Count);
                Point p = pos[index];
                int[] dCol = {-1, 0, 1};
                int idx = rn.Next(dCol.Length);
                ladders[p.Y][p.X] = new Transportation(p.Y, p.X, p.Y - 1, p.X + dCol[idx]);
                pos.RemoveAt(index);
                pos.Remove(new Point(p.X + dCol[idx], p.Y - 1));
                int[] dOuterRow = { -1, -1, 0, 1, 1, 1, 0, -1 };
                int[] dOuterCol = { 0, 1, 1, 1, 0, -1, -1, -1 };
                for (int j = 0; j < 8; j++)
                {
                    if (p.X + dOuterCol[j] >= 0 && p.X + dOuterCol[j] <= NUM_COLS - 1)
                    {
                        pos.Remove(new Point(p.X + dOuterCol[j], p.Y + dOuterRow[j]));
                    }
                    if (p.X + dOuterCol[j] * 2 >= 0 && p.X + dOuterCol[j] * 2 <= NUM_COLS - 1)
                    {
                        pos.Remove(new Point(p.X + dOuterCol[j] * 2, p.Y + dOuterRow[j] * 2));
                    }
                }
            }
            gameOver = false;
            Invalidate();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void randomizeBtn_Click(object sender, EventArgs e)
        {
            RandomizeGame();
        }

        private void playerRollDiceBtn_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerRollDiceCtr == -1 && oppRollDiceCtr == -1)
                {
                    playerRollDiceCtr = 0;
                }
            }
        }

        private void playerRollDiceTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerRollDiceCtr > DURATION)
                {
                    if (player.checkDestValid(0, NUM_COLS - 1))
                    {
                        player.setDest(0, NUM_COLS - 1);
                        playerRollDiceCtr = -2;
                    }
                    else
                    {
                        playerRollDiceCtr = -1;
                        if (oppRollDiceCtr == -1)
                        {
                            oppRollDiceCtr = 0;
                        }
                    }
                }
                else if (playerRollDiceCtr >= 0)
                {
                    Random rn = new Random();
                    player.DiceNum = rn.Next(1, 7);
                    playerRollDiceBtn.Image = images[$"dice{player.DiceNum}"];
                    playerRollDiceCtr++;
                }
            }
        }

        private void playerMoveTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerRollDiceCtr == -2)
                {
                    if (playerLoc == new Point(locations[player.DestRow][player.DestCol].X + X_OFFSET, locations[player.DestRow][player.DestCol].Y + PLAYER_Y_OFFSET))
                    {
                        player.SrcCol = player.DestCol;
                        player.SrcRow = player.DestRow;
                        player.DestCol = -1;
                        player.DestRow = -1;
                        if (player.DirRow != 0)
                        {
                            player.DirCol = -player.TempDirCol;
                            player.TempDirCol = 0;
                            player.DirRow = 0;
                        }
                        if (snakes[player.SrcRow][player.SrcCol] != null)
                        {
                            if ((snakes[player.SrcRow][player.SrcCol].EndRow - player.SrcRow) % 2 == 1)
                            {
                                player.DirCol = -player.DirCol;
                            }
                            int srcCol = player.SrcCol, srcRow = player.SrcRow;
                            player.SrcCol = snakes[srcRow][srcCol].EndCol;
                            player.SrcRow = snakes[srcRow][srcCol].EndRow;
                            playerLoc.X = locations[player.SrcRow][player.SrcCol].X + X_OFFSET;
                            playerLoc.Y = locations[player.SrcRow][player.SrcCol].Y + PLAYER_Y_OFFSET;
                        }
                        else if (ladders[player.SrcRow][player.SrcCol] != null)
                        {
                            if ((player.SrcRow - ladders[player.SrcRow][player.SrcCol].EndRow) % 2 == 1)
                            {
                                player.DirCol = -player.DirCol;
                            }
                            int srcCol = player.SrcCol, srcRow = player.SrcRow;
                            player.SrcCol = ladders[srcRow][srcCol].EndCol;
                            player.SrcRow = ladders[srcRow][srcCol].EndRow;
                            playerLoc.X = locations[player.SrcRow][player.SrcCol].X + X_OFFSET;
                            playerLoc.Y = locations[player.SrcRow][player.SrcCol].Y + PLAYER_Y_OFFSET;
                        }
                        playerRollDiceCtr = -1;
                        if (oppRollDiceCtr == -1)
                        {
                            oppRollDiceCtr = 0;
                        }
                    }
                    else
                    {
                        if (playerLoc.X + player.DirCol * SPEED < locations[player.SrcRow][0].X + X_OFFSET
                            || playerLoc.X + player.DirCol * SPEED > locations[player.SrcRow][NUM_COLS - 1].X + X_OFFSET)
                        {
                            player.TempDirCol = player.DirCol;
                            player.DirCol = 0;
                            player.DirRow = -1;
                        }
                        else if (player.DirRow != 0)
                        {
                            if (playerLoc.Y == locations[player.SrcRow + player.DirRow][player.SrcCol].Y + PLAYER_Y_OFFSET)
                            {
                                player.DirCol = -player.TempDirCol;
                                player.TempDirCol = 0;
                                player.SrcRow += player.DirRow;
                                player.DirRow = 0;
                            }
                            else
                            {
                                playerLoc.Y += player.DirRow * SPEED;
                            }
                        }
                        else
                        {
                            if (playerLoc == new Point(locations[player.SrcRow][player.SrcCol + player.DirCol].X + X_OFFSET, locations[player.SrcRow][player.SrcCol + player.DirCol].Y + PLAYER_Y_OFFSET))
                            {
                                player.SrcCol += player.DirCol;
                            }
                            else
                            {
                                playerLoc.X += player.DirCol * SPEED;
                            }
                        }
                    }
                    if (player.SrcCol == 0 && player.SrcRow == 0)
                    {
                        gameOver = true;
                        MessageBox.Show("You win!");
                    }
                }
            }
        }

        private void oppRollDiceTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (oppRollDiceCtr > DURATION)
                {
                    if (opp.checkDestValid(0, NUM_COLS - 1))
                    {
                        opp.setDest(0, NUM_COLS - 1);
                        oppRollDiceCtr = -2;
                    }
                    else
                    {
                        oppRollDiceCtr = -1;
                    }
                }
                else if (oppRollDiceCtr >= 0)
                {
                    Random rn = new Random();
                    opp.DiceNum = rn.Next(1, 7);
                    oppRollDiceBtn.Image = images[$"dice{opp.DiceNum}"];
                    oppRollDiceCtr++;
                }
            }
        }

        private void oppMoveTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (oppRollDiceCtr == -2)
                {
                    if (oppLoc == new Point(locations[opp.DestRow][opp.DestCol].X + X_OFFSET, locations[opp.DestRow][opp.DestCol].Y + OPP_Y_OFFSET))
                    {
                        opp.SrcCol = opp.DestCol;
                        opp.SrcRow = opp.DestRow;
                        opp.DestCol = -1;
                        opp.DestRow = -1;
                        if (opp.DirRow != 0)
                        {
                            opp.DirCol = -opp.TempDirCol;
                            opp.TempDirCol = 0;
                            opp.DirRow = 0;
                        }
                        if (snakes[opp.SrcRow][opp.SrcCol] != null)
                        {
                            if ((snakes[opp.SrcRow][opp.SrcCol].EndRow - opp.SrcRow) % 2 == 1)
                            {
                                opp.DirCol = -opp.DirCol;
                            }
                            int srcCol = opp.SrcCol, srcRow = opp.SrcRow;
                            opp.SrcCol = snakes[srcRow][srcCol].EndCol;
                            opp.SrcRow = snakes[srcRow][srcCol].EndRow;
                            oppLoc.X = locations[opp.SrcRow][opp.SrcCol].X + X_OFFSET;
                            oppLoc.Y = locations[opp.SrcRow][opp.SrcCol].Y + OPP_Y_OFFSET;
                        }
                        else if (ladders[opp.SrcRow][opp.SrcCol] != null)
                        {
                            if ((opp.SrcRow - ladders[opp.SrcRow][opp.SrcCol].EndRow) % 2 == 1)
                            {
                                opp.DirCol = -opp.DirCol;
                            }
                            int srcCol = opp.SrcCol, srcRow = opp.SrcRow;
                            opp.SrcCol = ladders[srcRow][srcCol].EndCol;
                            opp.SrcRow = ladders[srcRow][srcCol].EndRow;
                            oppLoc.X = locations[opp.SrcRow][opp.SrcCol].X + X_OFFSET;
                            oppLoc.Y = locations[opp.SrcRow][opp.SrcCol].Y + OPP_Y_OFFSET;
                        }
                        oppRollDiceCtr = -1;
                    }
                    else
                    {
                        if (oppLoc.X + opp.DirCol * SPEED < locations[opp.SrcRow][0].X + X_OFFSET
                            || oppLoc.X + opp.DirCol * SPEED > locations[opp.SrcRow][NUM_COLS - 1].X + X_OFFSET)
                        {
                            opp.TempDirCol = opp.DirCol;
                            opp.DirCol = 0;
                            opp.DirRow = -1;
                        }
                        else if (opp.DirRow != 0)
                        {
                            if (oppLoc.Y == locations[opp.SrcRow + opp.DirRow][opp.SrcCol].Y + OPP_Y_OFFSET)
                            {
                                opp.DirCol = -opp.TempDirCol;
                                opp.TempDirCol = 0;
                                opp.SrcRow += opp.DirRow;
                                opp.DirRow = 0;
                            }
                            else
                            {
                                oppLoc.Y += opp.DirRow * SPEED;
                            }
                        }
                        else
                        {
                            if (oppLoc == new Point(locations[opp.SrcRow][opp.SrcCol + opp.DirCol].X + X_OFFSET, locations[opp.SrcRow][opp.SrcCol + opp.DirCol].Y + OPP_Y_OFFSET))
                            {
                                opp.SrcCol += opp.DirCol;
                            }
                            else
                            {
                                oppLoc.X += opp.DirCol * SPEED;
                            }
                        }
                    }
                    if (opp.SrcCol == 0 && opp.SrcRow == 0)
                    {
                        gameOver = true;
                        MessageBox.Show("Opponent wins!");
                    }
                }
            }
        }

        private void refreshScreenTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void onDraw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int ctr = NUM_ROWS * NUM_COLS, left = playerRollDiceBtn.Left, top = 30;
            int[][] board = new int[NUM_ROWS][];
            bool flag = true;
            for (int i = 0; i < NUM_ROWS; i++)
            {
                board[i] = new int[NUM_COLS];
                if (flag)
                {
                    for (int j = 0; j < NUM_COLS; j++)
                    {
                        board[i][j] = ctr;
                        ctr--;
                    }
                }
                else
                {
                    for (int j = NUM_COLS - 1; j >= 0; j--)
                    {
                        board[i][j] = ctr;
                        ctr--;
                    }
                }
                flag = !flag;
            }
            for (int i = 0; i < NUM_ROWS; i++)
            {
                for (int j = 0; j < NUM_COLS; j++)
                {
                    Color color = Color.Brown;
                    if ((i + j) % 2 == 1)
                    {
                        color = Color.Chocolate;
                    }
                    g.FillRectangle(new SolidBrush(color), left, top, CELL_SIZE, CELL_SIZE);
                    g.DrawString(board[i][j] + "", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), new SolidBrush(Color.Yellow), left, top);
                    left += CELL_SIZE;
                }
                left = playerRollDiceBtn.Left;
                top += CELL_SIZE;
            }
            for (int i = 1; i < NUM_ROWS - 1; i++)
            {
                for (int j = 1; j < NUM_COLS - 1; j++)
                {
                    if (snakes[i][j] != null)
                    {
                        if (snakes[i][j].EndCol < snakes[i][j].StartCol)
                        {
                            g.DrawImage(images["snake_rotated_left"], locations[snakes[i][j].StartRow][snakes[i][j].StartCol - 1].X + CELL_SIZE / 2, locations[snakes[i][j].StartRow][snakes[i][j].StartCol - 1].Y + CELL_SIZE / 2, images["snake_rotated_left"].Width, images["snake_rotated_left"].Height);
                        }
                        else if (snakes[i][j].EndCol > snakes[i][j].StartCol)
                        {
                            g.DrawImage(images["snake_rotated_right"], locations[snakes[i][j].StartRow][snakes[i][j].StartCol].X + CELL_SIZE / 2, locations[snakes[i][j].StartRow][snakes[i][j].StartCol].Y + CELL_SIZE / 2, images["snake_rotated_right"].Width, images["snake_rotated_right"].Height);
                        }
                        else
                        {
                            g.DrawImage(images["snake"], locations[snakes[i][j].StartRow][snakes[i][j].StartCol].X + CELL_SIZE / 2 - images["snake"].Width / 2, locations[snakes[i][j].StartRow][snakes[i][j].StartCol].Y + CELL_SIZE / 2, images["snake"].Width, images["snake"].Height);
                        }
                    }
                    else if (ladders[i][j] != null)
                    {
                        if (ladders[i][j].EndCol < ladders[i][j].StartCol)
                        {
                            g.DrawImage(images["ladder_rotated_right"], locations[ladders[i][j].EndRow][ladders[i][j].EndCol].X + CELL_SIZE / 2, locations[ladders[i][j].EndRow][ladders[i][j].EndCol].Y + CELL_SIZE / 2, images["ladder_rotated_left"].Width, images["ladder_rotated_left"].Height);
                        }
                        else if (ladders[i][j].EndCol > ladders[i][j].StartCol)
                        {
                            g.DrawImage(images["ladder_rotated_left"], locations[ladders[i][j].EndRow][ladders[i][j].EndCol - 1].X + CELL_SIZE / 2, locations[ladders[i][j].EndRow][ladders[i][j].EndCol - 1].Y + CELL_SIZE / 2, images["ladder_rotated_right"].Width, images["ladder_rotated_right"].Height);
                        }
                        else
                        {
                            g.DrawImage(images["ladder"], locations[ladders[i][j].EndRow][ladders[i][j].EndCol].X + CELL_SIZE / 2 - images["ladder"].Width / 2, locations[ladders[i][j].EndRow][ladders[i][j].EndCol].Y + CELL_SIZE / 2, images["ladder"].Width, images["ladder"].Height);
                        }
                    }
                }
            }
            g.DrawImage(images["goal"], locations[0][0].X + CELL_SIZE / 2 - images["goal"].Width / 2, locations[0][0].Y + CELL_SIZE / 2 - images["goal"].Height / 2, images["goal"].Width, images["goal"].Height);
            g.FillEllipse(new SolidBrush(Color.White), playerLoc.X, playerLoc.Y, PIECE_SIZE, PIECE_SIZE);
            g.FillEllipse(new SolidBrush(Color.Cyan), oppLoc.X, oppLoc.Y, PIECE_SIZE, PIECE_SIZE);
        }
    }
}
