using System;
using System.Collections.Generic;
using System.IO;

namespace UndoWord
{
    class Model
    {
        private string currentWord;
        private string path;
        private string[] words;
        private static Random rand = new Random();
        private Stack<string> wordsHistory = new Stack<string>();

        public event EventHandler CurrentWordChanged;

        public string CurrentWord 
        { 
            get => currentWord; 
            set 
            { 
                currentWord = value; 
                CurrentWordChanged?.Invoke(this, null); 
            } 
        }

        public bool CanUndo { get => wordsHistory.Count > 0; }

        public Model()
        {
            path = "word_rus.txt";
            words = File.ReadAllLines(path);
        }

        internal void Undo()
        {
            CurrentWord = wordsHistory.Pop();
        }

        public void NewWord()
        {
            wordsHistory.Push(CurrentWord);
            var randomWordNumber = rand.Next(0, words.Length - 1);
            var word = words[randomWordNumber];
            CurrentWord = word;
        }
    }
}
