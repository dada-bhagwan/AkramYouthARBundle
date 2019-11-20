using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using JsonUtility;
using System;
using UnityEngine.Networking;

//[Serializable]
public class MyClass
{
    public int level;
    public float timeElapsed;
    public double ay_ar_android;
}
public class ProcessCall : MonoBehaviour
{
    public ProcessCall()
    {

    }
    void Start()
    {
        // A non-existing page.
        StartCoroutine(GetRequest());
    }
    string stringResponse = "";
    bool objRe = true;
    IEnumerator GetRequest()
    {
        WWW internetObj = new WWW("http://youthapi.dbf.ooo:8000/appSettings");
        yield return internetObj;
        if (!string.IsNullOrEmpty(internetObj.error))
        {
            Debug.Log(" Error: " + internetObj.error);
        }
        else
        {
            //Debug.Log(internetObj.text);
            var vers = JsonUtility.FromJson<MyClass>(internetObj.text);
            Debug.Log(JsonUtility.FromJson<MyClass>(internetObj.text).ay_ar_android);
            if (Convert.ToDouble(Application.version) != vers.ay_ar_android)
            {
                objRe = false;
            }
        }
    }
    public bool CheckVersion()
    {

        //bool objRe = true;
        //return objRe;
        Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Call from Process Call");
        //Start();
        //Start();


        return objRe;

    }
}
