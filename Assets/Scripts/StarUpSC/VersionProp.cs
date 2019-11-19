using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using JsonUtility;
using System;

//[Serializable]
public class MyClass
{
    public int level;
    public float timeElapsed;
    public double version;
}
public class ProcessCall
{
    public ProcessCall()
    {

    }
    public bool CheckVersion()
    {
        bool objRe = true;
        Debug.Log("Call from Process Call");
        using (WWW internetObj = new WWW("file:///C:/Users/laxitp/Desktop/version.json"))
        {
            if (!string.IsNullOrEmpty(internetObj.error))
            {
                Debug.Log(" Error: " + internetObj.error);
            }
            else
            {
                //Debug.Log(internetObj.text);
                var vers = JsonUtility.FromJson<MyClass>(internetObj.text);
                Debug.Log(JsonUtility.FromJson<MyClass>(internetObj.text).version);
                if (Convert.ToDouble(Application.version) != vers.version)
                {
                    objRe = false;
                }
            }
        }
        return objRe;

    }
}
