using System;

namespace MedianOfTwoSortedArrays {
    class Program {
        static void Main(string[] args) {
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };

            Console.WriteLine(Solution.FindMedianSortedArrays(nums1, nums2));
            Console.Read();
        }
    }

    public class Solution {
        public static double FindMedianSortedArrays(int[] num1, int[] num2) {

            int pointer1 = 0;
            int pointer2 = 0;
            int totalLength;
            double midPoint;

            //figures out the length of two arrays combined
            totalLength = num1.Length + num2.Length;

            //keeps track of the middle
            midPoint = totalLength / 2d;

            //keeps track if there was an odd number of integers
            bool doubleMedian;

            //checks to see if the length was odd
            if (totalLength % 2 == 1) {

                //keeps track of if there is only one middle number
                doubleMedian = false;

                //gets rid of the decimal point
                midPoint += 0.5;
            } else {

                //keeps track of that fact that there will be two middle numbers
                doubleMedian = true;

                //sets the mid point to take one more number
                midPoint += 1;
            }

            //an array used to store the combined arrays up to the midpoint
            int[] allNumbers = new int[(int)midPoint];

            //loops through enough times to sort up to the midpoint of the combined arrays
            for (int i = 0; i < midPoint; i++) {

                //checks to see if the pointers are still within the array bounds
                if (pointer1 < num1.Length && pointer2 < num2.Length) {

                    //checks to see what array has the smallest pointer number
                    if (num1[pointer1] < num2[pointer2]) {

                        //saves array 1's pointer number
                        allNumbers[i] = num1[pointer1];
                        pointer1++;
                    } else {

                        //saves array 2's pointer number
                        allNumbers[i] = num2[pointer2];
                        pointer2++;
                    }

                    //checks to see if pointer1 is still within array1's bounds
                } else if (pointer1 < num1.Length) {

                    allNumbers[i] = num1[pointer1];
                    pointer1++;

                    //checks to see if pointer2 is still within array2's bounds
                } else if (pointer2 < num2.Length) {

                    allNumbers[i] = num2[pointer2];
                    pointer2++;
                }
            }

            double median;

            if (doubleMedian)
                median = (double)(allNumbers[allNumbers.Length - 2] + allNumbers[allNumbers.Length - 1]) / (double)2;

            else
                median = allNumbers[allNumbers.Length - 1];

            return median;
        }
    }
}
