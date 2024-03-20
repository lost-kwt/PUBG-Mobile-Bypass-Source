using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using KeyAuth;*/
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PM_BYPASS
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; 
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

/*        public static api KeyAuthApp = new api(
            name: "",
            ownerid: "",
            secret: "",
            version: "1.0"
        );*/

        private void Form1_Load(object sender, EventArgs e)
        {
            /*KeyAuthApp.init();*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "PMBYPASS")
            {
                Form2 Main = new Form2();
                // KeyAuthApp.license(textBox1.Text);
                // if (KeyAuthApp.response.success)
                // {
                this.Hide();
                Main.Show();
                // }
                // else
                // {
                //     Thread.Sleep(2000);
                //     Application.Exit(); 
                // }
            }
            else
            {
                MessageBox.Show("Obtain the Key by Clicking the GET KEY Button", "Wrong KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            /* Process.Start("https://t.me/");*/
            MessageBox.Show("KEY:  PMBYPASS", "KEY İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
   
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }
   
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursor = Cursor.Position;
                this.Location = new Point(
                    lastForm.X + (currentCursor.X - lastCursor.X),
                    lastForm.Y + (currentCursor.Y - lastCursor.Y)
                );
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
