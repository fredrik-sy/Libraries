using UnityEngine;

public abstract class State : ScriptableObject
{
    public GameObject GameObject { get; set; }
    public int StateID { get; protected set; }
    public abstract int CheckTransitions();
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Initialize();
    public abstract void Update();
}
