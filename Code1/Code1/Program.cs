// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.ComponentModel;

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
        //21
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode res = new ListNode (0);
            ListNode cur = res;
            ListNode p1 = list1;
            ListNode p2 = list2;
            while (p1 != null && p2 != null)
            {
                if (p1.val <= p2.val)
                {
                    cur.next = p1;
                    cur = cur.next;
                    p1 = p1.next;
                }
                else
                {
                    cur.next = p2;
                    cur = cur.next;
                    p2 = p2.next;
                }
            }
            if (p1 == null && p2 != null)
                cur.next = p2; 
            else if (p2 == null && p1 != null)
                cur.next = p1;
            return res.next;
        }
        //83
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;
            ListNode cur = head;
            ListNode next = null;
            int curNum = head.val;
            while (cur.next != null)
            {
                if (cur.next.val == curNum)
                {
                    next = cur.next.next;
                    cur.next.next = null;
                    cur.next = next;
                }
                else
                {
                    cur = cur.next;
                    curNum = cur.val;
                }
            }
            return head;
        }
        //19
        //注意删除的是第一个结点时的情况 故使用dummyHead.next作为返回的结果
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode cur = head;
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode pFront = dummyHead;
            ListNode pre = dummyHead;
            int count = 0;
            while (count < n)
            {
                pFront = pFront.next;
                count++;
            }
            while (pFront.next != null)
            {
                pre = cur;
                cur = cur.next;
                pFront= pFront.next;
            }
            pre.next = cur.next;
            return dummyHead.next;
        }
        //24
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode p = dummyHead;
            ListNode next = null;
            ListNode nextnext = null;
            while (p.next != null && p.next.next != null)
            { 
                next = p.next;
                nextnext = next.next;
                p.next = nextnext;
                next.next = nextnext.next;
                nextnext.next = next;
                p = next;
            }
            return dummyHead.next;
        }
        //2 两数相加
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode resDummyHead = new ListNode(0);
            ListNode p = resDummyHead;
            int carry = 0;
            int val = 0;
            int val1 = 0;
            int val2 = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                val1 = l1 == null ? 0 : l1.val;
                val2 = l2 == null ? 0 : l2.val;
                val = (val1 + val2 + carry) % 10;
                carry = (val1 + val2 + carry) / 10;
                ListNode cur = new ListNode(val);
                p.next = cur;
                p = p.next;
                if (l1 != null)  //注意！
                    l1 = l1.next;  //注意！
                if (l2 != null)  //注意！
                    l2 = l2.next;   //注意！
            }
            return resDummyHead.next;
        }
        //445 两数相加2
        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            Stack<int> s1 = new Stack<int>();
            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            Stack<int> s2= new Stack<int>();
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            ListNode res = null;
            int carry = 0;
            int val = 0;
            int val1 = 0;
            int val2 = 0;
            while (s1.Count != 0 || s2.Count != 0 || carry != 0)
            {
                val1 = s1.Count == 0 ? 0 : s1.Pop();
                val2 = s2.Count == 0 ? 0 : s2.Pop();
                val = (val1 + val2 + carry) % 10;
                carry = (val1 + val2 + carry) / 10;
                ListNode cur = new ListNode(val);
                cur.next = res;
                res = cur;
            }
            return res;
        }
        //234
        public bool IsPalindrome(ListNode head)
        {
            bool res = false;
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            //处理长度为1或2的情况
            if (slow == fast)
            {
                if (fast.next == null)
                    return true;
                else if (fast.next.next == null)
                    return fast.val == fast.next.val;
            }
            else
            {
                slow.next = ReverseList(slow.next);
                slow = slow.next;
                while (slow != null && head != null)
                {
                    if (slow.val != head.val)
                        return false;
                    slow = slow.next;
                    head= head.next;
                }
                return true;
            }
            return res;
        }
        //725
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            ListNode[] res = new ListNode[k];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = null;
            }
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            int length = GetListLength(head);
            int quotient = length / k;
            int remainder = length % k;
            int remainLength = quotient;
            ListNode cur = head;
            ListNode pre = dummyHead;
            ListNode curPreHead = dummyHead;
            int index = 0;
            while (index < k)
            {
                if (cur != null) //链表还未遍历结束时
                {
                    //从已有一个开始
                    remainLength = quotient - 1;
                    //还有余数未被分配
                    if (remainder > 0)
                    {
                        remainLength = remainLength + 1;
                        remainder= remainder - 1;
                    }

                    while (remainLength > 0)
                    {
                        cur = cur.next;
                        remainLength--;
                    }
                    pre = cur;
                    cur = cur.next;
                    pre.next = null;
                    res[index] = curPreHead.next;
                    curPreHead.next = cur;
                }
                index++;
            }
            return res;
        }
        //328
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode even = new ListNode(0);
            ListNode odd = new ListNode(0);
            ListNode evenCur = even;
            ListNode oddCur = odd;
            ListNode cur = head;
            bool isOdd = true;
            while (cur != null)
            {
                if (isOdd)
                {
                    oddCur.next = cur;
                    oddCur = oddCur.next;
                    isOdd = false;
                }
                else 
                {
                    evenCur.next = cur;
                    evenCur = evenCur.next;
                    isOdd = true;
                }
                cur = cur.next;
            }
            oddCur.next = even.next;
            evenCur.next = null;
            return odd.next;
        }

        //数组部分
        //283
        public void MoveZeroes(int[] nums)
        {
            int cur = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[cur] = nums[i];
                    cur++;
                }
            }
            for (int m = cur; m < nums.Length; m++)
            {
                nums[m] = 0;
            }
        }
        //566
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int m = mat.GetLength(0);
            int n = mat[0].Length;
            if (m * n != r * c)
                return mat;
            int[][] res = new int[r] [];
            int curM = 0;
            int curN = 0;
            for (int i = 0; i < r; i++)
            {
                res[i] = new int[c];
                for (int j = 0; j < c; j++)
                {
                    res[i][j] = mat[curM][curN];
                    curN++;
                    if (curN > n - 1)
                    {
                        curM++;
                        curN = 0;
                    }
                }
            }
            return res;
        }
        //485
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int res = 0;
            int last = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    last = last + 1;
                    res = Math.Max(last, res);
                }
                else
                    last = 0;
            }
            return res;
        }
        //141 环形链表
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;
            ListNode slow = head;
            ListNode fast = head.next; //fast在前一部 防止下面while循环在最初时判断无法进入
            while (fast!= null && fast.next != null && fast.next.next != null && slow != fast)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast == null || fast.next == null || fast.next.next == null)
                return false;
            else
                return true;
        }
    }
} 