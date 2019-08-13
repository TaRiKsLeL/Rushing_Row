using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Rushing_Row
{
    public partial class RowForm : Form
    {
        int speed;
        string text;

        Letta l;
        ArrayList myLetters = new ArrayList();
        Letter space = new Letter(Letta.SpaceLetter);

        int[,] allArea = new int[8, 64];

        bool finishFlag = false;
        int letterCounter = 0;
        int columnCounter = 0;
        int spaceCounter=0;

        public RowForm()
        {
            InitializeComponent();
        }

 

        public RowForm(string text, int speed)
        {
            InitializeComponent();
            this.text = text;
            this.speed = speed;
        }

        private void RowForm_Load(object sender, EventArgs e)
        {
            setLabels(tbPanel);
            setLabelsFromArray(allArea, tbPanel);
            printArray(allArea);

            text=text.ToUpper();

            foreach(char letter in text)
            {
                if (letter == 'A')
                {
                    l = Letta.Aletter;
                }
                else if (letter == 'B')
                {
                    l = Letta.Bletter;
                }
                else if (letter == 'C')
                {
                    l = Letta.Cletter;
                }
                else if (letter == 'D')
                {
                    l = Letta.Dletter;
                }
                else if (letter == 'E')
                {
                    l = Letta.Eletter;
                }
                else if (letter == 'R')
                {
                    l = Letta.Rletter;
                }
                else if (letter == 'F')
                {
                    l = Letta.Fletter;
                }
                else if (letter == 'T')
                {
                    l = Letta.Tletter;
                }
                else if (letter == 'S')
                {
                    l = Letta.Sletter;
                }
                else if (letter == 'I')
                {
                    l = Letta.Iletter;
                }
                else if (letter == ' ')
                {
                    l = Letta.SpaceLetter;
                }




                myLetters.Add(new Letter(l));
            }

            timer1.Enabled = true;
            timer1.Interval = speed * 10;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!finishFlag)
            {
                ((Letter)myLetters[letterCounter]).moveAndSetColumn(allArea, columnCounter++);
                setLabelsFromArray(allArea, tbPanel);

                if (columnCounter >= 8)
                {
                    letterCounter++;
                    columnCounter = 0;
                }
                if (letterCounter >= myLetters.Count)
                {
                    letterCounter = 0;
                    finishFlag = true;
                    spaceCounter = 8 - myLetters.Count;
                }
            }
            else
            {
                space.moveAndSetColumn(allArea, columnCounter++);
                setLabelsFromArray(allArea, tbPanel);

                if (columnCounter >= 8)
                {
                    spaceCounter--;
                    columnCounter = 0;
                }
                
                if (spaceCounter <= 0)
                {
                    finishFlag = false;
                }
            }
        }

        void printArray(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int cols = arr.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j]);
                    Console.Write("LELELL");
                }
                Console.WriteLine();
            }

        }
        public void setLabelsFromArray(int[,] array, TableLayoutPanel tableLayoutPanel)
        {
            int rows = array.GetUpperBound(0) + 1;
            int cols = array.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] == 0)
                    {
                        //    tableLayoutPanel.GetControlFromPosition(j, i).BackColor = Color.FromArgb(0, 206, 201);
                        tableLayoutPanel.GetControlFromPosition(j, i).BackColor = Color.Black;

                    }

                    if (array[i, j] == 1)
                    {
                        //  tableLayoutPanel.GetControlFromPosition(j, i).BackColor = Color.FromArgb(255, 97, 69);
                        tableLayoutPanel.GetControlFromPosition(j, i).BackColor = Color.White;

                    }
                }
            }

        }

        void setLabels(TableLayoutPanel tableLayoutPanel)
        {
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel.ColumnCount; j++)
                {
                    Label label = new Label();
                   //label.ImageAlign = ContentAlignment.MiddleLeft;
                    label.Dock = DockStyle.Fill;
                    label.BackColor = Color.FromArgb(0, 206, 201);
                    label.Margin = new Padding(0);
                    tableLayoutPanel.Controls.Add(label, j, i);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void tbPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
