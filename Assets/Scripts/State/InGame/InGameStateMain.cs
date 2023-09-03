using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateMain : InGameState
{
    public InGameStateMain(InGameStateMachine stateMachine, CookieClicerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {
        if (cookieClickerPresenter.cookieClickerModel.GetCookieClickCount() == 0)
            return;

        if (cookieClickerPresenter.cookieClickerModel.GetCookieClickCount() % 10 == 0)
        {
            Debug.Log("âÊëúÇÃïœçX");
            cookieClickerPresenter.cookieClickerModel.LoadCookieImage(cookieClickerPresenter.cookieClickerModel.GetCookieClickCount() / 10);
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateResult);
        }
    }
}
