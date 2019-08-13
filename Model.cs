using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_Row
{
    enum Letta
    {
        Aletter='A',
        Bletter='B',
        Cletter='C',
        Dletter='D',
        Eletter='E',
        Rletter='R',
        Fletter='F',
        Tletter='T',
        Sletter='S',
        Iletter='I',
        SpaceLetter=' '
    }

    class Letter
    {
        public int[,] letter = new int[8,8];

        string[] hexArray = new string[8];

        public Letter(Letta letta)
        {
            setHexArray(letta);

            int rows = letter.GetUpperBound(0) + 1;
            int cols = letter.Length / rows;

            byte[] tempArr = new byte[8];

            for (int i = 0; i < rows; i++)
            {
                tempArr = StringToByteArray(hexArray[i]);
                for (int j = 0; j < cols; j++)
                {
                    letter[i, j] = tempArr[j];
                }
            }
        }

        public void setHexArray(Letta letta)
        {
            switch (letta)
            {
                case Letta.Aletter:
                    {
                       // letter =
                        hexArray[0] = "3f";
                        hexArray[1] = "41";
                        hexArray[2] = "41";
                        hexArray[3] = "7f";
                        hexArray[4] = "41";
                        hexArray[5] = "41";
                        hexArray[6] = "41";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Bletter:
                    {
                        hexArray[0] = "7e";
                        hexArray[1] = "43";
                        hexArray[2] = "43";
                        hexArray[3] = "7e";
                        hexArray[4] = "43";
                        hexArray[5] = "43";
                        hexArray[6] = "7e";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Cletter:
                    {
                        hexArray[0] = "7e";
                        hexArray[1] = "41";
                        hexArray[2] = "40";
                        hexArray[3] = "40";
                        hexArray[4] = "40";
                        hexArray[5] = "41";
                        hexArray[6] = "7e";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Dletter:
                    {
                        hexArray[0] = "7e";
                        hexArray[1] = "41";
                        hexArray[2] = "41";
                        hexArray[3] = "41";
                        hexArray[4] = "41";
                        hexArray[5] = "41";
                        hexArray[6] = "7e";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Eletter:
                    {
                        hexArray[0] = "7f";
                        hexArray[1] = "7f";
                        hexArray[2] = "40";
                        hexArray[3] = "7f";
                        hexArray[4] = "40";
                        hexArray[5] = "7f";
                        hexArray[6] = "7f";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Rletter:
                    {
                        hexArray[0] = "7e";
                        hexArray[1] = "41";
                        hexArray[2] = "41";
                        hexArray[3] = "7e";
                        hexArray[4] = "41";
                        hexArray[5] = "41";
                        hexArray[6] = "41";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Fletter:
                    {
                        hexArray[0] = "7f";
                        hexArray[1] = "08";
                        hexArray[2] = "08";
                        hexArray[3] = "7f";
                        hexArray[4] = "08";
                        hexArray[5] = "08";
                        hexArray[6] = "08";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Tletter:
                    {
                        hexArray[0] = "7f";
                        hexArray[1] = "08";
                        hexArray[2] = "08";
                        hexArray[3] = "08";
                        hexArray[4] = "08";
                        hexArray[5] = "08";
                        hexArray[6] = "08";
                        hexArray[7] = "00";
                        break;
                    }
                case Letta.Sletter:
                    {
                        hexArray[0] = "7f";
                        hexArray[1] = "41";
                        hexArray[2] = "40";
                        hexArray[3] = "7f";
                        hexArray[4] = "01";
                        hexArray[5] = "41";
                        hexArray[6] = "7f";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.Iletter:
                    {
                        hexArray[0] = "08";
                        hexArray[1] = "08";
                        hexArray[2] = "08";
                        hexArray[3] = "08";
                        hexArray[4] = "08";
                        hexArray[5] = "08";
                        hexArray[6] = "08";
                        hexArray[7] = "00";
                        break;
                    }

                case Letta.SpaceLetter:
                    {
                        hexArray[0] = "00";
                        hexArray[1] = "00";
                        hexArray[2] = "00";
                        hexArray[3] = "00";
                        hexArray[4] = "00";
                        hexArray[5] = "00";
                        hexArray[6] = "00";
                        hexArray[7] = "00";
                        break;
                    }
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            if (hex == "08")
            {
                Console.WriteLine("kek");
            }

            byte []res=new byte[8];
            int k = 0;

            byte []tempByte = Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();

            string binary = Convert.ToString(tempByte[0], 2);

            if (binary.Length <= 4)
            {
                int kek = 8-binary.Length-1;
                string newBinary="";

                while (kek!=0)
                {
                    kek--;
                    newBinary += "0";
                    
                }
                newBinary += binary;
                binary = newBinary;
            }

            foreach(char c in binary)
            {
                if (c == '0')
                {
                    res[k++] = 0;
                }
                else
                {
                    res[k++] = 1;
                }
            }

            return res;
        }

        public void moveAndSetColumn(int[,] area,int column)
        {
            int rows = area.GetUpperBound(0) + 1;
            int cols = area.Length / rows;
            int j;

            for (int i = 0; i < rows; i++)
            {
                

                for (j = 0; j < cols-1; j++)
                {
                   area[i, j] = area[i, j + 1];
                    if (j == cols-2)
                    {
                        area[i, cols - 1] = 0;
                        area[i, cols - 1] = area[i, cols - 1] | letter[i, column];
                    }
                }
                
                
            }

          //  for (int i = 0; i < rows; i++)
            //{
                
            //}

        }

    }
    class Model
    {
    }
}
