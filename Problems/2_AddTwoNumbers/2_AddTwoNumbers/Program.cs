using System;
using System.Collections.Generic;

namespace _2_AddTwoNumbers {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();

            ListNode l1 = new ListNode(1);
            ListNode l2 = new ListNode(9);

            ListNode l11 = new ListNode(9);
            //ListNode l12 = new ListNode(3);

            //ListNode l21 = new ListNode(6);
            //ListNode l22 = new ListNode(4);

            l1.NextNode(l11);
            //l11.NextNode(l12);


            //l2.NextNode(l21);
            //l21.NextNode(l22);



            ListNode answer = s.AddTwoNumbers(l1, l2);

            Console.WriteLine(s.ListToNum(answer));
            Console.Read();
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;

        //constructor
        public ListNode(int x) {
            val = x;
        }

        public void NextNode(ListNode _next) {
            next = _next;
        }
    }

    public class Solution {

        //used to store the nodes
        List<ListNode> nodes = new List<ListNode>();

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

            ListNode l1Curr = l1;
            ListNode l2Curr = l2;
            bool l1End = false;
            bool l2End = false;
            ListNode digit1;
            ListNode digit2;

            //sets up the list of nodes to 
            nodes.Add(new ListNode(0));

            //loops while either of the linked lists have not reached an end
            while (!l1End || !l2End) {

                //sets up two ints to hold the numbers being added
                int add1;
                int add2;

                //sets up what the first addition number should be
                if (l1End) add1 = 0;
                else add1 = l1Curr.val;

                //sets up what the second addition number should be
                if (l2End) add2 = 0;
                else add2 = l2Curr.val;

                //takes the last entered digit from the list (the second digit from the last addition)
                digit1 = nodes[nodes.Count - 1];

                //creates the second digit with a value of 0
                digit2 = new ListNode(0);

                //adds the two numbers together
                AddTwoNodes(add1, add2, digit2, digit1);

                //adds the second digit to the list
                nodes.Add(digit2);

                //sets up the nodes for the next digit of additions
                if (l1Curr.next != null) l1Curr = l1Curr.next;
                else l1End = true;
                if (l2Curr.next != null) l2Curr = l2Curr.next;
                else l2End = true;
            }

            //removes the last digit if it was 0
            if (nodes[nodes.Count - 1].val == 0) nodes.RemoveAt(nodes.Count - 1);

            Link();

            return nodes[0];
        }

        public void AddTwoNodes(int add1, int add2, ListNode digit2, ListNode digit1) {

            //adds together the two nodes
            int sum = add1 + add2;

            //checks to see if the two nodes added to be bigger than 10
            if (sum >= 10) {

                //keeps just the first digit of the sum
                sum -= 10;

                //registers that there was an extra digit from this addition
                digit2.val += 1;
            }

            //adds the result of the addition
            digit1.val += sum;

            //checks to see if the summation
            if (digit1.val >= 10) {
                digit1.val -= 10;
                digit2.val += 1;

            }
        }

        public void Link() {
            for (int i = 0; i < nodes.Count- 1; i++) 

                //links each node to the next one in the list
                nodes[i].next = nodes[i + 1];
        }

        //Turns a list into an int
        public int ListToNum(ListNode node) {

            ListNode current = node;
            int power = 0;
            int num = 0;

            //keeps looping while the node exists
            while (current != null) {

                //takes the next number
                num += current.val * (int)Math.Pow(10, power);

                //increases what power to use
                power++;

                //takes the next node
                current = current.next;
            }

            return num;
        }
    }
}
