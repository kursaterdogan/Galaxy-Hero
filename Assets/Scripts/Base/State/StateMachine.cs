using UnityEngine;
using System;
using System.Collections.Generic;

namespace Base.State
{
    public abstract class StateMachine
    {
        protected abstract void OnEnter();
        protected abstract void OnExit();

        private StateMachine _parent;
        private StateMachine _defaultSubState;
        private StateMachine _currentSubState;

        private readonly Dictionary<Type, StateMachine> _subStates = new Dictionary<Type, StateMachine>();
        private readonly Dictionary<int, StateMachine> _transitions = new Dictionary<int, StateMachine>();

        public void Enter()
        {
            //TODO Conditional Logging
            Debug.Log(
                "<color=orange>" + GetType().Name + " " +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "</color>");

            OnEnter();

            if (_currentSubState == null && _defaultSubState != null)
                _currentSubState = _defaultSubState;

            _currentSubState?.Enter();
        }

        protected void AddSubState(StateMachine subState)
        {
            if (_subStates.Count == 0)
                _defaultSubState = subState;

            subState._parent = this;

            if (_subStates.ContainsKey(subState.GetType()))
            {
                Debug.LogWarning("Duplicated sub state : " + subState.GetType());
                return;
            }

            _subStates.Add(subState.GetType(), subState);
        }

        protected void AddTransition(StateMachine sourceStateMachine, StateMachine targetStateMachine, int trigger)
        {
            if (sourceStateMachine._transitions.ContainsKey(trigger))
            {
                Debug.LogWarning("Duplicated transition! : " + trigger);
                return;
            }

            sourceStateMachine._transitions.Add(trigger, targetStateMachine);
        }

        protected void SendTrigger(int trigger)
        {
            StateMachine root = this;
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

        protected void SetCurrentSubStateToDefaultSubState()
        {
            if (_defaultSubState != null)
                _currentSubState = _defaultSubState;
        }

        private void ChangeSubState(StateMachine state)
        {
            _currentSubState?.Exit();

            StateMachine nextState = _subStates[state.GetType()];
            _currentSubState = nextState;
            nextState.Enter();
        }

        private void Exit()
        {
            _currentSubState?.Exit();

            OnExit();

            Debug.Log(
                "<color=cyan>" + GetType().Name + " " +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "</color>");
        }
    }
}