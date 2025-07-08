using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SimpleCalculatorMaui;

public class CalculatorViewModel : INotifyPropertyChanged
{
    string number1;
    public string Number1
    {
        get => number1;
        set { number1 = value; OnPropertyChanged(); }
    }

    string number2;
    public string Number2
    {
        get => number2;
        set { number2 = value; OnPropertyChanged(); }
    }

    string result;
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
        AddCommand = new Command(() => Calculate("+"));
        SubtractCommand = new Command(() => Calculate("-"));
        MultiplyCommand = new Command(() => Calculate("*"));
        DivideCommand = new Command(() => Calculate("/"));
    }

    void Calculate(string op)
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

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
