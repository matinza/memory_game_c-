namespace C22_EX05
{
    using System;
    using System.Windows.Forms;
    using C22_EX05_Matan_204597082_Oleg_319274874;

    internal class SettingsForm : Form
    {
        // Forms
        // $G$ CSS-999 (-6) Bad labels names, you should have choose a meaningful name, what exactly is "label1/2/3" ??
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TextBox_FirstPlayer;
        private TextBox TextBox_SecondPlayer;
        private Button Button_ChangeAgainstPlayerOrComputer;
        private Button Button_ChangeBoardSize;
        private Button Button_StartGame;

        public SettingsForm()
        {
            InitializeComponent();
            ShowDialog();
        }

        // $G$ CSS-999 (-3) Private methods should start with a lower-case letter.
        // $G$ DSN-003 (-5) This method is too long, you should have split it into several methods.
        private void InitializeComponent()
        {
            this.Button_ChangeAgainstPlayerOrComputer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_FirstPlayer = new System.Windows.Forms.TextBox();
            this.TextBox_SecondPlayer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_ChangeBoardSize = new System.Windows.Forms.Button();
            this.Button_StartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_ChangeAgainstPlayerOrComputer
            // 
            this.Button_ChangeAgainstPlayerOrComputer.Location = new System.Drawing.Point(406, 84);
            this.Button_ChangeAgainstPlayerOrComputer.Name = "Button_ChangeAgainstPlayerOrComputer";
            this.Button_ChangeAgainstPlayerOrComputer.Size = new System.Drawing.Size(154, 33);
            this.Button_ChangeAgainstPlayerOrComputer.TabIndex = 0;
            this.Button_ChangeAgainstPlayerOrComputer.Text = "Against a Friend";
            this.Button_ChangeAgainstPlayerOrComputer.UseVisualStyleBackColor = true;
            this.Button_ChangeAgainstPlayerOrComputer.Click += new System.EventHandler(this.Button_AgainstPlayerOrComputer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Second Player Name:";
            // 
            // TextBox_FirstPlayer
            // 
            this.TextBox_FirstPlayer.Location = new System.Drawing.Point(215, 34);
            this.TextBox_FirstPlayer.Name = "TextBox_FirstPlayer";
            this.TextBox_FirstPlayer.Size = new System.Drawing.Size(162, 26);
            this.TextBox_FirstPlayer.TabIndex = 3;
            // 
            // TextBox_SecondPlayer
            // 
            this.TextBox_SecondPlayer.Enabled = false;
            this.TextBox_SecondPlayer.Location = new System.Drawing.Point(215, 84);
            this.TextBox_SecondPlayer.Name = "TextBox_SecondPlayer";
            this.TextBox_SecondPlayer.Size = new System.Drawing.Size(162, 26);
            this.TextBox_SecondPlayer.TabIndex = 4;
            this.TextBox_SecondPlayer.Text = "computer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Board Size:";
            // 
            // Button_ChangeBoardSize
            // 
            this.Button_ChangeBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Button_ChangeBoardSize.Location = new System.Drawing.Point(56, 162);
            this.Button_ChangeBoardSize.Name = "Button_ChangeBoardSize";
            this.Button_ChangeBoardSize.Size = new System.Drawing.Size(153, 99);
            this.Button_ChangeBoardSize.TabIndex = 6;
            this.Button_ChangeBoardSize.Text = "4 X 4";
            this.Button_ChangeBoardSize.UseVisualStyleBackColor = false;
            this.Button_ChangeBoardSize.Click += new System.EventHandler(this.Button_ChangeBoardSize_Click);
            // 
            // Button_StartGame
            // 
            this.Button_StartGame.BackColor = System.Drawing.Color.LimeGreen;
            this.Button_StartGame.Location = new System.Drawing.Point(444, 225);
            this.Button_StartGame.Name = "Button_StartGame";
            this.Button_StartGame.Size = new System.Drawing.Size(116, 36);
            this.Button_StartGame.TabIndex = 7;
            this.Button_StartGame.Text = "Start!";
            this.Button_StartGame.UseVisualStyleBackColor = false;
            this.Button_StartGame.Click += new System.EventHandler(this.Button_StartGame_Click);
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(602, 298);
            this.Controls.Add(this.Button_StartGame);
            this.Controls.Add(this.Button_ChangeBoardSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox_SecondPlayer);
            this.Controls.Add(this.TextBox_FirstPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_ChangeAgainstPlayerOrComputer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "MemoryGame - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // $G$ CSS-999 (-3) Private methods should start with a lower-case letter.
        private void Button_AgainstPlayerOrComputer_Click(object sender, EventArgs e)
        {
            TextBox_SecondPlayer.Enabled = !TextBox_SecondPlayer.Enabled;
            Button_ChangeAgainstPlayerOrComputer.Text = "Against a Computer";
            if (!TextBox_SecondPlayer.Enabled)
            {
                TextBox_SecondPlayer.Text = "computer";
                Button_ChangeAgainstPlayerOrComputer.Text = "Against a Friend";
            }
        }

        // $G$ CSS-999 (-3) Private methods should start with a lower-case letter.
        private void Button_ChangeBoardSize_Click(object sender, EventArgs e)
        {
            Button_ChangeBoardSize.Text = BoardSize.GetNextSize();
        }

        // $G$ CSS-999 (-3) Private methods should start with a lower-case letter.
        private void Button_StartGame_Click(object sender, EventArgs e)
        {
            if (this.TextBox_FirstPlayer.Text == string.Empty || this.TextBox_SecondPlayer.Text == string.Empty)
            {
                MessageBox.Show("You need to fill all the names!", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                this.Hide();
                new MemoryGameForm(
                                   this.Button_ChangeBoardSize.Text,
                                   this.TextBox_FirstPlayer,
                                   this.TextBox_SecondPlayer,
                                   !this.TextBox_SecondPlayer.Enabled);                
            }
        }
    }
}
