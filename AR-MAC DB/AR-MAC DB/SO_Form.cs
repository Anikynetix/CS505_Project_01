﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AR_MAC_DB
{
    public partial class soForm : Form
    {
        public soForm(User user)
        {
            InitializeComponent();
            welcomeLabel.Text = "Welcome, " + user.fname + " " + user.lname + "!";
        }

        public void listUsers()
        {
            try
            {
                StreamReader file = new StreamReader("user.db");
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    listUsersListBox.Items.Add(line);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found!!!");
            }

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm form = new loginForm();
            form.Show();
        }

        private void listUsersButton_Click(object sender, EventArgs e)
        {
            listUsers();
        }

        public void addUser(User uobject)
        {
            try
            {

                StreamWriter file = new StreamWriter("user.db", true);
                string line = uobject.fname + "\t" + uobject.lname + "\t" + uobject.uid + "\t" + uobject.pwd + "\t" + uobject.perm;
                file.WriteLine(line);
                file.Close();

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found!!");
            }

        }

    }
}