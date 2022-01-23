using ConsoleDrawing.Enums;
using ConsoleDrawing.States;

namespace ConsoleDrawing;

public sealed class DrawApplication
{
    private readonly Stack<State> _states = new();
    private bool _isExit;

    public DrawApplication()
    {
        _states.Push(new MenuState(_states));    
    }

    /// <summary>
    /// Runs application.
    /// </summary>
    public StatusCode Run(string[] args)
    {
        do
        {
            Update();
            
        } while (!_isExit);

        return StatusCode.Success;
    }

    private void Update()
    {
        if (_states.Count != 0)
        {
            _states.Peek().Update();
        }
        else
        {
            _isExit = true;
        }
    }
}
