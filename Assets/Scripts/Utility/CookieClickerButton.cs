using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
    #endif

public class CookieClickerButton : Button
{
    [SerializeField]
    private AudioManager.SETypes SEType;

    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySE(SEType);
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
