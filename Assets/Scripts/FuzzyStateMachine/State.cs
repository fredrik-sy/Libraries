using UnityEngine;

namespace FuzzyStateMachine
{
    public abstract class State : ScriptableObject
    {
        public GameObject gameObject { get; set; }
        public abstract float CalculateActivation();
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Initialize();
        public abstract void Update();
    }
}