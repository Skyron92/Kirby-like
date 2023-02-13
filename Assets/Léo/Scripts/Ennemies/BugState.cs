public abstract class BugState
{
    public Bugs Context;

    public BugState(Bugs context)
    {
        Context = context;
    }

    public abstract void Transition();
    public abstract void Do();
}