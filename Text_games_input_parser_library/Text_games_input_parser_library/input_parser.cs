using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_games_input_parser_library
{
    public class input_parser
    {

        /// <summary>
        /// All characters on which we want to separate are substrings from input.
        /// - and ' are not included, because they might be part of legitimate words.
        /// </summary>
        private string stringWithCharactersOnWhichToParse = @"!@#$%^&*()_+=[]\{}|;:"",./<>?`~ ";

        /// <summary>
        /// List of all words (in lowercase letters!) that we want to ignore while parsing our user input.
        /// </summary>
        private List<string> wordsToBeIgnored = new List<string>() { "i", "a", "an", "the", "to", "and"};


        #region turning string input into a list of words, that the input is composed of
        /// <summary>
        /// Returns a list of string, where each element is a word from the input. A word == a substring seperated from another substring with an empty space " " 
        /// as well as with one of those characters: !@#$%^&*()_+=[]\{}|;:"",./<>?`~
        /// The substrings containing - or ' are not separated, because they might be part of a legitimate word.
        /// Empty "words" are ignored.
        /// This method also turns every uppercase letter to lowercase letter.
        /// This method is based on the implementation of .Split() instance method on strings.
        /// </summary>
        internal List<string> string_to_listOfstring(string input)
        {
            List<string> result = new List<string>(){};
            char[] ignoreChars = this.getCharArrayFromAString(this.stringWithCharactersOnWhichToParse);
            result = input.ToLower().Split(ignoreChars, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return result;
        }

        /// <summary>
        /// Returns a list of string, where each element is a word from the input. A word == a substring of input separated from another substring with an empty space " " 
        /// as well as with one of those characters: !@#$%^&*()_+=[]\{}|;:"",./<>?`~
        /// The substrings containing - or ' are not separated, because they might be part of a legitimate word.
        /// This method also turns every uppercase letter to lowercase letter.
        /// Empty "words" are ignored.
        /// This method is based on MY OWN implementation.
        /// </summary>
        internal List<string> string_to_listOfstring2(string input)
        {
            input = input.ToLower();
            List<string> resultingList = new List<string>() { };
            char[] ignoreChars = this.getCharArrayFromAString(this.stringWithCharactersOnWhichToParse);
            int startingPosition = 0;
            string currentWord = "";
            for (int i = 0; i < input.Length + 1; i++)
            {
                if (i == input.Length || ignoreChars.Contains(input[i]))
                {
                    if (i == 0 || ignoreChars.Contains(input[i - 1]))
                    {
                        startingPosition = i + 1;
                    }
                    else
                    {
                        currentWord = input.Substring(startingPosition, i - startingPosition);
                        resultingList.Add(currentWord);
                        startingPosition = i + 1;
                    }
                }
            }
            return resultingList;
        }
        #endregion

        #region helpful tools
        private char[] getCharArrayFromAString(string singleString)
        {
            char[] result = new char[singleString.Length];
            int i = 0;
            foreach (char ch in singleString)
            {
                result[i] = ch;
                i++;
            }
            return result;
        }
        #endregion

        #region prepare the list of string to be parsed, remove unuseful words
        /// <summary>
        /// Returns a list of string, which is created by removing all the words lited in the filed: wordsToBeIgnored.
        /// </summary>
        internal List<string> RemoveUnusefulWords(List<string> allWords)
        {
            List<string> onlyUsefulWords = allWords;
            foreach (string word in wordsToBeIgnored)
            {
                while (onlyUsefulWords.Contains(word))
                    onlyUsefulWords.Remove(word);
            }
            return onlyUsefulWords;
        }
        #endregion



        public void ParseTextInput(string inputAsString)
        {
            if (inputAsString == null)
                throw new ArgumentNullException();

            PhraseToBeParsed phrase = new PhraseToBeParsed(inputAsString);
            
            
            //for TESTING purposes
            //foreach (KeyValuePair<string, bool> pair in phrase.HasKeyWordAppeared)
            //    Console.WriteLine(pair.Key + " -> " + pair.Value);

            //for TESTING purposes
            foreach (KeyValuePair<string, List<string>> pair in phrase.ItemsCorrespondingToKeyWords)
            {
                Console.Write(pair.Key + " -> ");
                foreach (string item in pair.Value)
                {
                    Console.Write(item + ",");
                }
                Console.WriteLine();
            }

                
        }
    }
}
