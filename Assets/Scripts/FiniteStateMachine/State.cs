using UnityEngine;

namespace FiniteStateMachine
{
    public abstract class State : ScriptableObject
    {
        public GameObject GameObject { get; set; }
        public abstract int StateID { get; }
        public abstract int CheckTransitions();
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Initialize();
        public abstract void Update();
    }
}