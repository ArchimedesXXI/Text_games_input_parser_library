using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_games_input_parser_library
{
    public class PhraseToBeParsed
    {
        #region Constructors
        public PhraseToBeParsed(string inputString)
        {
            // making sure the input is not null
            if (inputString == null)
                throw new ArgumentNullException();

            this.InputString = inputString;
            this.HasKeyWordAppeared = new Dictionary<string,bool>();
            this.ItemsCorrespondingToKeyWords = new Dictionary<string,List<string>>();
            this.AllKeyWords = new List<string>();
            // filling in our "map" of key words with its initial "properties"
            foreach (string command in this.keyCommandsWithTheirSynonyms.Keys)
            {
                this.HasKeyWordAppeared.Add(command, false);
                this.ItemsCorrespondingToKeyWords.Add(command, new List<string> { });
                foreach (string value in keyCommandsWithTheirSynonyms[command])
                    this.AllKeyWords.Add(value);
            }

            input_parser input_parser = new input_parser();
            this.ListOfWords_Raw = input_parser.string_to_listOfstring(this.InputString);
            this.ListOfWords_Decluttered = input_parser.RemoveUnusefulWords(this.ListOfWords_Raw);

            // updating fields & properties with input parsed from inputString
            this.UpdateProperty_HasKeyWordAppeared();
            this.UpdateProperty_ItemsCorrespondingToKeyWords();
        }
        #endregion

        #region Fields & Properties
        /// <summary>
        /// All the "key words" ("key commands"), that we want our game to detect and react to.
        /// This is in a form of a Dictionary, which Keys are strings containing a "key command", 
        /// and the associated Values is a List of strings containing all words, that our game treats as synonimes 
        /// of that "key command". (The "key command" itself has to be included in the List as its own synonim.)
        /// </summary>
        //TODO: add "go" and "use"
        internal Dictionary<string, List<string>> keyCommandsWithTheirSynonyms = new Dictionary<string, List<string>>() 
        { 
            {"go", new List<string> {"go", "walk", "run"} },
            {"take", new List<string> {"take", "pick up", "pick-up", "collect"} }, 
            {"drop", new List<string> {"drop", "leave"} } 
        };  

        public Dictionary<string, bool> HasKeyWordAppeared;
        public Dictionary<string, List<string>> ItemsCorrespondingToKeyWords;
        public List<string> AllKeyWords;
        
        public string InputString { get; private set; }
        public List<string> ListOfWords_Raw { get; private set; }
        public List<string> ListOfWords_Decluttered { get; private set; }
        #endregion

        #region Methods

        private void UpdateProperty_HasKeyWordAppeared()
        {
            foreach (string word in this.ListOfWords_Decluttered)
            {
                foreach (string keyCommand in this.keyCommandsWithTheirSynonyms.Keys)
                {
                    if (this.keyCommandsWithTheirSynonyms[keyCommand].Contains(word))
                        this.HasKeyWordAppeared[keyCommand] = true;
                }
            }
        }

        private void UpdateProperty_ItemsCorrespondingToKeyWords()
        {
            this.UpdateProperty_HasKeyWordAppeared();

            int main_index = 0;
            foreach (string word in this.ListOfWords_Decluttered)
            {
                foreach (string keyCommand in this.keyCommandsWithTheirSynonyms.Keys)
                {
                    if (this.keyCommandsWithTheirSynonyms[keyCommand].Contains(word))
                    {
                        string substringsFromLeft = "";
                        string substringsFromRight = "";
                        int maxIndex = 0;

                        for (int local_index = main_index; local_index < ListOfWords_Decluttered.Count; local_index++)
                        {
                            if ((local_index + 1 < ListOfWords_Decluttered.Count)
                                && !this.AllKeyWords.Contains(ListOfWords_Decluttered[local_index + 1]))
                            {
                                if (local_index == main_index)
                                    substringsFromLeft = ListOfWords_Decluttered[local_index + 1];
                                else
                                {
                                    substringsFromLeft = substringsFromLeft + " " + ListOfWords_Decluttered[local_index + 1];
                                    this.ItemsCorrespondingToKeyWords[keyCommand].Add(ListOfWords_Decluttered[local_index + 1]);
                                } 
                                this.ItemsCorrespondingToKeyWords[keyCommand].Add(substringsFromLeft);
                            }
                            else
                            {
                                maxIndex = local_index;
                                break;
                            }
                        }
                        for (int local_index = maxIndex; local_index > main_index + 1; local_index--)
                        {
                            if (local_index == maxIndex)
                                substringsFromRight = ListOfWords_Decluttered[local_index];
                            else
                            {
                                substringsFromRight = ListOfWords_Decluttered[local_index] + " " + substringsFromRight;
                                this.ItemsCorrespondingToKeyWords[keyCommand].Add(substringsFromRight);
                            }
                        }
                    }
                }
                main_index++;
            }
        }

        #endregion
    }
}
