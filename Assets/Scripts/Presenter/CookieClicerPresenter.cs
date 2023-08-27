using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClicerPresenter : MonoBehaviour
{
    private CookieClickerModel cookieClickerModel;
    private CookieClickerView cookieClickerView;

    private async void Start()
    {
        cookieClickerModel = new CookieClickerModel();
        cookieClickerModel.LoadCookieClickCount();

        IEnumerable assetLabel = new string[]
        {
            "CookieImages"
        };

        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();
        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetLabel);

        cookieClickerModel.LoadCookieImage();

        cookieClickerView = GetComponent<CookieClickerView>();

        cookieClickerView.SetClickButtonAction(OnClickCookie);
        cookieClickerView.SetButtonImage(cookieClickerModel.GetCookieImageSprite);
        UpdateCookieUI();
    }

    private void OnClickCookie()
    {
        cookieClickerModel.AddCookieClickCount(1);
        UpdateCookieUI();
    }

    private void UpdateCookieUI()
    {
        cookieClickerView.UpdateCookieCount(cookieClickerModel.GetCookieClickCount());
    }

    /// <summary>
    ///ゲームを終了するか、シーンが遷移したときにセーブを行う 
    /// </summary>
    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
