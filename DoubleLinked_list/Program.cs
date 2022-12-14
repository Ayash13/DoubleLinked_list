using System;
using System.Net.NetworkInformation;

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
            //On the execution from above for loop, prev and current will point to those node
            //between which the new node is to be inseretd

            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null) ;
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            newNode.next = START;
            if (START != null)
                START.prev = newNode;
            {
                newNode.next = null;
                START = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = current = START;
            while (current != null && rollNo != current.noMhs)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            //the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node between two nodes in the list
            if(current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            //If  deleted is between the list then the following line has executed
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void asCending()
        {
            if (listEmpty())
                Console.WriteLine("List is empty");
            else
            {
                Console.WriteLine("Record in the ascending order of" + "Roll number of : ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.WriteLine(currentNode.noMhs + currentNode.name + "");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("List is empty");
            else
            {
                Console.WriteLine("Record in the ascending order of" + "Roll number of : ");
                Node currentNode;
                //bring the currentNode to the last Node
                currentNode = START;
                while (currentNode.next != null)
                {
                    currentNode =  currentNode.next;
                }
                //mambaca data dari last node ke first
                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.noMhs + " " + currentNode.name + " ");
                    currentNode = currentNode.prev;
                }
            }
        }
    }
    class Program
    {
       static void Main(string[]args)
       {
            DoubleLinkedList obj = new DoubleLinkedList();
            while  (true)
            {
                try
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Add a record to the list ");
                    Console.WriteLine("1. Delete a record from the list ");
                    Console.WriteLine("3. View all record in the ascending order of roll numbers ");
                    Console.WriteLine("4. View all records in the descending order of roll numbers ");
                    Console.WriteLine("5. Search for a record in the list ");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadKey());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("List is empty");
                                    break;

                                }
                                Console.WriteLine("Enter the roll number of the student" + "Whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "deleted");

                            }
                            break;
                        case '3':
                            {
                                obj.asCending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("List is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("Enter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("Record not found");
                                else
                                {
                                    Console.WriteLine("Record found");
                                    Console.WriteLine("Roll number : " + curr.noMhs);
                                    Console.WriteLine("Name : " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");

                            }
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
       }
    }
}