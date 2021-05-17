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
            string output = "";
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                temp += encodingArray[(int)s[i]];
            }
            //Console.WriteLine(temp);
            for (int i = 0; i < temp.Length; i = i + 8)
            {
                // Console.WriteLine(temp.Substring(i, 8));
                try
                {
                    output += (char)Convert.ToInt32(temp.Substring(i, 8), 2);
                }
                catch (Exception)
                {

                }
            }
            int count = 0;
            for (int i = temp.Length / 8 * 8; i < temp.Length; i++)
            {
                count++;
            }
            if (count != 0)
            {
                for (int i = count; i < 8; i++)
                {
                    temp += '0';
                }
                output += (char)Convert.ToInt32(temp.Substring(temp.Length - 8, 8), 2);
            }
           
            //Console.WriteLine(count);
            if (count ==0)
            {
                output += Convert.ToString(0);
            }else
            output += Convert.ToString(8 - count);
            return output;
        }
        public string Decode(string input)
        {
            String []EncodingArray = new string[143859];
            String tr="";
            string inp = input;
            int k = 0;
            while(inp[k]!=' ' || inp [k+1]!='\r')
            {
                tr += inp[k];
                k++;
            }
            k++;
            inp = inp.Remove(0,k+2);
            EncodingArray = ShortHafTree.getEncod(ShortHafTree.getHuftree(tr));
            string output = "";
          //  Console.WriteLine();
           // Console.WriteLine(inp[inp.Length - 1]);
            int zero = Convert.ToInt32((int)inp[inp.Length - 1] - '0');
            inp = inp.Remove(inp.Length - 1);
            string temp = "";
            string temp2 = "";
            for (int i = 0; i < inp.Length; i++)
            {
                temp2 += Convert.ToString((int)inp[i], 2);
                for (int c = temp2.Length; c < 8; c++)     
                {
                    temp2 = '0' + temp2;         
                }
                temp += temp2;
                temp2 = "";
            }
             if (zero!=0) 
            temp = temp.Remove(temp.Length - zero); 
            int end = 0; 
            while (temp != "")
            {

                for (int j = 0; j < 143859; j++)
                {
                    if (EncodingArray[j] == temp.Substring(0, end))
                    {
                    //    Console.WriteLine((char)Convert.ToInt32(EncodingArray[j], 2));
                        output += (char)j;
                        temp = temp.Substring(end, temp.Length - end);
                        end = 0;
                        break;
                    }
                }
                end++;
            }
            return output;
        }
        public HuffmanTree GetTree()
        {
            return tree;
        }
    }

}