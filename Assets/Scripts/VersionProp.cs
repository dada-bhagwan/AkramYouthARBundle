using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using JsonUtility;
using System;
using UnityEngine.Networking;
using System.IO;
using System.Net;

//[Serializable]
public class MyClass
{
    public int level;
    public float timeElapsed;
    public string ay_android_version;
}
public class ProcessCall
{
    public ProcessCall()
    {

    }
    private MyClass GetVersion()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://youthapi.dbf.ooo:8000/ay_version");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log("######################### " + jsonResponse);
        return JsonUtility.FromJson<MyClass>(jsonResponse);
    }

    //string stringResponse = "";
    //bool objRe = true;
    //IEnumerator GetRequest()
    //{
    //    WWW internetObj = new WWW("http://youthapi.dbf.ooo:8000/appSettings");
    //    yield return internetObj;
    //    if (!string.IsNullOrEmpty(internetObj.error))
    //    {
    //        Debug.Log(" Error: " + internetObj.error);
    //    }
    //    else
    //    {
    //        //Debug.Log(internetObj.text);
    //        var vers = JsonUtility.FromJson<MyClass>(internetObj.text);
    //        Debug.Log(JsonUtility.FromJson<MyClass>(internetObj.text).ay_ar_android);
    //        if (Convert.ToDouble(Application.version) != vers.ay_ar_android)
    //        {
    //            objRe = false;
    //        }
    //    }
    //}
    public bool CheckVersion()
    {

        bool objRe = true;
        //return objRe;
        Debug.Log("######################### Call from Process Call");
        var objVersion = GetVersion();
        Debug.Log(objVersion.ay_android_version);
        if (Application.version != objVersion.ay_android_version)
        {
            objRe = false;
        }
        //Start();
        //Start();


        return objRe;
    }

    public bool IsAppUpdateAvailable()
    {
        string playstoreVersion = GetVersion().ay_android_version;
        Debug.Log("########## Playstor Version:" + playstoreVersion);
        var appVersion = Application.version;
        Debug.Log("########## App Version:" + appVersion);
        var version1 = new Version(playstoreVersion);
        var version2 = new Version(appVersion);

        var result = version1.CompareTo(version2);
        Debug.Log("########## Result:" + result);
        if (result > 0)
            return true;
        return false;
    }
}
