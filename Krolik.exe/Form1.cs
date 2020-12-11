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
using System.Collections;

namespace Krolik.exe
{
    public partial class Form1 : Form
    {
        int selforviv = 1;
        int selforwrt = 1;
        bool state1=true;
        List<Hole> holes = new List<Hole>(5);
        public Form1()
        {

            InitializeComponent();
            System.IO.Stream str = Properties.Resources.STALKERtheme;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            button2.Left = 387;
            button2.Top = 255;
            for (int i = 0; i < 5; i++)
            {
                holes.Add(new Hole());
            }
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
        Rabbit.RabbitColor futureRabbitColor;
        bool futureRabbitHasTooManyPaws;
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            futureRabbitColor = Rabbit.RabbitColor.Белый;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            futureRabbitColor = Rabbit.RabbitColor.Серый;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            futureRabbitColor = Rabbit.RabbitColor.Бежевый;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            selectedToWriteLabel.Text = "Нора " + selforwrt;
            selectedToDisplayLabel.Text = "Выбранно для вывода: Нора " + selforviv;
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

            holeDataTextArea.Text = "";
            totalRabbitsInSelectedHole.Text = $"Кроликов уже: {holes[selforviv - 1].Rabbits.Count}/5";
            int i = 0;
            foreach (var item in holes[selforviv - 1].Rabbits)
            {
                i++;
                holeDataTextArea.Text += $"Кролик {i} {item}\r\n";
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            selforwrt++;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            selforwrt--;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            selforviv++;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            selforviv--;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Music_Tick(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (int.TryParse(earsCountTextBox.Text, out int ears))
            {
                System.Diagnostics.Debug.WriteLine("Created");
                holes[selforwrt - 1].AddRabbit(new Rabbit(futureRabbitColor, ears, futureRabbitHasTooManyPaws));
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            futureRabbitHasTooManyPaws = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            futureRabbitHasTooManyPaws = false;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
        }
    }

    public class Hole
    {
        List<Rabbit> rabbits = new List<Rabbit>();
        public bool ReachedMax
        {
            get
            {
                return rabbits.Count >= 5;
            }
        }
        public Rabbit this[int index]
        {
            get
            {
                return rabbits[index];
            }
            set
            {
                rabbits[index] = value;
            }
        }
        public List<Rabbit> Rabbits
        {
            get
            {
                return rabbits;
            }
        }
        public void AddRabbit(Rabbit rabbit) { if (!ReachedMax) { rabbits.Add(rabbit); } }


        public Hole(Rabbit rabbit) => AddRabbit(rabbit);
        public Hole(List<Rabbit> rabbits)
        {
            foreach (var rabbit in rabbits) AddRabbit(rabbit);
        }
        public Hole() { }
    }

    public class Rabbit
    {
        public enum RabbitColor
        {
            Белый,
            Серый,
            Бежевый,
        }

        RabbitColor color;
        int ears;
        bool tooManyPaws;

        public Rabbit(RabbitColor color, int ears, bool tooManyPaws)
        {
            this.color = color;
            this.ears = ears;
            this.tooManyPaws = tooManyPaws;
        }
        public override string ToString()
        {
            return $"Цвет: {color}\r\n\t- Кол-во ушей {ears}\r\n\t-{(tooManyPaws ? "Лишние лапки есть" : "Лишних лапок нет")} ";
        }
    }
}