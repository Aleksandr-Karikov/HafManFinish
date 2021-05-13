using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HafManFinish
{
    class HuffmanOperator
    {
        private HuffmanTree tree;
        private String[] encodingArray;
        public HuffmanOperator(string mes)
        {
            tree = new HuffmanTree(mes);
            encodingArray = tree.getEncodingArray();
        }
        public string Encode(string s)
        {
            string output="";
            string temp = "";
            for (int i =0;i<s.Length;i++)
            {
                temp += encodingArray[(int)s[i]];
            }
            Console.WriteLine(temp);
            for (int i = 0; i < temp.Length; i = i+ 8) 
            {
                // Console.WriteLine(temp.Substring(i, 8));
                try
                {
                    output += (char)Convert.ToInt32(temp.Substring(i, 8), 2);
                }
                catch(Exception)
                {

                }
            }
            int count=0;
            for (int i = temp.Length/8 * 8; i<= temp.Length; i++)
            {
                count++;
            }
            for (int i=count;i<=8;i++)
            {
                temp += '0';
            }
            output += (char)Convert.ToInt32(temp.Substring(temp.Length -8, 8), 2);
            Console.WriteLine(count);
            output += Convert.ToString(8-count);
             return output;
        }
        public string Decode(string input)
        {
            tree.displayEncodingArray();
            string output = "";
            string inp=input;
            Console.WriteLine();
            Console.WriteLine(inp[inp.Length - 1]);
            int zero = Convert.ToInt32((int)inp[inp.Length - 1] - '0');
            inp = input.Remove(inp.Length - 1);
            //input = input.Substring(1, input.Length-1);
            string temp = "";
            for (int i = 0; i < inp.Length; i++)
            {
    //            Console.WriteLine((int)inp[i]);
                temp += Convert.ToString((int)inp[i], 2);
                for (int c =temp.Length;c<8;c++)
                {
                    temp = '0' + temp;
                }
            }
            temp =temp.Remove(temp.Length - zero - 1);
            int end = 0;
            while (temp!="")
            {
                
                for (int j = 0; j < 255; j++)
                {
                    if (encodingArray[j] == temp.Substring(0, end))
                    {
                        Console.WriteLine((char)Convert.ToInt32(encodingArray[j], 2));
                        output += (char)j;
                        temp = temp.Substring(end, temp.Length-end);
                        end = 0;
                        break;
                    }
                }
                end++;
            }
            return output;
        }
    }

}
