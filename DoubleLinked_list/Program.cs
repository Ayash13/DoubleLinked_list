﻿using System;

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

            //Check if the list empty
            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("Duplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            //if the node is to be inserted at between two Node
            Node previous, current;
            for (current = previous = START;
                current != null && nim >= current.noMhs;
                previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("Duplicate roll number is not allowed");
                    return;
                }
            }
            
    }
    class Program
    {
       
    }
}