using System;
using System.Collections.Generic;
using System.IO;

namespace UndoWord
{
    class Model
    {
        private bool isRandom;
        private string currentWord;
        private string path;
        private string[] words;
        private static Random rand = new Random();
        private Stack<string> wordsHistory = new Stack<string>();

        public event EventHandler CurrentWordChanged;
        public event EventHandler IsRandomChanged;

        public string CurrentWord
        {
            get => currentWord;
            set
            {
                currentWord = value;
                CurrentWordChanged?.Invoke(this, null);
            }
        }
        public bool IsRandom {
            get => isRandom;
            set
            {
                isRandom = value;
                IsRandomChanged?.Invoke(this, null);
            }
        }
        public bool CanUndo { get => wordsHistory.Count > 0; }
        public int WordLength { get; set; }

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
            string word;
            if (IsRandom)
            {
                int randomWordNumber = rand.Next(0, words.Length - 1);
                word = words[randomWordNumber];
            }
            else if (WordLength < 2 || WordLength > 24)
            {
                System.Windows.MessageBox.Show("Введите число от 2 до 24");
                return;
            }
            else
            {
                do word = words[rand.Next(0, words.Length - 1)];
                while (word.Length != WordLength);
            }
            wordsHistory.Push(CurrentWord);
            CurrentWord = word;
        }
    }
}
