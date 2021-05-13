using System;
using System.Text;
using System.IO;
namespace HafManFinish
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = 'c';
            Console.WriteLine((char)97);
            //   Console.WriteLine((int)c);
            string path = @"C:\Users\Александр\source\repos\HafManFinish\test.txt";
            string path2 = @"C:\Users\Александр\source\repos\HafManFinish\test2.txt";
            string test = "SUSsda sada sda ";
            //Console.WriteLine(Convert.ToInt32("11111111",2));
            //Console.WriteLine((char)255);
            //Console.WriteLine("sadasd".Substring(0,3));
            string s = Convert.ToString((int)'7', 2);
            while (s.Length < 8)
            {
                s= "0" + s;
            }
            int a= 110111;
          //  Console.WriteLine((char)Convert.ToInt32("110111",2));

            //  Console.WriteLine(s);
            //     Console.WriteLine(Convert.ToInt32("(char)7",2));
            HuffmanOperator huffmanOperator = new HuffmanOperator("aaaaabbbbb");
            //Console.WriteLine(huffmanOperator.Encode("aaaaabbbbb"));
            
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {
                   sw.Write(huffmanOperator.Encode("aaaaabbbbb"));
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //using (FileStream fstream = new FileStream($"{path}", FileMode.Open))
            //    {
            //        byte[] a = huffmanOperator.getBytedMsg();
            //        fstream.Position = fstream.Seek(0, SeekOrigin.End);


            //        fstream.Write(a, 0, a.Length);
            //        Console.WriteLine("Текст записан в файл");
            //    }
            string temp = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    temp = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           // Console.WriteLine(temp);
            //try
            //{
                using (StreamWriter sw = new StreamWriter(path2, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(huffmanOperator.Decode(temp));
                }
                Console.WriteLine("Запись выполнена");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}


            //    string temp="";
            //    try
            //    {
            //        using (StreamReader sr = new StreamReader(path))
            //        {
            //            temp = sr.ReadToEnd();
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    Console.WriteLine(temp);


            //    try
            //    {
            //        using (StreamWriter sw = new StreamWriter(path2, false, System.Text.Encoding.Default))
            //        {
            //            sw.WriteLine(huffmanOperator.extract(temp, huffmanOperator.GetHuffmantree().encodingArray));
            //        }
            //        Console.WriteLine("Запись выполнена");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}
        }
    }
}
