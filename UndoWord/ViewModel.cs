using MVVM;

namespace UndoWord
{
    class ViewModel : NotifyPropertyChanged
    {
        Model model;

        public string CurrentWord { get => model.CurrentWord; }
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
        }
    }
}
