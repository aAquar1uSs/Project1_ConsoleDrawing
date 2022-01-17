namespace ConsoleDrawing.States;

public abstract class State
{
    protected readonly Stack<State> States;

    protected State(Stack<State> states)
    {
        this.States = states;
    }
    
    protected abstract void ShowMenu();
    protected abstract void ConsoleHandler(int selection);

    protected void DeleteState()
    {
        States.Pop();
    }
    public abstract void Update();
}
