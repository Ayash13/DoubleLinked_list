using System;

namespace DoubleLinked_list
{
    class Node
    {
        //Node class represent the node of doubly linked list
        //It consist of the information part and links to
        //Its seccemdimh amd proceeding
        //in terms of next and previous

        public int noMhs;
        public string name;
        //point to the succending node
        public Node next;
        //point to preccedning node
        public Node prev;

    }
    class DoubleLinkedList
    {
        Node START;

        //constructor

        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("Enter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of the student : ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs = nim;
            newNode.name = nm;
        }
    }
    class Program
    {
       
    }
}