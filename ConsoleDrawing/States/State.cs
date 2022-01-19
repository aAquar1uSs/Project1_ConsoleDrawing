namespace ConsoleDrawing.States;

public delegate void ErrorMessageHandler(string message);

public abstract class State
{
    protected Stack<State> States { get; }
    protected ErrorMessageHandler ErrorMessage { get; }
    
    protected State(Stack<State> states)
    {
       States = states;
       ErrorMessage += OutputErrorMessage;
    }
    
    protected abstract void ShowMenu();
    
    protected abstract void ConsoleHandler(int selection);

    private void OutputErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    protected void DeleteState()
    {
        States.Pop();
    }
    public abstract void Update();
}
