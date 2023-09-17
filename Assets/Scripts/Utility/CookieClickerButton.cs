using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
    #endif

public class CookieClickerButton : Button
{
    [SerializeField]
    private AudioManager.SETypes SEType;

    public UnityAction Action;

    private RectTransform rectTransform => GetComponent<RectTransform>();

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //rectTransform.DOShakePosition(duration: 1f, strength: 5.5f);
        rectTransform.DOScale(new Vector3(1.2f,1.2f,1),0.5f);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySE(SEType);
        Action?.Invoke();
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CookieClickerButton))]
    public class CustomButtonEditor : UnityEditor.UI.ButtonEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var componet = (CookieClickerButton)target;
            componet.SEType = (AudioManager.SETypes)EditorGUILayout.EnumPopup("SEType", componet.SEType);
        }
    }
#endif
}
