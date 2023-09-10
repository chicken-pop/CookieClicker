using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneModel
{
    private bool LoadAsset = false;

    public async UniTask Load()
    {
        LoadAsset = false;
        IEnumerable assetslabel = new object[]
        {
            "CookieImages",
            "BGM",
            "SE"
        };

        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();
        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetslabel);
        LoadAsset = true;
    }
}
