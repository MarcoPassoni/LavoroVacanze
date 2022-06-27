using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; //per Drag form
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
namespace Lavoro_con_Alex
{
    public partial class Form1 : Form
    {
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentForm;

        public Form1()
        {
            InitializeComponent();
            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(7, 75);
            panelMenu.Controls.Add(leftBorderButton);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        public struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ButtonClick(object sender, Color color)
        {
            if (sender != null)
            {
                BottoneDisabilitato();
                currentButton = (IconButton)sender;
                currentButton.BackColor = Color.FromArgb(37, 36, 81);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderButton.BackColor = color;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();
                icon.IconChar = currentButton.IconChar;
                icon.IconColor = color;
            }
        }
        private void BottoneDisabilitato()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(31, 30, 68);
                currentButton.ForeColor = Color.LightSteelBlue;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.LightSteelBlue;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void aperto(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(form);
            panelDesktop.Tag = form;
            form.BringToFront();
            form.Show();
            label1.Text = form.Text;

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ButtonClick(sender, RGBcolors.color1);
            //aperto(new FormDashbord());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ButtonClick(sender, RGBcolors.color2);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ButtonClick(sender, RGBcolors.color3);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ButtonClick(sender, RGBcolors.color4);
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            BottoneDisabilitato();
            leftBorderButton.Visible = false;
            icon.IconChar = IconChar.Home;
            icon.IconColor = Color.DarkSlateBlue;
            label1.Text = "Home";
        }
        //drag form (linea di codice copiata e incollata da tutorial, serve per spostare la finestra tramite il banner del titolo)
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitolo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); 
        }
    }
}
