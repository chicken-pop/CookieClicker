using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateResult : InGameState
{
    public InGameStateResult(InGameStateMachine stateMachine, CookieClicerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
        Debug.Log("Result");

        if (cookieClickerPresenter.cookieClickerModel.GetCookieClickCount() < cookieClickerPresenter.GameClearClickCount)
        {
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateMain);
        }
        else
        {
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateEnd);
        }
    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {
       
    }
}
