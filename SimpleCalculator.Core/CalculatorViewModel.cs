using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SimpleCalculator.Core
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string number1 = string.Empty;
        public string Number1
        {
            get => number1;
            set { number1 = value; OnPropertyChanged(); }
        }

        private string number2 = string.Empty;
        public string Number2
        {
            get => number2;
            set { number2 = value; OnPropertyChanged(); }
        }

        private string result = string.Empty;
        public string Result
        {
            get => result;
            set { result = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        public CalculatorViewModel()
        {
            AddCommand = new RelayCommand(_ => Calculate("+"));
            SubtractCommand = new RelayCommand(_ => Calculate("-"));
            MultiplyCommand = new RelayCommand(_ => Calculate("*"));
            DivideCommand = new RelayCommand(_ => Calculate("/"));
        }

        private void Calculate(string op)
        {
            if (!double.TryParse(Number1, out double n1) || !double.TryParse(Number2, out double n2))
            {
                Result = "Invalid input";
                return;
            }
            switch (op)
            {
                case "+": Result = (n1 + n2).ToString(); break;
                case "-": Result = (n1 - n2).ToString(); break;
                case "*": Result = (n1 * n2).ToString(); break;
                case "/":
                    if (n2 == 0)
                        Result = "Cannot divide by zero";
                    else
                        Result = (n1 / n2).ToString();
                    break;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        public RelayCommand(Action<object?> execute) { _execute = execute; }
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => _execute(parameter);
    }
}
