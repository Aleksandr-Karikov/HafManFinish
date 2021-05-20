using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HafManFinish
{
    class HuffmanTree
    {
        BinaryTree haftree;
        private Dictionary<char, string> encode = new Dictionary<char, string>();
        private Dictionary<char, int> ArrayFrequence = new Dictionary<char, int>();
        public HuffmanTree(StreamReader read)
        {
            fillArrayFrequence(read);
            haftree = getHuffmanTree();
            fillEncoding(haftree.getRoot(), "");
        }
        public Dictionary<char, string> GetEncoding()
        {
            return encode;
        }
        void fillArrayFrequence(StreamReader reader)
        {
            char c;
            while (reader.Peek() >= 0)
            {
                c = Convert.ToChar(reader.Read());
                if (!ArrayFrequence.Keys.Contains(c))
                {
                    ArrayFrequence.Add(c, 1);
                } else
                {
                    ArrayFrequence[c]++;
                }
            }
        }
        public Dictionary<char, int> getFrequenceArray()
        {
            return ArrayFrequence;
        }
        private BinaryTree getHuffmanTree()
        {
            PriorityQueue pq = new PriorityQueue();
            foreach (KeyValuePair<char, int> keyValue in ArrayFrequence)
            {
                Node newNode = new Node(keyValue.Key, keyValue.Value);
                BinaryTree newTree = new BinaryTree(newNode);
                pq.insert(newTree);
            }
           
            while (true)
            {
                BinaryTree tree1 = pq.remove();//извлечь из очереди первое дерево.

                try
                {
                    BinaryTree tree2 = pq.remove();//извлечь из очереди второе дерево

                    Node newNode = new Node();//создать новый Node
                    newNode.addChild(tree1.getRoot());//сделать его потомками два извлеченных дерева
                    newNode.addChild(tree2.getRoot());

                    pq.insert(new BinaryTree(newNode));
                }
                catch (Exception)
                {//осталось одно дерево в очереди
                    return tree1;
                }
            }
        }
        public BinaryTree getTree()
        {
            return haftree;
        }
        public Dictionary<char, string> getEncoding()
        {
            return encode;
        }

        void fillEncoding(Node node,string code)
        {
            if(node.isLeaf())
            {
                if (code == "" )
                {
                    encode.Add(node.getLetter(), "1");
                }
                else { encode.Add(node.getLetter(), code); }

            }
            else
            {
                fillEncoding(node.getLeftChild(), code+"0");
                fillEncoding(node.getRightChild(), code + "1");
            }
        }



        //public void displayEncodingArray()
        //{//для отладки
        //   // fillEncodingArray(haftree.getRoot(), "");

        //    Console.WriteLine("======================Encoding table====================");
        //    foreach (KeyValuePair<char, string> keyValue in encode)
        //    {
        //        // keyValue.Value представляет класс Person
        //        Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
        //    }
        //    Console.WriteLine("========================================================");
        //}
    }
}
