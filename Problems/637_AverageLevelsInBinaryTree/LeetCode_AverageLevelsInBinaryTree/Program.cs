using System;
using System.Collections.Generic;

namespace LeetCode_AverageLevelsInBinaryTree {
    class Program {
        static void Main(string[] args) {

            //test1
            //TreeNode root = new TreeNode(3);
            //TreeNode node1 = new TreeNode(9);
            //TreeNode node2 = new TreeNode(20);
            //TreeNode node3 = new TreeNode(15);
            //TreeNode node4 = new TreeNode(7);

            //root.left = node1;
            //root.right = node2;

            //node1.left = node3;
            //node1.right = node4;

            TreeNode root = new TreeNode(2147483647);
            TreeNode node1 = new TreeNode(2147483647);
            TreeNode node2 = new TreeNode(2147483647);


            root.left = node1;
            root.right = node2;

            Solution s;
            s = new Solution();
            IList<double> averages = s.AverageOfLevels(root);

            foreach (double i in averages)
                Console.WriteLine(i);

            Console.Read();
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public class Solution {

        IList<double> averages;

        int currentDepth;
        int depthToFind;
        List<int> currentDepthValues;

        bool repeat;

        public IList<double> AverageOfLevels(TreeNode root) {

            //keeps track of all the depth's averages
            averages = new List<double>();

            //the depth to go to 
            depthToFind = 0;

            //the current depth
            currentDepth = 0;

            //values found at the right depth
            currentDepthValues = new List<int>();

            //used to know if another traversal was necessary
            repeat = false;

            //keeps traversing while there is more to find
            do {

                //resets the found values
                currentDepthValues = new List<int>();

                //resets the traversal depth
                currentDepth = 0;

                //resets the repeat variable
                repeat = false;

                //traverses
                Traverse(root);

                //used to keep track of total values of the visited nodes at this depth
                long total = 0;

                //loops through the found values for this depth
                foreach (int i in currentDepthValues)

                    //adds on the found value
                    total += i;

                //adds on the average
                averages.Add((double)total / (double)currentDepthValues.Count);

                //sets up the traversal to go a level further
                depthToFind++;

            } while (repeat);

            //returns all the found averages
            return averages;
        }

        //Traverses the tree and keeps track of the current toSearchDepth's values
        void Traverse(TreeNode current) {

            //checks to see if the right level was achieved
            if (currentDepth < depthToFind) {

                //checks to see if there was another node to go to the left
                if (current.left != null) {

                    //registers that the traversal will go down a depth;
                    currentDepth++;

                    //traverses down towards the left
                    Traverse(current.left);
                }

                //checks to see if there was another node to go to the right
                if (current.right != null) {

                    //registers that the traversal will go down a depth;
                    currentDepth++;

                    //goes to the keeps track of the right values
                    Traverse(current.right);
                }

                //registers that the traversal will go back up one
                currentDepth--;


                //else traversal is on the correct depth
            } else {

                //keeps track of this value
                currentDepthValues.Add(current.val);

                //checks to see if the traversal could go further
                if (current.left != null || current.right != null)

                    //keeps track that another traversal should be done
                    repeat = true;

                //registers that the traversal will go up a depth
                currentDepth--;
            }
        }
    }
}