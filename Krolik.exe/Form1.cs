using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Krolik.exe
{
    public partial class Form1 : Form
    {
        int krol = 0;
        int selforviv = 1;
        int selforwrt = 1;
        bool state1=true;
        int[,,] mass = new int[5, 5, 5];
        int[,,] endmass = new int[5, 5, 5];
        bool[,] config = new bool[5, 5];
        int[] perenoska_dlya_koshek = new int[5];
        SoundPlayer player = new SoundPlayer("STALKERtheme.wav");
        public Form1()
        {
            InitializeComponent();
            player.PlayLooping();
            button2.Left = 387;
            button2.Top = 255;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            mass[0, selforviv - 1, 0] = 1;//белый
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            mass[0, selforviv - 1, 0] = 2;//серый
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            mass[0, selforviv-1, 0] = 3;//бежевый
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel4.Text = "Нора " + selforviv;
            toolStripLabel5.Text = "Выбранно для вывода: Нора " + selforwrt;
            if (selforviv < 1)
            {
                selforviv = 1;
            }
            if (selforwrt < 1)
            {
                selforwrt = 1;
            }

            if (selforviv > 5)
            {
                selforviv = 5;
            }
            if (selforwrt > 5)
            {
                selforwrt = 5;
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (config[krol + 1, selforwrt + 1] == true)
            {
                selforviv++;
            } else
            {
                krol = perenoska_dlya_koshek[selforwrt++];
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (config[krol-1, selforwrt-1] == true)
            {
                selforviv--;
            } else
            {
                krol = perenoska_dlya_koshek[selforwrt--];
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            selforwrt++;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            selforwrt--;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            mass[1, selforviv - 1, 0] = Convert.ToInt32(toolStripTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Music_Tick(object sender, EventArgs e)
        {
            player.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (state1 == true)
            {
                player.Stop();

            } else
            {
                player.PlayLooping();
            }
            state1 = !state1;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            config[krol, selforwrt] = true;
            endmass[0, selforviv - 1, 0] = mass[0, selforviv - 1, 0];
            endmass[1, selforviv - 1, 0] = mass[1, selforviv - 1, 0];
            endmass[2, selforviv - 1, 0] = mass[2, selforviv - 1, 0];
            if (krol >= 4)
            {
                textBox1.Text = "Нора переполнена. Выберите следующую нору!";
            }
            else
            {
                krol++;
            }
            if (endmass[0, selforviv - 1, 0] == 1)
            {
                textBox1.Text = "Нора " + selforwrt + ", Кролик " + krol + "\r\n    - Белый" + "\r\n    - Кол-во ушей " + endmass[1, selforviv - 1, 0] + "\r\n    - Лишние лапки " + endmass[2, selforviv - 1, 0] + " | 1 - есть, 0 - нет";
            }
            else if (endmass[0, selforviv - 1, 0] == 2)
            {
                textBox1.Text = "Нора " + selforwrt + ", Кролик " + krol + "\r\n    - Серый" + "\r\n    - Кол-во ушей " + endmass[1, selforviv - 1, 0] + "\r\n    - Лишние лапки " + endmass[2, selforviv - 1, 0] + " | 1 - есть, 0 - нет";
            }
            else if (endmass[0, selforviv - 1, 0] == 3)
            {
                textBox1.Text = "Нора " + selforwrt + ", Кролик " + krol + "\r\n    - Бежевый" + "\r\n    - Кол-во ушей " + endmass[1, selforviv - 1, 0] + "\r\n    - Лишние лапки " + endmass[2, selforviv - 1, 0] + " | 1 - есть, 0 - нет";
            }
            else
            {

            }
            toolStripLabel7.Text = "Кроликов уже:" + (krol) + "/5";
            perenoska_dlya_koshek[selforwrt] = krol;

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            mass[2, 0, 0] = 1;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            mass[2, 0, 0] = 0;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (config[krol, selforwrt] == true)
            {
                if (endmass[0, 0, 0] == 1)
                {
                    textBox1.Text = "Нора " + (selforwrt - 1) + ", Кролик " + krol + "\r\n    - Белый" + "\r\n    - Кол-во ушей " + endmass[1, selforwrt - 1, 0] + "\r\n    - Лишние лапки " + endmass[2, selforwrt - 1, 0] + " | 1 - есть, 0 - нет";
                }
                else if (endmass[0, 0, 0] == 1)
                {
                    textBox1.Text = "Нора " + (selforwrt - 1) + ", Кролик " + krol + "\r\n    - Серый" + "\r\n    - Кол-во ушей " + endmass[1, selforwrt - 1, 0] + "\r\n    - Лишние лапки " + endmass[2, selforwrt - 1, 0] + " | 1 - есть, 0 - нет";
                }
                else if (endmass[0, 0, 0] == 1)
                {
                    textBox1.Text = "Нора " + (selforwrt - 1) + ", Кролик " + krol + "\r\n    - Бежевый" + "\r\n    - Кол-во ушей " + endmass[1, selforwrt - 1, 0] + "\r\n    - Лишние лапки " + endmass[2, selforwrt - 1, 0] + " | 1 - есть, 0 - нет";
                }
                else
                {
                    krol++;
                }
            } else
            {
                textBox1.Text = "Нора " + selforwrt + ", Кролик " + krol + "\r\nЭта нора ещё не сконфигурирована!";
            }
        }
    }
}