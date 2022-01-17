using System.Globalization;

namespace ConsoleDrawing.States;

public abstract class State
{
    protected readonly Stack<State> States;

    protected State(Stack<State> states)
    {
       States = states;
    }
    
    protected abstract void ShowMenu();
    protected abstract void ConsoleHandler(int selection);

    public int ConvertConsoleInputToInt()
    {
        return Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
    }
    
    protected void DeleteState()
    {
        States.Pop();
    }
    public abstract void Update();
}
