using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HafManFinish
{
    class HuffmanOperator
    {
        private HuffmanTree tree;
        private Dictionary<char, string> encoding = new Dictionary<char, string>();
        public HuffmanOperator(StreamReader read)
        {
            tree = new HuffmanTree(read);
            encoding = tree.GetEncoding();
        }
        public HuffmanOperator()
        {
        }
            public void Encode(string path1, string path2)
        {
            int lenghtCode = 0;
            int zero;
            Dictionary<char, int> ArrayFrequence = tree.getFrequenceArray(); 
            foreach (KeyValuePair<char, string> keyValue in encoding)
            {
                lenghtCode += (ArrayFrequence[keyValue.Key] * keyValue.Value.Length);
            }
            if ((zero = 8 - (lenghtCode % 8)) == 8)
            {
                zero = 0;
            }

            StringBuilder sb = new StringBuilder();
            if (zero != 0)
            {
                for (int i = 0; i < zero; i++)
                {
                    sb.Append("0");
                }
            }
            try
            {
                using (StreamReader sr = new StreamReader(path1))
                {
                using (FileStream fstreamWriter = new FileStream(path2, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(Convert.ToString(zero));
                    fstreamWriter.Seek(0, SeekOrigin.End);
                    fstreamWriter.Write(array, 0, array.Length);

                    while (sr.Peek() >= 0)
                    {
                        while (sb.Length < 8)
                        {
                            int b = sr.Read();
                            char a = (char)b;
                            sb.Append(encoding[a]);
                        }

                        string temp =Convert.ToString((char)Convert.ToInt32(sb.ToString(0, 8), 2));
                        sb.Remove(0, 8);
                        array = System.Text.Encoding.Default.GetBytes(Convert.ToString(temp));
                        fstreamWriter.Write(array, 0, array.Length);
                    }

                }
            }
        }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        
        public void Decode(string path1, string path2)
        {
            Dictionary<string, char> decoding = new Dictionary<string, char>();
            StringBuilder sb = new StringBuilder();
            StringBuilder temp = new StringBuilder();
            StringBuilder zeros= new StringBuilder();
            using (StreamReader sr = new StreamReader(path1))
            {
                using (StreamWriter sw = new StreamWriter(path2, false, System.Text.Encoding.UTF8))
                {
                    decoding = ShortHafTree.getDecod(ShortHafTree.getTree(sr));
                    int zero = sr.Read() - '0';
                    int peak = sr.Peek();
                    int end = 0;
                    zeros.Append(Convert.ToString(sr.Read(), 2)); 
                    for (int i = zeros.Length; i < 8 - zero; i++)
                    {
                        zeros.Insert(0,'0');
                    }
                    sb.Append(zeros);
                    zeros.Remove(0,zeros.Length);
                    while (sr.Peek() >= 0)
                    {
                        zeros.Append(Convert.ToString(sr.Read(), 2));
                        for (int i = zeros.Length; i < 8; i++)
                        {
                            zeros.Insert(0, '0');
                        }
                        sb.Append(zeros);
                        zeros.Remove(0, zeros.Length);
                        bool code = false;
                        while (true)
                        {
                            while (!(code = decoding.Keys.Contains(temp.ToString())) && end < sb.Length)
                            {
                                temp.Append(sb.ToString(end, 1));
                                end++;
                            }
                            if (code)
                            {
                                sw.Write(decoding[temp.ToString()]);
                                temp.Remove(0, temp.Length);
                                sb.Remove(0, end);
                                end = 0;

                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                
            }
        }
            public HuffmanTree GetTree()
            {
                return tree;
            }
    }

}