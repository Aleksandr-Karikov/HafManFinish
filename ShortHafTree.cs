using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HafManFinish
{
    static class ShortHafTree
    {
        static string output="";
        static public string shorttree(Node node)
        {
            if (node.isLeaf())
            {
                output += '1';
                output +=node.getLetter();
            }
            else
            {
                output += "0";
                shorttree(node.getLeftChild());
                shorttree(node.getRightChild());
            }
            return output;
        }

        private static Node getHuftree(Node head, StreamReader streamRead)
        {
            Node newLeftBranch = new Node();
            Node newRightBranch = new Node();
            if ((Convert.ToChar(streamRead.Read())) == '0')
            {
                head.SetLeftChild(newLeftBranch);
                getHuftree(head.getLeftChild(), streamRead);
                head.SetRightChild(newRightBranch);
                getHuftree(head.getRightChild(), streamRead);
            }
            else
            {
                head.SetLetter(Convert.ToChar(streamRead.Read()));
            }
            return head;
        }
        public static BinaryTree getTree(StreamReader reader)
        {
            BinaryTree tree = new BinaryTree();
            tree.setRoot(getHuftree(tree.getRoot(), reader));
            return tree;

        }
        static private Dictionary<string, char> decode = new Dictionary<string, char>();
        static void fillDencoding(Node node, string code)
        {
            if (node.isLeaf())
            {
                if (code == "")
                {
                    decode.Add("1", node.getLetter());
                }
                else { decode.Add(code, node.getLetter()); }

            }
            else
            {
                fillDencoding(node.getLeftChild(), code + "0");
                fillDencoding(node.getRightChild(), code + "1");
            }
        }
        public static Dictionary<string, char> getDecod(BinaryTree tree)
        {
            //Dictionary<string, char> dencoding = new Dictionary<string, char>();
            //Node c = tree.getRoot();
            fillDencoding(tree.getRoot(), "");
            //Console.WriteLine("======================Encoding table====================");
            //foreach (KeyValuePair<string, char> keyValue in decode)
            //{
            //    // keyValue.Value представляет класс Person
            //    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            //}
            //Console.WriteLine("========================================================");
            return decode;
        }

        //static public void displayDencodingArray()
        //{//для отладки
        // // fillEncodingArray(haftree.getRoot(), "");

        //    Console.WriteLine("======================Encoding table====================");
        //    foreach (KeyValuePair<string, char> keyValue in decode)
        //    {
        //        // keyValue.Value представляет класс Person
        //        Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
        //    }
        //    Console.WriteLine("========================================================");
        //}
    }
}
