using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HafManFinish
{
    class HuffmanTree
    {
        BinaryTree haftree;
        string input;
        byte[] ArrayFrequence;
        int CodeSize = 143859;
        public String[] encodingArray;
        public HuffmanTree(string inp)
        {
            input = inp;
            ArrayFrequence = new byte[CodeSize];
            fillArrayFrequence(inp);
            haftree = getHuffmanTree();
            encodingArray = new String[CodeSize];
            fillEncodingArray(haftree.getRoot(), "", "");
        }
        void fillArrayFrequence(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
             //   Console.WriteLine((int)message[i]);
                    ArrayFrequence[(int)message[i]]++;

            }
        }
            public byte[] getFrequenceArray()
        {
            return ArrayFrequence;
        }
        private BinaryTree getHuffmanTree()
        {
            PriorityQueue pq = new PriorityQueue();
            for (int i = 0; i < CodeSize; i++)
            {
                if (ArrayFrequence[i] != 0)
                {
                    Node newNode = new Node((char)i, ArrayFrequence[i]);//то создать для него Node
                    BinaryTree newTree = new BinaryTree(newNode);//а для Node создать BinaryTree
                    pq.insert(newTree);//вставить в очередь
                }
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
        public String[] getEncodingArray()
        {
            return encodingArray;
        }
        void fillEncodingArray(Node node, String codeBefore, String direction)
        {
            if (node.isLeaf())
            {
                if (codeBefore=="" && direction=="")
                {
                    encodingArray[(int)node.getLetter()] = "1";
                }else
                encodingArray[(int)node.getLetter()] = codeBefore + direction;
            }
            else
            {
                fillEncodingArray(node.getLeftChild(), codeBefore + direction, "0");
                fillEncodingArray(node.getRightChild(), codeBefore + direction, "1");
            }
        }
        public String getOriginalString()
        {
            return input;
        }

        //public void displayEncodingArray()
        //{//для отладки
        //    fillEncodingArray(haftree.getRoot(), "", "");

        //    Console.WriteLine("======================Encoding table====================");
        //    for (int i = 0; i < 140000; i++)
        //    {
        //        if (ArrayFrequence[i] != 0)
        //        {
        //            Console.WriteLine((char)i + " ");
        //            Console.WriteLine(encodingArray[i]);
        //        }
        //    }
        //    Console.WriteLine("========================================================");
        //}
    }
}
