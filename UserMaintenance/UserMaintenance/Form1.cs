using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();


        public Form1()
        {
            InitializeComponent();
            LastNamelabel.Text = Resource1.LastName;
            FirstNamelabel.Text = Resource1.FirstName;
            Addbutton.Text = Resource1.Add;
            button1.Text = Resource1.File;

            //listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text + ' ' + textBox2.Text
            };
            users.Add(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save";
            sfd.FileName = "Nevek.txt";
            sfd.Filter = "Text File | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr =new  StreamWriter(sfd.OpenFile());
                for (int i=0; i< users.Count; i++)
                {
                    sr.WriteLine(users[i].ID.ToString());
                    sr.WriteLine(users[i].FullName.ToString());
                }

                sr.Dispose();
                sr.Close();
            }
        }
    }
}
