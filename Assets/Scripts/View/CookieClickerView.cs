using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �\���Ɋւ��邱�Ƃ͂��̃N���X�ɏW�񂷂�
/// </summary>
public class CookieClickerView : MonoBehaviour
{
    public TextMeshProUGUI cookieCountText;
    public Button clickButton;

    public void UpdateCookieCount(int count)
    {
        cookieCountText.text = $"Cookies:{count}";
    }

    public void SetClickButtonAction(System.Action onClick)
    {
        clickButton.onClick.AddListener(() => onClick?.Invoke());
    }
}
