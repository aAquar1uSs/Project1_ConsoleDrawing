namespace ConsoleDrawing.States;

public class DrawState : State
{
    public DrawState(Stack<State> states) : base(states)
    {
    }

    protected override void ShowMenu()
    {
        throw new NotImplementedException();
    }

    protected override void ConsoleHandler(int selection)
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}
