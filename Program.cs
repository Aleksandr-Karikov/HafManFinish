using System;
using System.Text;
using System.IO;
namespace HafManFinish
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding c = Encoding.ASCII;
            string path = @"C:\Users\Александр\source\repos\HafManFinish\test.txt";
            byte[] a = new byte[0];
            a = c.GetBytes("k");
            Console.WriteLine(Convert.ToString(a[0]));
            using (FileStream fstream = new FileStream($"{path}", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes("0101");
                // запись массива байтов в файл
                //string text = "AAA";
              //  fstream.WriteByte(101);
                byte[] t = System.Text.Encoding.Default.GetBytes("e");
                Console.WriteLine(Convert.ToString(t[0], 2));

                fstream.WriteByte(101);
                Console.WriteLine("Текст записан в файл");
            }
        }
    }
}
