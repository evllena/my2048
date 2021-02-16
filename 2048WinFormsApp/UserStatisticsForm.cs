using System;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class UserStatisticsForm : Form
    {

        User bestUser = UserResultsStorage.GetBestUser();
        public UserStatisticsForm()
        {
            InitializeComponent();
            bestLabel.Text = bestUser.Name + " " + bestUser.Score;
            var results = UserResultsStorage.GetAll();

            foreach (var result in results)
            {
                dataGridView1.Rows.Add(result.Name, result.Score);
                
            }
        }
        
        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            
        }

        private void closeWindowButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
