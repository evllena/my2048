using System;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class UserInfoForm : Form
    {
        private User user;

        public UserInfoForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }


        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
        }

        

        private void okButton_Click_1(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                MessageBox.Show("Необходимо ввести имя!");
                return;
            }

            user.Name = userNameTextBox.Text;
            Close();
        }
    }
}
