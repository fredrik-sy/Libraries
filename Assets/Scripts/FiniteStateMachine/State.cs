using UnityEngine;

namespace FiniteStateMachine
{
    public abstract class State : ScriptableObject
    {
        public GameObject gameObject { get; set; }
        public abstract int GetStateID();
        public abstract int CheckTransitions();
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void FixedUpdate() { }
        public virtual void Initialize() { }
        public virtual void LateUpdate() { }
        public virtual void Update() { }
    }
}