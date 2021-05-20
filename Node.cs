using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HafManFinish
{
    class Node
    {
        private int frequence;//частота
        private char letter;//буква
        private Node leftChild;//левый потомок
        private Node rightChild;//правый потомок
        public Node(char letter, int frequence)
        { //собственно, конструктор
            this.letter = letter;
            this.frequence = frequence;
        }
        public Node() { }
        public Node(char letter) { this.letter = letter; }

        public void addChild(Node newNode)
        {//добавить потомка
            if (leftChild == null)//если левый пустой=> правый тоже=> добавляем в левый
                leftChild = newNode;
            else
            {
                if (leftChild.getFrequence() <= newNode.getFrequence()) //в общем, левым потомком
                    rightChild = newNode;//станет тот, у кого меньше частота
                else
                {
                    rightChild = leftChild;
                    leftChild = newNode;
                }
            }

            frequence += newNode.getFrequence();//итоговая частота
        }
        public void addChildWithouFreq(Node newNode)
        {
            if (leftChild == null)
                leftChild = newNode;
            else
            {
                if (rightChild == null)
                {
                    rightChild = newNode;
                }
            }
        }
        public Node getLeftChild()
        {
            return leftChild;
        }
        public void SetLeftChild(Node child)
        {
            leftChild = child;
        }
        public void SetRightChild(Node child)
        {
            rightChild = child;
        }
        public void SetLetter(char ch)
        {
            letter = ch;
        }
        public Node getRightChild()
        {
            return rightChild;
        }

        public int getFrequence()
        {
            return frequence;
        }

        public char getLetter()
        {
            return letter;
        }

        public bool isLeaf()
        {//проверка на лист
            return leftChild == null && rightChild == null;
        }
    }
}
