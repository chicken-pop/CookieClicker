using UnityEngine;

public abstract class InGameState
{
    protected InGameStateMachine stateMachine;
    protected CookieClicerPresenter cookieClickerPresenter;

    public InGameState(InGameStateMachine stateMachine, CookieClicerPresenter cookieClickerPresenter)
    {
        this.stateMachine = stateMachine;
        this.cookieClickerPresenter = cookieClickerPresenter;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
