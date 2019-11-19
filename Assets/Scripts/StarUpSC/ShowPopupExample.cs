﻿using UnityEngine;
using UnityEditor;

public class ShowPopupExample : EditorWindow
{
    //[MenuItem("Example/ShowPopup Example")]
    public static void Init()
    {
        ShowPopupExample window = ScriptableObject.CreateInstance<ShowPopupExample>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Please Update version!", EditorStyles.wordWrappedLabel);
        GUILayout.Space(70);
        if (GUILayout.Button("Agree!")) this.Close();
    }
}