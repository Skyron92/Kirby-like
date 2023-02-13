using Player;
using UnityEngine;

public class Patroil : BugState
{
    public Patroil(Bugs context) : base(context)
    {
    }

    public override void Transition() {
        if (Context.RangeOfView >= Context.distance) Context.CurrentState = new Attack(Context);
    }

    public override void Do() {
        Debug.Log("I'm in patroil");
    }
}