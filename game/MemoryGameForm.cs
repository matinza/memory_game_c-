namespace C22_EX05_Matan_204597082_Oleg_319274874
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using Ex05_Boards;
    using Ex05_Players;

    public class MemoryGameForm : Form
    {
        private const int k_NumberInAscii = 48;
        private const string k_ColorFirstPlayer = "128, 255, 128";
        private const string k_ColorSecondPlayer = "128, 128, 255";
        private int m_RedColor;
        private int m_GreenColor;
        private int m_BlueColor;
        private int m_BoardWidth;
        private int m_BoardHeight;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsFirstPlayer = true;
        private char m_FirstCellToCompare = '\0';
        private char m_SecondCellToCompare = '\0';
        private int m_FirstCellRowToFlip;
        private int m_FirstCellColumnToFlip;
        private int m_SecondCellRowToFlip;
        private int m_SecondCellColumnToFlip;
        private FlowLayoutPanel flowLayoutPanel_SecondPlayer;
        private Label Label_SecondPlayer;
        private FlowLayoutPanel flowLayoutPanel_FirstPlayer;
        private Label Label_FirstPlayer;
        private FlowLayoutPanel flowLayoutPanel_CurrentPlayer;
        private Label Label_CurrentPlayer;
        private GroupBox Panel_Details;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer Timer_DrawingAndSetCurrentPlayer;
        private GroupBox Panel_Cells;

        public MemoryGameForm(
                              string i_BoardSize,
                              TextBox i_FirstPlayer,
                              TextBox i_SecondPlayer,
                              bool i_IsAgainstComputer)
        {

            InitializeComponent();
            initializeBoardAndCells(i_BoardSize);
            initializeCellsPanel();
            initializeDetailsPanel(
                                   i_FirstPlayer,
                                   i_SecondPlayer,
                                   i_IsAgainstComputer);
            Timer_DrawingAndSetCurrentPlayer.Start();
            ShowDialog();
        }

        private void initializeBoardAndCells(string i_BoardSize)
        {
            m_BoardWidth = (int)i_BoardSize[0] - k_NumberInAscii;
            m_BoardHeight = (int)i_BoardSize[4] - k_NumberInAscii;
            new Board(m_BoardHeight, m_BoardWidth);
        }

        // $G$ CSS-999 (-3) Private methods should start with a lower-case letter.
        // $G$ DSN-003 (-5) This method is too long, you should have split it into several methods.
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel_Cells = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_SecondPlayer = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_SecondPlayer = new System.Windows.Forms.Label();
            this.flowLayoutPanel_FirstPlayer = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_FirstPlayer = new System.Windows.Forms.Label();
            this.flowLayoutPanel_CurrentPlayer = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_CurrentPlayer = new System.Windows.Forms.Label();
            this.Panel_Details = new System.Windows.Forms.GroupBox();
            this.Timer_DrawingAndSetCurrentPlayer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel_SecondPlayer.SuspendLayout();
            this.flowLayoutPanel_FirstPlayer.SuspendLayout();
            this.flowLayoutPanel_CurrentPlayer.SuspendLayout();
            this.Panel_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Cells
            // 
            this.Panel_Cells.AutoSize = true;
            this.Panel_Cells.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Cells.Location = new System.Drawing.Point(29, 36);
            this.Panel_Cells.Name = "Panel_Cells";
            this.Panel_Cells.Size = new System.Drawing.Size(6, 5);
            this.Panel_Cells.TabIndex = 4;
            this.Panel_Cells.TabStop = false;
            // 
            // flowLayoutPanel_SecondPlayer
            // 
            this.flowLayoutPanel_SecondPlayer.Controls.Add(this.Label_SecondPlayer);
            this.flowLayoutPanel_SecondPlayer.Location = new System.Drawing.Point(16, 109);
            this.flowLayoutPanel_SecondPlayer.Name = "flowLayoutPanel_SecondPlayer";
            this.flowLayoutPanel_SecondPlayer.Size = new System.Drawing.Size(200, 36);
            this.flowLayoutPanel_SecondPlayer.TabIndex = 3;
            // 
            // Label_SecondPlayer
            // 
            this.Label_SecondPlayer.AutoSize = true;
            this.Label_SecondPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Label_SecondPlayer.Location = new System.Drawing.Point(3, 0);
            this.Label_SecondPlayer.Name = "Label_SecondPlayer";
            this.Label_SecondPlayer.Size = new System.Drawing.Size(115, 20);
            this.Label_SecondPlayer.TabIndex = 0;
            this.Label_SecondPlayer.Text = "Second Player:";
            // 
            // flowLayoutPanel_FirstPlayer
            // 
            this.flowLayoutPanel_FirstPlayer.Controls.Add(this.Label_FirstPlayer);
            this.flowLayoutPanel_FirstPlayer.Location = new System.Drawing.Point(16, 67);
            this.flowLayoutPanel_FirstPlayer.Name = "flowLayoutPanel_FirstPlayer";
            this.flowLayoutPanel_FirstPlayer.Size = new System.Drawing.Size(200, 36);
            this.flowLayoutPanel_FirstPlayer.TabIndex = 2;
            // 
            // Label_FirstPlayer
            // 
            this.Label_FirstPlayer.AutoSize = true;
            this.Label_FirstPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Label_FirstPlayer.Location = new System.Drawing.Point(3, 0);
            this.Label_FirstPlayer.Name = "Label_FirstPlayer";
            this.Label_FirstPlayer.Size = new System.Drawing.Size(91, 20);
            this.Label_FirstPlayer.TabIndex = 0;
            this.Label_FirstPlayer.Text = "First Player:";
            // 
            // flowLayoutPanel_CurrentPlayer
            // 
            this.flowLayoutPanel_CurrentPlayer.Controls.Add(this.Label_CurrentPlayer);
            this.flowLayoutPanel_CurrentPlayer.Location = new System.Drawing.Point(16, 25);
            this.flowLayoutPanel_CurrentPlayer.Name = "flowLayoutPanel_CurrentPlayer";
            this.flowLayoutPanel_CurrentPlayer.Size = new System.Drawing.Size(200, 36);
            this.flowLayoutPanel_CurrentPlayer.TabIndex = 1;
            // 
            // Label_CurrentPlayer
            // 
            this.Label_CurrentPlayer.AutoSize = true;
            this.Label_CurrentPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Label_CurrentPlayer.Location = new System.Drawing.Point(3, 0);
            this.Label_CurrentPlayer.Name = "Label_CurrentPlayer";
            this.Label_CurrentPlayer.Size = new System.Drawing.Size(117, 20);
            this.Label_CurrentPlayer.TabIndex = 0;
            this.Label_CurrentPlayer.Text = "Cureent Player:";
            // 
            // Panel_Details
            // 
            this.Panel_Details.AutoSize = true;
            this.Panel_Details.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Details.Controls.Add(this.flowLayoutPanel_CurrentPlayer);
            this.Panel_Details.Controls.Add(this.flowLayoutPanel_FirstPlayer);
            this.Panel_Details.Controls.Add(this.flowLayoutPanel_SecondPlayer);
            this.Panel_Details.Location = new System.Drawing.Point(12, 412);
            this.Panel_Details.Name = "Panel_Details";
            this.Panel_Details.Size = new System.Drawing.Size(222, 170);
            this.Panel_Details.TabIndex = 5;
            this.Panel_Details.TabStop = false;
            // 
            // Timer_DrawingAndSetCurrentPlayer
            // 
            this.Timer_DrawingAndSetCurrentPlayer.Interval = 1000;
            this.Timer_DrawingAndSetCurrentPlayer.Tick += new System.EventHandler(this.Timer_DrawingAndSetCurrentPlayer_Tick);
            // 
            // MemoryGameForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(565, 594);
            this.Controls.Add(this.Panel_Cells);
            this.Controls.Add(this.Panel_Details);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemoryGameForm";
            this.flowLayoutPanel_SecondPlayer.ResumeLayout(false);
            this.flowLayoutPanel_SecondPlayer.PerformLayout();
            this.flowLayoutPanel_FirstPlayer.ResumeLayout(false);
            this.flowLayoutPanel_FirstPlayer.PerformLayout();
            this.flowLayoutPanel_CurrentPlayer.ResumeLayout(false);
            this.flowLayoutPanel_CurrentPlayer.PerformLayout();
            this.Panel_Details.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void initializeCellsPanel()
        {
            string rgbColor;
            int redColor;
            int greenColor;
            int blueColor;
            int startX = 10;
            int startY = 10;

            this.Panel_Cells.Controls.Clear();
            for (int i = 0; i < m_BoardHeight; i++)
            {
                for (int j = 0; j < m_BoardWidth; j++)
                {
                    rgbColor = Cells.ColorsOfTheCells[i, j].ToString();
                    redColor = int.Parse(rgbColor.Substring(0, 3));
                    greenColor = int.Parse(rgbColor.Substring(5, 3));
                    blueColor = int.Parse(rgbColor.Substring(10, 3));

                    Button button = new Button();
                    button.Name = string.Format("{0}{1}", i, j);
                    button.Location = new Point(startX, startY);
                    button.Width = 50;
                    button.Height = 50;
                    startY += 55;
                    button.Text = Cells.FlippedCells[i, j].ToString();
                    button.BackColor = Color.FromArgb(redColor, greenColor, blueColor);
                    button.Click += new EventHandler(CellsFlipped_Click);
                    this.Panel_Cells.Controls.Add(button);
                }

                startX += 55;
                startY = 10;
            }
        }

        private void initializeDetailsPanel(
                                            TextBox i_FirstPlayer,
                                            TextBox i_SecondPlayer,
                                            bool i_IsAgainstComputer)
        {
            initializeDetailsPanelSize();
            initializeDetailsPanelPlayers(i_FirstPlayer, i_SecondPlayer, i_IsAgainstComputer);
        }

        private void initializeDetailsPanelPlayers(TextBox i_FirstPlayer, TextBox i_SecondPlayer, bool i_IsAgainstComputer)
        {
            this.Label_FirstPlayer.Text = string.Format("{0}: ", i_FirstPlayer.Text);
            this.Label_SecondPlayer.Text = string.Format("{0}: ", i_SecondPlayer.Text);

            m_FirstPlayer = new RegularPlayer(i_FirstPlayer.Text, 0);
            if (i_IsAgainstComputer)
            {
                m_SecondPlayer = new ComputerPlayer(0);
            }
            else
            {
                m_SecondPlayer = new RegularPlayer(i_SecondPlayer.Text, 0);
            }

            this.Label_CurrentPlayer.Text = string.Format("Current Player: {0}",
                                                                    m_IsFirstPlayer ?
                                                                    m_FirstPlayer.Name :
                                                                    m_SecondPlayer.Name);
            int redColor = int.Parse(k_ColorFirstPlayer.Substring(0, 3));
            int greenColor = int.Parse(k_ColorFirstPlayer.Substring(5, 3));
            int blueColor = int.Parse(k_ColorFirstPlayer.Substring(10, 3));
            this.Label_CurrentPlayer.BackColor = Color.FromArgb(redColor, greenColor, blueColor);
        }

        private void initializeDetailsPanelSize()
        {
            this.Panel_Details.Location = new Point(
                                                    29,
                                                    36 + this.Panel_Cells.Height);
            this.Width = this.Panel_Cells.Width + 50;
            this.Height = this.Panel_Cells.Height + this.Panel_Details.Height + 80;
        }

        // $G$ CSS-999 (-3) Private methods should start with a lower-case letter.
        private void CellsFlipped_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int rowToFlip = button.Name[0] - k_NumberInAscii;
            int columnToFlip = button.Name[1] - k_NumberInAscii;

            if (isAlreadyFlipped(rowToFlip, columnToFlip))
            {
                return;
            }

            button.BackColor = Color.FromArgb(m_RedColor, m_GreenColor, m_BlueColor);
            button.Text = Cells.CellsWithValues[rowToFlip, columnToFlip].ToString();

            if (isFirstCellFlip())
            {
                handleFirstFlip(rowToFlip, columnToFlip);
            }
            else
            {
                handleSecondFlip(rowToFlip, columnToFlip);
            }

            Timer_DrawingAndSetCurrentPlayer.Start();
        }

        private void handleSecondFlip(int rowToFlip, int columnToFlip)
        {
            m_SecondCellToCompare = Cells.CellsWithValues[rowToFlip, columnToFlip];
            m_SecondCellRowToFlip = rowToFlip;
            m_SecondCellColumnToFlip = columnToFlip;
            Cells.FlippedCells[m_SecondCellRowToFlip, m_SecondCellColumnToFlip] = m_SecondCellToCompare;

            if (m_FirstCellToCompare != m_SecondCellToCompare)
            {
                handleFlipppedCellsAreDiffrent();
            }
            else
            {
                handleFlippedCellsAreTheSame(rowToFlip, columnToFlip);
            }

            m_FirstCellToCompare = '\0';
            m_SecondCellToCompare = '\0';
        }

        private void handleFlippedCellsAreTheSame(int rowToFlip, int columnToFlip)
        {
            Cells.FlippedCells[m_FirstCellRowToFlip, m_FirstCellColumnToFlip] = m_FirstCellToCompare;
            Cells.FlippedCells[m_SecondCellRowToFlip, m_SecondCellColumnToFlip] = m_SecondCellToCompare;

            if (m_IsFirstPlayer)
            {
                m_FirstPlayer.AmountOfPoints++;
                changeColor(false, rowToFlip, columnToFlip);
            }
            else
            {
                m_SecondPlayer.AmountOfPoints++;
                changeColor(false, rowToFlip, columnToFlip);
            }

            setWinner();
        }

        private void handleFlipppedCellsAreDiffrent()
        {
            m_IsFirstPlayer = m_IsFirstPlayer ? false : true;
            Cells.FlippedCells[m_FirstCellRowToFlip, m_FirstCellColumnToFlip] = '\0';
            Cells.FlippedCells[m_SecondCellRowToFlip, m_SecondCellColumnToFlip] = '\0';
            changeColor(true, m_FirstCellRowToFlip, m_FirstCellColumnToFlip);
            changeColor(true, m_SecondCellRowToFlip, m_SecondCellColumnToFlip);
        }

        private void handleFirstFlip(int rowToFlip, int columnToFlip)
        {
            m_FirstCellToCompare = Cells.CellsWithValues[rowToFlip, columnToFlip];
            m_FirstCellRowToFlip = rowToFlip;
            m_FirstCellColumnToFlip = columnToFlip;
            Cells.FlippedCells[m_FirstCellRowToFlip, m_FirstCellColumnToFlip] = m_FirstCellToCompare;
            changeColor(false, rowToFlip, columnToFlip);
        }

        private void setWinner()
        {
            if (Cells.IsAllFlipped(m_BoardHeight, m_BoardWidth))
            {
                MessageBox.Show(string.Format("The winner is: {0} with {1} Pairs",
                                              m_FirstPlayer.AmountOfPoints > m_SecondPlayer.AmountOfPoints ?
                                              m_FirstPlayer.Name:
                                              m_SecondPlayer.Name,
                                              m_FirstPlayer.AmountOfPoints > m_SecondPlayer.AmountOfPoints ?
                                              m_FirstPlayer.AmountOfPoints :
                                              m_SecondPlayer.AmountOfPoints),
                                              "Congratulation!!!",
                                               MessageBoxButtons.OK);
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private bool isFirstCellFlip()
        {
            return m_FirstCellToCompare == '\0';
        }

        private bool isAlreadyFlipped(int i_RowToFlip, int i_ColumnToFlip)
        {
            return Cells.FlippedCells[i_RowToFlip, i_ColumnToFlip] != '\0';
        }

        private void changeColor(bool i_IsDefaultColor, int i_RowToFlip, int i_ColumnToFlip)
        {
            if (i_IsDefaultColor)
            {
                Cells.ColorsOfTheCells[i_RowToFlip, i_ColumnToFlip] = "100, 100, 100";
                return;
            }
            if (m_IsFirstPlayer)
            {
                string firstPlayerColor = string.Format(
                                                        "{0}, {1}, {2}",
                                                        this.Label_FirstPlayer.BackColor.R.ToString(),
                                                        this.Label_FirstPlayer.BackColor.G.ToString(),
                                                        this.Label_FirstPlayer.BackColor.B.ToString());

                Cells.ColorsOfTheCells[i_RowToFlip, i_ColumnToFlip] = firstPlayerColor;
            }
            else
            {
                string secondPlayerColor = string.Format(
                                                        "{0}, {1}, {2}",
                                                          this.Label_SecondPlayer.BackColor.R.ToString(),
                                                          this.Label_SecondPlayer.BackColor.G.ToString(),
                                                          this.Label_SecondPlayer.BackColor.B.ToString());

                Cells.ColorsOfTheCells[i_RowToFlip, i_ColumnToFlip] = secondPlayerColor;
            }
        }

        private void setCurrentPlayer()
        {
            m_RedColor = int.Parse(m_IsFirstPlayer ? k_ColorFirstPlayer.Substring(0, 3) : k_ColorSecondPlayer.Substring(0, 3));
            m_GreenColor = int.Parse(m_IsFirstPlayer ? k_ColorFirstPlayer.Substring(5, 3) : k_ColorSecondPlayer.Substring(5, 3));
            m_BlueColor = int.Parse(m_IsFirstPlayer ? k_ColorFirstPlayer.Substring(10, 3) : k_ColorSecondPlayer.Substring(10, 3));
            this.Label_CurrentPlayer.Text = string.Format("Current Player: {0}",
                                                            m_IsFirstPlayer ?
                                                            m_FirstPlayer.Name :
                                                            m_SecondPlayer.Name);
            this.Label_CurrentPlayer.BackColor = Color.FromArgb(m_RedColor, m_GreenColor, m_BlueColor);
        }

        private void Timer_DrawingAndSetCurrentPlayer_Tick(object sender, EventArgs e)
        {
            initializeCellsPanel();
            setCurrentPlayer();
            setAmountOfPoints();
            Timer_DrawingAndSetCurrentPlayer.Stop();
        }

        private void setAmountOfPoints()
        {
            this.Label_FirstPlayer.Text = string.Format(
                                                        "{0}: {1} Pairs",
                                                        this.m_FirstPlayer.Name,
                                                        this.m_FirstPlayer.AmountOfPoints);

            this.Label_SecondPlayer.Text = string.Format(
                                                         "{0}: {1} Pairs",
                                                         this.m_SecondPlayer.Name,
                                                         this.m_SecondPlayer.AmountOfPoints);
        }
    }
}
