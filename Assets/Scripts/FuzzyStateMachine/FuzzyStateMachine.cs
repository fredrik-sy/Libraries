using UnityEngine;

namespace FuzzyStateMachine
{
    public class FuzzyStateMachine : MonoBehaviour
    {
        [SerializeField] private State[] m_States;
        private bool[] m_ActivatedStates;

        private void Start()
        {
            m_ActivatedStates = new bool[m_States.Length];

            for (int i = 0; i < m_States.Length; i++)
            {
                m_States[i].GameObject = gameObject;
                m_States[i].Initialize();
            }
        }

        private void Update()
        {
            if (m_States.Length == 0)
                return;

            for (int i = 0; i < m_States.Length; i++)
            {
                if (m_States[i].CalculateActivation() > 0)
                {
                    if (!m_ActivatedStates[i])
                    {
                        m_ActivatedStates[i] = true;
                        m_States[i].Enter();
                    }

                    m_States[i].Update();
                }
                else
                {
                    if (m_ActivatedStates[i])
                    {
                        m_ActivatedStates[i] = false;
                        m_States[i].Exit();
                    }
                }
            }
        }

        public void Reset()
        {
            for (int i = 0; i < m_States.Length; i++)
            {
                m_States[i].Exit();
                m_States[i].Initialize();
            }
        }
    }
}