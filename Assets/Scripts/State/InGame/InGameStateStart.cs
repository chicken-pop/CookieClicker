using UnityEngine;

public class InGameStateStart : InGameState
{
    public InGameStateStart(InGameStateMachine stateMachine, CookieClicerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
        Debug.Log("Start");

        cookieClickerPresenter.cookieClickerModel.LoadCookieImage(0);

        cookieClickerPresenter.cookieClickerView = cookieClickerPresenter.gameObject.GetComponent<CookieClickerView>();

        cookieClickerPresenter.cookieClickerView.SetClickButtonAction(cookieClickerPresenter.OnClickCookie);
        cookieClickerPresenter.cookieClickerView.SetButtonImage(cookieClickerPresenter.cookieClickerModel.GetCookieImageSprite);
        cookieClickerPresenter.UpdateCookieUI();
        stateMachine.ChangeState(cookieClickerPresenter.InGameStateMain);

        AudioManager.Instance.PlayBGM(AudioManager.BGMType.InGame);

    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
