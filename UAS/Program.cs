using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UAS
{
    class Node
    {
        /*Node class represents the node of doubly lingked list
         * it consist of the information part and links to
         * it succeding and preceeding
         * in terms of next and previous */
        public int noBuku;
        public string JudulBuku;
        public string NamaPengarang;
        public int Tahun;
        //point to the succending node
        public Node next;
        //point to the precceending node
        public Node prev;

    }
    class SinglyLinkedList
    {
        Node START;

        //constructor
        public SinglyLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int number;
            string nm;
            Console.Write("\nmenambahkan nomor buku: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nmenambahkan judul buku: ");
            nm = Console.ReadLine();
            Console.Write("\nmenambahkan nama pengarang: ");
            nm = Console.ReadLine();
            Console.Write("\nTahun terbit: ");
            number = Convert.ToInt32(Console.ReadLine());

            Node newNode = new Node();
            newNode.noBuku = number;
            newNode.JudulBuku = nm;
            newNode.NamaPengarang = nm;
            newNode.Tahun = number;

            //check if the list empty
            if (START == null || number <= START.noBuku)
            {
                if ((START != null) && (number == START.noBuku))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;

            }
            /*if the node is to be inserted at between two node*/
            Node previous, current;
            for (current = previous = START;
                current != null && number >= current.Tahun;
                previous = current = current.next)
            {
                if (number == current.noBuku)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }

            }
            /*On the execution of the above for loop, prev and
             * * current will point to those nodes
             * * between wich the name node is to be insarted.*/
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be insarted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;

            }
            current.prev = newNode;
            previous.next = newNode;

        }
        public bool Search(int NoBuku, ref Node Previous, ref Node current)
        {
            for (Previous = current = START; current != null &&
                NoBuku != current.Tahun + current.noBuku; Previous = current,
                current = current.next) { }
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
                previous.next = current;
                return true;
            }
            //node between two nodes in the list
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            /*if the to be deleted is in between the list then the
             following lines of is executed. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public void Traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nThe records in the list are: ");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.noBuku + ""
                        + currentNode.JudulBuku + "" + currentNode.NamaPengarang + "" + currentNode.Tahun + "\n");
                Console.WriteLine();
            }
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        
       
        class Program
        {
            static void Main(string[] args)
            {
                SinglyLinkedList obj = new SinglyLinkedList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Add a record to the list");
                        Console.WriteLine("2. Delete a record from the list");
                        Console.WriteLine("3. Search for a record in the list");
                        Console.WriteLine("4. view for a record in the list");
                        Console.WriteLine("5. Exit\n");
                        Console.Write("Enter your choice (1-5): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;

                            case '2':
                                {
                                    if (obj.ListEmpty())
                                    {
                                        Console.WriteLine("\nList is Empty");
                                        break;
                                    }
                                    Console.WriteLine("\nEnter the roll number of the student" +
                            " Whose record is to be delated : ");
                                    int rollNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.dellNode(rollNo) == false)
                                        Console.WriteLine("Record not found");
                                    else
                                        Console.WriteLine("Record with roll number " + rollNo + " deleted \n");

                                }
                                break;


                            case '3':
                                {
                                    if (obj.ListEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is Empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nMasukkan tahun terbit buku yang ingin anda cari : ");
                                    int number = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(number, ref prev, ref curr) == true)
                                        Console.WriteLine("\nRecord not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.noBuku);
                                        Console.WriteLine("\nName: " + curr.JudulBuku);
                                        Console.WriteLine("\nName: " + curr.NamaPengarang);
                                        Console.WriteLine("\nRoll number: " + curr.Tahun);
                                    }
                                }
                                break;

                            case '4':
                                {
                                    obj.Traverse();
                                }
                                break;

                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nInvalid option");
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Check for the values entered. ");
                    }

                }
            }
        }
    }
}


//JAWABAN
//2. Algoritma singly linked list
//3. pop dan push
//4. insert  dan delete
//5. a.5
// b. inorder : 1, 8, 5, 10, 12, 15, 20, 22, 25, 28,30, 36, 38, 40, 48, 45,50



