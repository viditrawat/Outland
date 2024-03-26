using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }
    
    public void Init(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _nextState)
    {
        currentState.Exit();
        Debug.Log(currentState);
        currentState = _nextState;
        Debug.Log(currentState);
        currentState.Enter();
    }
}
