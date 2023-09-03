using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateEnd : InGameState
{
    public InGameStateEnd(InGameStateMachine stateMachine, CookieClicerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
        Debug.Log("Clear");
    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {
      
    }
}
