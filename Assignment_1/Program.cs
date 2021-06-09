using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}", gp);


            //Question 4:
            //int[] arr1 = { 3, 1, 4, 1, 5 };
            int[] arr1 = { 1, 7, 3, 6, 5, 6 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }

        /* 
<summary>
/// Input: moves = "UD"
/// Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. Therefore, we return true.
</summary>
<retunrs>true/False</returns>
*/
        private static bool JudgeCircle(string moves)
        {
            try
            {
                int x = 0;
                int y = 0;

                // variable z will contain the moves made my the robot
                int z = moves.Length;
                //Here we are storing the number of moves by the robot in variable moves
                for (int i = 0; i < z; i++)
                {

                    if (moves[i] == 'R')
                        x++;
                    //If the robot move to the right, it will be represented by x++
                    else if (moves[i] == 'L')
                        x--;
                    //If the robot move to the left, it will be represented by x-- 
                    else if (moves[i] == 'U')
                        y++;
                    //If the robot move up, it will be represented by y++
                    else if (moves[i] == 'D')
                        y--;
                    //If the robot move down, it will be represented by y--
                }
                if (x == 0 && y == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }

        }


        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
        */


        private static bool CheckIfPangram(string s)
        {
            try
            {
                string a;

                // Here we have created a string "a" and have stored all the English alphabets
                // which we can use to compare with the alphabets in the entered sentence.
                a = "abcdefghijklmnopqrstuvwxyz";
                int count = 1;
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < s.Length;)
                    {
                        //here we are checking one by one whether all the alphabets in the
                        //string "a" are present in the string "s" or not. It will start with alphabet "a"
                        //and will check with all the alphabets of string "s". And it will keep on increasing
                        //the counter "count" for every failure of if condition.
                        if (a[i] == s[j])
                        {
                            break;
                        }

                        else
                        {
                            count++;
                            break;
                        }
                    }
                    //if for a alphabet of string "a" is not present in string "s" then the count will be
                    //greater than the s.length and we will return false i.e. the sentence is not pangram.
                    if (count > s.Length)
                    {
                        break;
                    }
                }
                if (count > s.Length)
                    return false;
                else
                    return true;


            }
            catch (Exception)
            {

                throw;
            }

        }



        /*

 <summary> 
 Given an array of integers nums 
 A pair (i,j) is called good if nums[i] == nums[j] and i < j.
 Return the number of good pairs.
 Example:
 Input: nums = [1,2,3,1,1,3]
 Output: 4
 Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
   return type  : int
 </summary>
 <returns>int </returns>
     */

        private static int NumIdenticalPairs(int[] arr)
        {
            try
            {
                int count = 0;
                int i;

                for (i = 0; i < 6; i++)
                {
                    for (int j = i + 1; j < 6; j++)
                    {
                        //here we are verifing two given conditions which are whether
                        //arr[i] == arr[j] and i < j or not. and if the condition is satisfied then we will increment
                        //the counter and will consider that pair as good pair.
                        if (arr[i] == arr[j])
                        {
                            if (i < j)
                            {
                                count++;

                            }

                        }

                    }

                }

                return count;

            }
            catch (Exception)
            {

                throw;
            }
        }






        /*

          <summary>
   Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of all the numbers strictly to the left of  the index is equal to the sum of all the numbers strictly to the index's right.
  If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
  Return the leftmost pivot index. If no such index exists, return -1.
  Example 1:
  Input: nums = [1,7,3,6,5,6]
         Output : 3


      Explanation:
  The pivot index is 3.
  Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
  Right sum = nums[4] + nums[5] = 5 + 6 = 11
          /// </summary>
          /// <param name="nums"></param>
          /// <returns>Number the index in the array</returns>
      */
        private static int PivotIndex(int[] nums)
        {
            try
            {// variable sum1 is the sum starting from left side and the
             // variable grandsum is the total sum of all the numbers in the array.
                int sum1 = 0;
                int grandsum = 0;

                
                for (int i=0; i < 6;i++)
                {
                    grandsum = grandsum + nums[i];
                    
                }

               
                for (int j=0; j < 6;j++)
                {
                    if (grandsum - nums[j] == sum1)
                    {
                        return j;
                    }
                    else
                    {
                        sum1 =  sum1+nums[j];
                        grandsum =grandsum - nums[j];
                    }
                    
                }

                return -1;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /*
            /// <summary>
    /// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order, starting with word1. If a string is longer than the other,
    /// append the additional letters onto the end of the merged string.
    /// Example 1
    /// Input: word1 = "abc", word2 = "pqr"
    /// Output: "apbqcr"
    /// Explanation: The merged string will be merged as so:
    /// word1:  a   b   c
    /// word2:    p   q   r
    /// merged: a p b q c r
    /// </summary>
           /// <param name="word1"></param>
    ///<param name="word2"></param>
           /// <returns>return the merged string </returns>

    */

        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                //merged_word is the variable which will contain the final output.
                string merged_word = "";
                int i = 0;
                int j = 0;



                while (i < word1.Length || j < word2.Length)
                {
                    //here we are storing the first character of word1 in the string "merged_word" and then incrementing "i"
                    if (i < word1.Length)
                    {
                        merged_word = merged_word + word1[i];
                        i++;
                    }
                    // here we are adding the first character of word2 in the string "merged_word", so now it will have
                    //first character of word1 followed by first character of word2 and the loop will be going on till the
                    //while condition is true.
                    if (j < word2.Length)
                    {
                        merged_word = merged_word + word2[j];
                        j++;
                    }
                }

                return merged_word;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
    /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
    We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
    The rules of Goat Latin are as follows:
    1)	If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
    For example, the word 'apple' becomes 'applema'.

    2)	If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
    For example, the word "goat" becomes "oatgma".

    3)	Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
    For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
    Hint : think of a string function to divide the sentence on white spaces
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns> string</returns>
       */
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                //variable s is used to split the sentence based on space and it stores the words in the form of array.
                string[] s = sentence.Split(" ");


                //gl_sent is the variable which will contail the goat latin statement output.
                StringBuilder gl_sent = new StringBuilder();

                // variable c is used as a counter to count the word index in the sentence and accordingly add a's at the end of the word.
                int c = 1;



                foreach (string w in s)
                {
                    if (w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u' || w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U')
                    {
                        gl_sent.Append(w + "ma");
                    }
                    else
                    {
                        gl_sent.Append(w.Substring(1) + w.Substring(0, 1) + "ma");
                    }
                    for (int i = 0; i < c; i++)
                    {
                        gl_sent.Append("a");
                    }
                    c++;
                    if (c <= s.Length)
                    {
                        gl_sent.Append(" ");
                    }
                }
                return gl_sent.ToString();
                

            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}




