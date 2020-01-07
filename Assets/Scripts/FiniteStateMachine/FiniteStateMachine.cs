using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] private State m_DefaultState;
    [SerializeField] private List<State> m_States;
    private State m_CurrentState;

    private void Start()
    {
        m_States.Add(m_DefaultState);

        foreach (State state in m_States)
        {
            state.GameObject = gameObject;
            state.Initialize();
        }
    }

    private void Update()
    {
        if (m_States.Count == 0)
            return;

        if (m_CurrentState == null)
            m_CurrentState = m_DefaultState;

        if (m_CurrentState == null)
            return;

        int oldStateID = m_CurrentState.StateID;
        int stateID = m_CurrentState.CheckTransitions();

        if (stateID != oldStateID)
        {
            foreach (State state in m_States)
            {
                if (state.StateID == stateID)
                {
                    m_CurrentState.Exit();
                    m_CurrentState = state;
                    m_CurrentState.Enter();
                }
            }
        }

        m_CurrentState.Update();
    }
}
