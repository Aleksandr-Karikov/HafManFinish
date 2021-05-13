using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HafManFinish
{
    class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = new Node();
        }

        public BinaryTree(char letter)
        {
            root = new Node(letter);
        }
        public BinaryTree(Node root)
        {
            this.root = root;
        }
        public int getFrequence()
        {
            return root.getFrequence();
        }

        public Node getRoot()
        {
            return root;
        }

    }
}
