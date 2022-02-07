using System;
using System.Collections.Generic;
using UnityEngine;

namespace Base.State
{
    public abstract class StateMachine
    {
        protected abstract void OnEnter();
        protected abstract void OnUpdate();
        protected abstract void OnExit();

        private StateMachine _parent;
        private StateMachine _defaultSubState;
        private StateMachine _currentSubState;

        private Dictionary<Type, StateMachine> _subStates = new Dictionary<Type, StateMachine>();
        private Dictionary<int, StateMachine> _transitions = new Dictionary<int, StateMachine>();

        public void Enter()
        {
            OnEnter();

            if (_currentSubState == null && _defaultSubState != null)
            {
                _currentSubState = _defaultSubState;
            }

            if (_currentSubState != null)
            {
                _currentSubState.Enter();
            }
        }

        public void Update()
        {
            OnUpdate();

            if (_currentSubState != null)
            {
                _currentSubState.Update();
            }
        }

        public void Exit()
        {
            if (_currentSubState != null)
            {
                _currentSubState.Exit();
            }

            OnExit();
        }

        public void AddTransition(StateMachine sourceStateMachine, StateMachine targetStateMachine, int trigger)
        {
            if (sourceStateMachine._transitions.ContainsKey(trigger))
            {
                Debug.LogWarning("Duplicated transition! : " + trigger);
                return;
            }

            sourceStateMachine._transitions.Add(trigger, targetStateMachine);
        }

        public void AddSubState(StateMachine subState)
        {
            if (_subStates.Count == 0)
            {
                _defaultSubState = subState;
            }

            subState._parent = this;

            if (_subStates.ContainsKey(subState.GetType()))
            {
                Debug.LogWarning("Duplicated sub state : " + subState.GetType());
                return;
            }

            _subStates.Add(subState.GetType(), subState);
        }

        public void SendTrigger(int trigger)
        {
            var root = this;
            while (root?._parent != null)
            {
                root = root._parent;
            }

            while (root != null)
            {
                if (root._transitions.TryGetValue(trigger, out StateMachine toState))
                {
                    root._parent?.ChangeSubState(toState);
                    return;
                }

                root = root._currentSubState;
            }
        }

        public void SetDefaultState()
        {
            ChangeSubState(_defaultSubState);
        }

        private void ChangeSubState(StateMachine state)
        {
            if (_currentSubState != null)
            {
                _currentSubState.Exit();
            }

            var nextState = _subStates[state.GetType()];
            _currentSubState = nextState;
            nextState.Enter();
        }
    }
}