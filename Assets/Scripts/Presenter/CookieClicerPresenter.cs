using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClicerPresenter : MonoBehaviour
{
    internal CookieClickerModel cookieClickerModel;
    internal CookieClickerView cookieClickerView;

    public int GameClearClickCount = 20;

    private InGameStateMachine stateMachine;

    internal InGameStateMachine GetStateMachine
    {
        get { return stateMachine; }
    }

    public InGameStateInit InGameStateInit;
    public InGameStateStart InGameStateStart;

    //MainGame����
    public InGameStateMain InGameStateMain;

    //�Q�[���̃��U���g
    public InGameStateResult InGameStateResult;
    public InGameStateEnd InGameStateEnd;

    private void Start()
    {
        stateMachine = new InGameStateMachine();

        InGameStateInit = new InGameStateInit(stateMachine, this);
        InGameStateStart = new InGameStateStart(stateMachine, this);
        InGameStateMain = new InGameStateMain(stateMachine, this);
        InGameStateResult = new InGameStateResult(stateMachine, this);
        InGameStateEnd = new InGameStateEnd(stateMachine, this);

        stateMachine.ChangeState(InGameStateInit);

    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void OnClickCookie()
    {
        cookieClickerModel.AddCookieClickCount(1);
        UpdateCookieUI();
    }

    public void UpdateCookieUI()
    {
        cookieClickerView.UpdateCookieCount(cookieClickerModel.GetCookieClickCount());
    }

    /// <summary>
    ///�Q�[�����I�����邩�A�V�[�����J�ڂ����Ƃ��ɃZ�[�u���s�� 
    /// </summary>
    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
