// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

namespace MyCode // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        //链表
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        //public class Solution
        //{
        //160
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int lengthA = GetListLength(headA);
            int lengthB = GetListLength(headB);
            int delta = Math.Abs(lengthB - lengthA);
            ListNode curA= headA;
            ListNode curB = headB;
            if (lengthA < lengthB)
            {
                curB = headB;
                while (delta > 0 && curB != null)
                {
                    curB = curB.next;
                    delta--;
                }
            }
            else if (lengthA > lengthB)
            {
                curA = headA;
                while (delta > 0 && curA != null)
                {
                    curA = curA.next;
                    delta--;
                }
            }
            while (curA != null && curB != null && curA != curB)
            {
                curA= curA.next;
                curB= curB.next;
            }
            return curA;
        }
        public int GetListLength(ListNode l)
        {
            ListNode cur = l;
            int length = 0;
            while (cur != null)
            {
                length = length + 1;
                cur = cur.next;
            }
            return length;
        }
        //}
        //206
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode cur = head;
            ListNode pre = null;
            ListNode next = null;
            while (cur!= null)
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
    }
}