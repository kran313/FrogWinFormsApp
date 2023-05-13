using System;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int indicator = 40;

        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPicture)
        {
            var distance = (clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (Math.Abs(distance) > 2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                var location = clickedPicture.Location;

                clickedPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                stepCountLabel.Text = (int.Parse(stepCountLabel.Text) + 1).ToString();

                if (clickedPicture.Name.Contains("left") && distance < 0 ||
                    clickedPicture.Name.Contains("right") && distance > 0)
                {
                    indicator -= Math.Abs(distance);
                }
                else
                {
                    indicator += Math.Abs(distance);
                }

                if (indicator == 0)
                {
                    if (stepCountLabel.Text == "24")
                    {
                        MessageBox.Show("Победа! Вы сделали оптимальное количество ходов.");
                    }
                    else
                    {
                        MessageBox.Show("Победа! Но можно и за меньшее количество ходов.");
                    }
                    Application.Restart();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цель игры - расположить лягушек, которые смотрят влево, в левую часть, а остальных - в правую часть за минимальное количество перепрыгиваний.\nПрыгать можно на листок, если он находится рядом или через 1 лягушку");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
