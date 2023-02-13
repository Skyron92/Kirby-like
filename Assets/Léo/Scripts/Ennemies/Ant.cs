using System;

public class Ant : Bugs
{
    private void Awake() {
        CurrentState = new Patroil(this);
    }
    
    
}