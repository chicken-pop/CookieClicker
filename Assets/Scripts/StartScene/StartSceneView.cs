using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartSceneView : MonoBehaviour
{
    [SerializeField]
    private CookieClickerButton startButton;

    public void SetStartButton(UnityAction onClick)
    {
        startButton.Action = onClick;
    }

    public void SetStartButtonImage()
    {
        var sprite = AddressableAssetLoadUtility.Instance.LoadAssetAsync<Sprite>("CookieImage_1");
        startButton.image.sprite = sprite;
    }
}
