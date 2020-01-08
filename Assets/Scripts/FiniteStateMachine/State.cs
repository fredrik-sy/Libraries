using UnityEngine;

namespace FiniteStateMachine
{
    public abstract class State : ScriptableObject
    {
        public GameObject gameObject { get; set; }
        public abstract int GetStateID();
        public abstract int CheckTransitions();
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Initialize();
        public abstract void Update();
    }
}