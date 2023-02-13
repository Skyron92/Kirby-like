using UnityEngine;

public class Attack : BugState
{
    public Attack(Bugs context) : base(context)
    {
    }

    public override void Transition() {
        if (Context.RangeOfView > Context.distance) Context.CurrentState = new Attack(Context);
    }

    public override void Do()
    {
        Debug.Log("I'm Attacking");
    }
}