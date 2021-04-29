using System;
using System.Linq;

namespace PigLatin
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput = GetInput("Please input a word or sentence to translate to pig Latin");//displays query from method to user
            //Console.WriteLine("Please input a word or sentence to translate to pig Latin"); //don't understand why I can't just do this, but it doesn't work
            //string input = Console.ReadLine().ToLower().Trim(); 

            string translation = ToPigLatin(userInput);//creates variable string translation as a return of the method of ToPigLatin
            Console.WriteLine(translation);//writes the translated word to the console
        }

        public static string GetInput(string prompt)//gets input from the user
        {
            Console.WriteLine(prompt);//writes the prompt to the console
            string input = Console.ReadLine().ToLower().Trim();//reads input from the user
            return input;//returns input from the user.  But where?
        }

        public static bool IsVowel(char c)//method returns a bool if the letter is a vowel
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };//lists all of the vowels

            return c.ToString() == vowels.ToString();//returns c To String if it is equal to vowels To String (I don't understand)
        }

        public static string ToPigLatin(string word)
        {
            //This part works, I don't understand why.  Will change to a method?  Or use as if statment in method?
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };//lists special characters that will change the display based on if they are in the word
            word = word.ToLower();//converts the word entered to all lower case
            foreach(char c in specialChars)//Checks through each character in array c through array specialChars
            {
                foreach(char w in word)//checks to see if char w is in word.  
                {
                    if (w == c)//checks if char w is equal to char c.  Checks if each letter in word is equal to a special character.
                    {
                        //commenting out cw as it does not meet the requirements of the program.
                        //Console.WriteLine("That word has special characters, we will return it as is");//displays to the console the rationale.
                        return word;//returns word as is since it contains a special character.
                    }
                }               
            }
            //why does this exist? only works for if a word has no vowels.  commenting out makes a word with a vowel work.
            //bool noVowels = false;//sets bool value named noVowels as true
            //foreach (char letter in word)//checks each char letter in word
            //{
            //    if (IsVowel(letter))//checks if each letter in word is a vowel
            //    {
            //        noVowels = false;//changes bool NoVowels to false.  Why?
            //    }
            //}

            //if (noVowels)//if noVowels is changed to false it does what is within the set of brackets
            //{
            //    return word; //returns the word entered above
            //}

            char firstLetter = word[0];//checks if the first letter in a word is a vowel
            string output = "placeholder";//writes placeholder for some odd reason, but doesn't acutally.  Can't comment out, though.

            //Will try to change to a method for if first letter is vowel
            //the if statement was wrong, changing to false caused this method to work.
            if (IsVowel(firstLetter) == false)//reads if return of the first letter of the IsVowel method is a vowel then do what's in brackets
            {
                output = word + "way";//Should put at the end of word.  Correcting output to way.  Would output placeholderway?
            }
            //else statement is not working.  Is IsVowel bool really necessary?  Don't understand how to remove, though.
            else//if IsVowel(firstLetter) == false.  Meaning first letter is not a vowel.
            {
                int vowelIndex = -1;//creates a int variable called vowelIndex starting at -1 (why -1?)
                //Handle going through all the consonants<--developer comment
                for (int i = 0; i <= word.Length; i++)//checks value of i at 0, then goes through all values up to the total length of the word, adds 1 and starts over.
                {
                    //Doesn't matter if IsVowel is true or false
                    if (IsVowel(word[i]) == true)//???Trying to find first instance of a vowel and storing it's index as i (why true?)
                    {
                        vowelIndex = i;//i is index of where the first vowel is
                        break;//breaks out of loop
                    }
                }
                //this part I don't understand.  Struggled in my own version of it.
                string sub = word.Substring(vowelIndex + 1);//takes letters from the point after the first vowel is found sets it as var sub
                string postFix = word.Substring(0, vowelIndex -1);//takes letters from before the first instance of the vowel sets it as var postFix

                output = sub + postFix + "ay";//outputs as output var letters after first index of vowel and put them after the letters found after the vowel adds "ay".                                                                                                                                 
            }

            return output;//returns above output.
        }
    }
}
