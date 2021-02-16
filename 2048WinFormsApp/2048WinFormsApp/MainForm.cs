using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {

        public int mapSize;
        private User user;
        
        private Label [,] labelsMap;
        private static Random random = new Random();
        private int score = 0;
        
        private User bestUser;
        bool isMerged = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            user = new User("Unknown");
            var userInfoForm = new UserInfoForm(user);
            var result = userInfoForm.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                Close();
            }
            else
            {
                var mapSizeForm = new MapSizeForm();
                var rslt = mapSizeForm.ShowDialog(this);
                if (rslt != DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {

                    mapSize = MapSizeForm.GetMapSize();
                    DefineClientSize();

                    InitMap();
                    GenerateNumber();
                    bestUser = UserResultsStorage.GetBestUser();
                    ShowScores();
                }
            }
           
            
        }

        private void DefineClientSize()
        {
            
                ClientSize = new Size((14 + 76 * mapSize),(74 + 76 * mapSize));
            
        }

        private void InitMap()
        {
            labelsMap = new Label [mapSize,mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel; 
                }
            }
        }

        private void ShowScores()
        {
            scoreLabel.Text = score.ToString();
            bestScoreLabel.Text = bestUser.Score.ToString();
        }

        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                var randomNumber = random.Next(1, 5);
                if (randomNumber < 4)
                {
                    randomNumber = 2;
                }
                if (labelsMap[indexRow, indexColumn].Text == string.Empty)
                {
                    labelsMap[indexRow, indexColumn].Text = randomNumber.ToString();
                    break;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.AppWorkspace;
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70, 70);
           
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + (indexColumn * 76);
            int y = 70 + (indexRow * 76);
            label.Location = new Point(x, y);
            label.TextChanged += Label_TextChanged;
            return label;
        }

        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;
            UpdateLabelBackColor(label);
        }

      

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                return;
            }
            

            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, k].Text == labelsMap[i, j].Text)
                                    {
                                        isMerged = true;
                                        var number = int.Parse(labelsMap[i, k].Text);
                                        score += number * 2;
                                        
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, k].Text = string.Empty;
                                        
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {

                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, k].Text == labelsMap[i, j].Text)
                                    {
                                        isMerged = true;
                                        var number = int.Parse(labelsMap[i, k].Text);
                                        score += number * 2;
                                        
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, k].Text = string.Empty;
                                        
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {

                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < mapSize; j++)
                {

                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    if (labelsMap[k, j].Text == labelsMap[i, j].Text)
                                    {
                                        isMerged = true;
                                        var number = int.Parse(labelsMap[k, j].Text);
                                        score += number * 2;
                                        
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[k, j].Text = string.Empty;
                                        
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {

                                    labelsMap[i, j].Text = labelsMap[k, j].Text;
                                    labelsMap[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {
                                    if (labelsMap[k, j].Text == labelsMap[i, j].Text)
                                    {
                                        isMerged = true;
                                        var number = int.Parse(labelsMap[k, j].Text);
                                        score += number * 2;
                                        
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[k, j].Text = string.Empty;
                                        
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, j].Text != string.Empty)
                                {

                                    labelsMap[i, j].Text = labelsMap[k, j].Text;
                                    labelsMap[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            TryUpdateBestScore();
            ShowScores();
            user.Score = score;
            

            if (IsFullMap() && isMerged || Exists2048())
            {
                UserResultsStorage.Add(user);
                UserResultsStorage.SaveBestUser(bestUser);
                MessageBox.Show(user.Name + ", Вы набрали " + user.Score + " очков. Игра окончена");
                
                var userStatisticsForm = new UserStatisticsForm();
                userStatisticsForm.ShowDialog(this);
                Close();
            }
            GenerateNumber();

        }

        private void TryUpdateBestScore()
        {
           if (score > bestUser.Score)
            {
                bestUser.Score = score;
                bestUser.Name = user.Name;
                
            }
            
        }

        

        private void UpdateLabelBackColor(Label label)
        {
            int exponent = 0;
            if (label.Text == string.Empty)
            {
                exponent = 0; 
            }
            else
            {
                var number = Convert.ToInt32(label.Text);
                exponent =(int)Math.Log(number, 2);
            }
            
            Color[] colors = new Color[12];
            colors[0] = SystemColors.AppWorkspace;
            colors[1] = Color.Wheat;
            colors[2] = Color.LightSalmon;
            colors[3] = Color.RosyBrown;
            colors[4] = Color.Sienna;
            colors[5] = Color.LightSeaGreen;
            colors[6] = Color.LightCoral;
            colors[7] = Color.CadetBlue;
            colors[8] = Color.PaleVioletRed;
            colors[9] = Color.IndianRed;
            colors[10] = Color.MediumAquamarine;
            colors[11] = Color.Crimson;

            label.BackColor = colors[exponent];
        }

        private void gameRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gameRulesForm = new GameRulesForm();
            gameRulesForm.ShowDialog(this);
           
        }

        private bool IsFullMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Exists2048()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == "2048")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void выйтиИзИгрыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserResultsStorage.SaveBestUser(bestUser);

          
        }

        

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userStatisticsForm = new UserStatisticsForm();
            userStatisticsForm.ShowDialog(this);
        }
    }
}
