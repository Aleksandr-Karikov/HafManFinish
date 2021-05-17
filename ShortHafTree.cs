using System;
using System.Collections.Generic;
using System.Linq;
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
        static public BinaryTree getHuftree(string shortHaf)
        {
            BinaryTree temp = new BinaryTree();
            if (shortHaf[0] == '0')
            {
                temp = new BinaryTree();
            } else
            {
                if (shortHaf[0] == '1')
                {
                    temp = new BinaryTree(new Node(shortHaf[1]));
                    return temp;
                }
            }
            int i = 1;
            Node Temp = temp.getRoot();
            while (i < shortHaf.Length)
            {
                while (shortHaf[i] == '0')
                {
                    if (Temp.getLeftChild() != null && Temp.getRightChild() != null)
                    {
                        Temp = Temp.getParent();
                    }
                    else
                    {
                        if (Temp.getLeftChild() == null)
                        {
                            Temp.addChildWithouFreq(new Node(Temp));
                            Temp = Temp.getLeftChild();
                            i++;
                        }
                        else
                        {
                            Temp.addChildWithouFreq(new Node(Temp));
                            Temp = Temp.getRightChild();
                            i++;
                        }
                    }
                }
                while (Temp.getLeftChild() != null && Temp.getRightChild() != null)
                {
                    Temp = Temp.getParent();
                }
                i++;
                Temp.addChildWithouFreq(new Node(shortHaf[i], Temp));
                i++;
            }
            return temp;
        }
        static private String[] encodingArray;
        static void fillEncodingArray(Node node, String codeBefore, String direction)
        {
            if (node.isLeaf())
            {
                encodingArray[(int)node.getLetter()] = codeBefore + direction;
            }
            else
            {
                fillEncodingArray(node.getLeftChild(), codeBefore + direction, "0");
                fillEncodingArray(node.getRightChild(), codeBefore + direction, "1");
            }
        }
        public static string[] getEncod(BinaryTree tree)
        {
            encodingArray = new String[143859];
            Node c = tree.getRoot();
            fillEncodingArray(tree.getRoot(), "", "");
            return encodingArray;
        }
            
       
    }
}
