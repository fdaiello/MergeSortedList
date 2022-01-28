using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the mergeLists function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {

        if (head1 == null && head2 == null)
            return head1;
        else if (head1 == null)
            return head2;
        else if (head2 == null)
            return head1;
        else
        {
            List<int> outList = new List<int>();

            // Insert values from list 1 into outList
            while ( head1 != null)
            {
                outList.Add(head1.data);
                head1 = head1.next;
            }

            // Insert values from list 2 into outList
            while (head2 != null)
            {
                outList.Add(head2.data);
                head2 = head2.next;
            }

            // Sort out List
            outList.Sort();

            // Reverse
            outList.Reverse();

            // New Header
            SinglyLinkedListNode newHead = null;

            // Fill new list ( from end to beggining )
            foreach ( int i in outList)
            {
                // New Node
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(i);
                newNode.next = newHead;

                // Adjust head
                newHead = newNode;

            }

            // return new merged list
            return newHead;
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter($"{Directory.GetCurrentDirectory()}\\output2.txt", true);

        StreamReader sr = new StreamReader($"{Directory.GetCurrentDirectory()}\\testcase2.txt");

        int tests = Convert.ToInt32(sr.ReadLine());

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            SinglyLinkedList llist1 = new SinglyLinkedList();

            int llist1Count = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < llist1Count; i++)
            {
                int llist1Item = Convert.ToInt32(sr.ReadLine());
                llist1.InsertNode(llist1Item);
            }

            SinglyLinkedList llist2 = new SinglyLinkedList();

            int llist2Count = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < llist2Count; i++)
            {
                int llist2Item = Convert.ToInt32(sr.ReadLine());
                llist2.InsertNode(llist2Item);
            }

            SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

            PrintSinglyLinkedList(llist3, " ", textWriter);
            textWriter.WriteLine();
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
