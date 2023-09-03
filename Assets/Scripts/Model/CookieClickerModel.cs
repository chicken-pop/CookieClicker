using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データ、およびデータの操作はすべてここで行う
/// </summary>
public class CookieClickerModel
{
    private int cookieClickCount;

    public int GetCookieClickCount()
    {
        return cookieClickCount;
    }

    private Sprite cookieImageSprite;

    public Sprite GetCookieImageSprite
    {
        get { return cookieImageSprite; }
    }

    public void AddCookieClickCount(int amount)
    {
        cookieClickCount += amount;
    }

    public void SaveCookieClickCount()
    {
        var saveData = new PlayerSaveData(string.Empty, cookieClickCount);
        JsonSaveUtility.Save(saveData);
    }

    public void LoadCookieClickCount()
    {
        var loadPlayerData = JsonSaveUtility.Load<PlayerSaveData>();
        //保存しているデータがある場合
        if (loadPlayerData != null)
        {
            cookieClickCount = loadPlayerData.PlayerScore;
            return;
        }
        cookieClickCount = 0;
    }

    public bool LoadedAsset = false;

    public async UniTask AssetsLoad()
    {
        IEnumerable assetLabel = new string[]
        {
            "CookieImages"
        };

        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();
        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetLabel);
        LoadedAsset = true;
    }

    public void LoadCookieImage(int index)
    {
        var cookieSprite = AddressableAssetLoadUtility.Instance.LoadAssetAsync<Sprite>($"CookieImage_{index}");
        cookieImageSprite = cookieSprite;
        Debug.Log(cookieImageSprite);
    }
}
