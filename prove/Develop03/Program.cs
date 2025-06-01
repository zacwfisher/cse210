using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning03
{
    // represents missing words, can be true or false
    public class Word
    {
        private string _text;
        // tracks if the word is currently hidden
        private bool _isHidden;

        // constructor for Word
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        // hides Word, makes it hidden by default
        public void Hide()
        {
            _isHidden = true;
        }

        // shows Word, setting it to visible
        public void Show()
        {
            _isHidden = false;
        }

        // check for if Word is hidden
        public bool IsHidden()
        {
            return _isHidden;
        }

        // gets text, returns as underlines
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                // return underscores for the length of the word
                return new string('_', _text.Length);
            }
            else
            {
                return _text;
            }
        }
    }

    public class Reference
    {
        // private attributes to store components of Reference
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse; // for verse ranges, defaults to 0 if single verse

        // constructor for a single-verse scripture reference
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = 0; // indicate no end verse for a single verse
        }

        // constructor for a scripture reference with a verse range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        // gets the formatted display text for the scripture reference
        public string GetDisplayText()
        {
            if (_endVerse == 0)
            {
                // single verse format
                return $"{_book} {_chapter}:{_startVerse}";
            }
            else
            {
                // multiple verse range format
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
        }
    }

    public class Scripture
    {
        // store the original full scripture text
        private string _text;
        // private attribute to store the scripture reference
        private Reference _reference;
        // internal list to store individual Word objects. This is crucial for hiding logic
        private List<Word> _words;
        // used to randomly select which words are hidden
        private Random _random = new Random(); // This is for hiding words within a scripture, not for selecting scripture

        /// constructor for the Scripture class that initializes a new scripture with given reference and text
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _text = text;

            _words = new List<Word>();
            string[] textWords = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string wordText in textWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        // displays scripture in console
        public void DisplayScripture()
        {
            Console.WriteLine(GetRenderedText());
        }

        // hides random words in scripture
        public void HideWords()
        {
            // get list of currently visible words to choose from
            List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

            // determine how many words to hide this turn
            int wordsToHideThisTurn = Math.Min(3, visibleWords.Count); // hides 3 words as default

            for (int i = 0; i < wordsToHideThisTurn; i++)
            {
                if (visibleWords.Count == 0)
                {
                    break; // no more words to hide
                }

                // select random index from the list of visible words
                int indexToHide = _random.Next(0, visibleWords.Count);

                // get word and hide it
                visibleWords[indexToHide].Hide();

                // remove word from the visible list to avoid hiding it again in the same turn
                visibleWords.RemoveAt(indexToHide);
            }
        }

        // gets the text representation of the scripture including the reference and text with hidden words replaced by underscores
        private string GetRenderedText()
        {
            // start with the formatted reference string
            string displayText = _reference.GetDisplayText();

            // append the scripture text, word by word, using GetDisplayText() from Word objects
            foreach (Word word in _words)
            {
                displayText += " " + word.GetDisplayText();
            }

            return displayText;
        }

        // check if all words in the scripture are completely hidden
        public bool IsCompletelyHidden()
        {
            // use LINQ's .All() method for a concise check
            return _words.All(word => word.IsHidden());
        }
    }

    class Program
    {
        // declare static Random instance to ensure it's initialized only once per application run
        private static Random _appRandom = new Random();

        static void Main(string[] args)
        {
            // Step 1: Create scripture references
            Reference reference1 = new Reference("John", 3, 16);
            Scripture scripture1 = new Scripture(reference1, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

            // added two more scriptures
            Reference reference2 = new Reference("Proverbs", 3, 5, 6);
            Scripture scripture2 = new Scripture(reference2, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");

            Reference reference3 = new Reference("Philippians", 4, 13);
            Scripture scripture3 = new Scripture(reference3, "I can do all things through Christ which strengtheneth me.");

            // create list of scriptures to choose from
            List<Scripture> scriptures = new List<Scripture> { scripture1, scripture2, scripture3 };

            // choose random scripture to start with using the static _appRandom instance
            Scripture currentScripture = scriptures[_appRandom.Next(scriptures.Count)];

            string userInput = "";

            // main loop: continue until the user types 'quit' or all words are hidden
            while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
            {
                Console.Clear(); // clear console screen

                // display current state of the scripture using the public DisplayScripture method
                currentScripture.DisplayScripture(); // calls DisplayScripture()
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");

                userInput = Console.ReadLine();

                if (userInput.ToLower() != "quit")
                {
                    // call the public HideWords method on the Scripture object
                    currentScripture.HideWords(); // calls HideWords()
                }
            }

            // final display after the loop ends (either quit or all hidden)
            Console.Clear();
            currentScripture.DisplayScripture(); // display one last time

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Good job!");
            }
            else
            {
                Console.WriteLine("\nProgram ended. You can try again to memorize more!");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); // keep console open until user presses a key
        }
    }
}
