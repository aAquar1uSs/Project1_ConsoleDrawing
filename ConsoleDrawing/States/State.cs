namespace ConsoleDrawing.States;

public delegate void ErrorMessageHandler(string message);

public abstract class State
{
    /// <summary>
    /// The stack where the application states are stored. 
    /// </summary>
    protected Stack<State> States { get; }
    protected ErrorMessageHandler ErrorMessage { get; }
    
    protected State(Stack<State> states)
    {
       States = states;
       ErrorMessage += OutputErrorMessage;
    }
    
    /// <summary>
    /// Shows the menu.
    /// </summary>
    protected abstract void ShowMenu();
    
    /// <summary>
    /// Processes input data 
    /// </summary>
    /// <param name="selection"></param>
    protected abstract void ConsoleHandler(int selection);

    private static void OutputErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    protected void DeleteState()
    {
        States.Pop();
    }
    /// <summary>
    /// Updates states
    /// </summary>
    public abstract void Update();
}
