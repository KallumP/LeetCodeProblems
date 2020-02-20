using System;
using System.Collections;

namespace _3_LongestSubstring {
    class Program {
        static void Main(string[] args) {

            Solution s = new Solution();

            Console.WriteLine(s.LengthOfLongestSubstring("aab"));
            Console.Read();

            

        }
    }


    public class Solution {


        public int LengthOfLongestSubstring(string s) {


            int biggestFoundLength = 0;
            Hashtable foundLetters = new Hashtable();
            int currentFoundLength = 0;

            //loops through each letter in the string
            for (int i = 0; i < s.Length; i++) {

                //string used to keep track of the current char
                string current;

                //gets the current char
                current = s.Substring(i, 1);

                //checks to see if the hashtable didn't have the current letter
                if (!foundLetters.ContainsKey(current)) {

                    //puts in the letter, and it's position
                    foundLetters.Add(current, i);

                    //registers that the substring just increased
                    currentFoundLength++;

                    // checks to see if the current substring is the biggest one found
                    if (currentFoundLength > biggestFoundLength)

                        //registers that this is now the biggest
                        biggestFoundLength = currentFoundLength;


                    //if the hash table did have the letter
                } else {

                    //sets i back to one after the found repeated word
                    i = System.Convert.ToInt32(foundLetters[current]);

                    //sets this back to 0 to start searching again
                    currentFoundLength = 0;

                    //removes all elements from the table ready to keep track of the new letters
                    foundLetters.Clear();
                }
            }


            return biggestFoundLength;

            //when a dupe letter is found, set the size to the current size minus the length up to the found dupe letter.    
        }
    }
}
