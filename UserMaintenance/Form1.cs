using System.ComponentModel;


namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFirstName.Text = Resource1.LastName; // label1
           // lblFirstName.Text = Resource1.FirstName; // label2
            btnAdd.Text = Resource1.Add; // button1

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,
              //  FirstName = txtFirstName.Text,
            };
            users.Add(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false))
            {
                foreach (User item in users)
                {
                    sw.WriteLine(item.FullName+";"+item.ID);   
                }
            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach  (User item in users)
            {
                users.Remove(item);
            }
        }
    }
}