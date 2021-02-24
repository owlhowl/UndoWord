using MVVM;

namespace UndoWord
{
    class ViewModel : NotifyPropertyChanged
    {
        Model model;

        public string CurrentWord { get => model.CurrentWord; }
        public int WordLength { get => model.WordLength; set => model.WordLength = value; }
        public bool IsRandom { get => model.IsRandom; set => model.IsRandom = value; }
        public bool IsNotRandom { get => !model.IsRandom;}

        public Command NewWord { get; set; }
        public Command Undo { get; set; }

        public ViewModel()
        {
            model = new Model();

            NewWord = new Command(
                () => model.NewWord(), 
                () => true);

            Undo = new Command(
                () => model.Undo(),
                () => model.CanUndo);

            model.CurrentWordChanged += (o, e) => OnPropertyChanged("CurrentWord");
            model.IsRandomChanged += (o, e) => OnPropertyChanged("IsNotRandom");
        }
    }
}
