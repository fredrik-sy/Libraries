using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private State m_DefaultState;
        [SerializeField] private List<State> m_States;
        private State m_CurrentState;

        private void Start()
        {
            m_States.Add(m_DefaultState);

            for (int i = 0; i < m_States.Count; i++)
            {
                m_States[i].gameObject = gameObject;
                m_States[i].Initialize();
            }

            m_CurrentState = m_DefaultState;
            m_CurrentState.Enter();
        }

        private void Update()
        {
            int currentStateID = m_CurrentState.GetStateID();
            int nextStateID = m_CurrentState.CheckTransitions();

            if (nextStateID != currentStateID)
            {
                for (int i = 0; i < m_States.Count; i++)
                {
                    if (m_States[i].GetStateID() == nextStateID)
                    {
                        m_CurrentState.Exit();
                        m_CurrentState = m_States[i];
                        m_CurrentState.Enter();
                        break;
                    }
                }
            }

            m_CurrentState.Update();
        }

        public void Restart()
        {
            m_CurrentState.Exit();
            m_CurrentState = m_DefaultState;

            for (int i = 0; i < m_States.Count; i++)
                m_States[i].Initialize();

            m_CurrentState.Enter();
        }
    }
}