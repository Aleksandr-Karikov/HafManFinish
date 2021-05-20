using System;
using System.Text;
using System.IO;
namespace HafManFinish
{
    class Program
    {
        static void Main(string[] args)
        {
;
            string path = @"C:\Users\Александр\source\repos\HafManFinish\test.txt";
            string path2 = @"C:\Users\Александр\source\repos\HafManFinish\test2.txt";
            string path3 = @"C:\Users\Александр\source\repos\HafManFinish\test3.txt";
            string Start = "";
            try
            {
                using (StreamReader sr = new StreamReader(path3))
                {
                    Start = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            HuffmanOperator huffmanOperator = new HuffmanOperator(Start);

            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(ShortHafTree.shorttree(huffmanOperator.GetTree().getTree().getRoot()));
                    //sw.Write(huffmanOperator.Encode(Start));
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            huffmanOperator.Encode(path3,path);
            huffmanOperator.Decode(path, path2);
        }
    }
}