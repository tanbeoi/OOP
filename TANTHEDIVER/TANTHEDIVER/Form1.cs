using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TANTHEDIVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            BG.Controls.Add(Player);
            Player.Location = new Point(400, 300);
            Player.BackColor = Color.Transparent;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mainGameTimer(object sender, EventArgs e)
        {
    /*        if (BG.Location.X > -10 - BG.Width / 2 ) //to check if background image is about to go out of screen
            {
                BG.Location = new Point(-10 + BG.Width /2 , -40); // pic box is set to the new point. here -10 is indicate of X coordinate.
            }
            else
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 100, pictureBox1.Location.Y); // to move picture box from x coordinate by 100 Point.
            }*/


        }

        private void repeat_x ()
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

        }

        private void keyisup(object sender, KeyEventArgs e)
        {

        }
    }
}
