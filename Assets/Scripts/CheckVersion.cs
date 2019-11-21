using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVersion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Popup;
    void Start()
    {
        try
        {
            Debug.Log("############################### Inside Start");
            ProcessCall processCall = new ProcessCall();
            if (IsAppUpdateAvailable())
            {
                Debug.Log("############################### App Update Version available");
                Popup.SetActive(true);

                //System.Threading.Thread.Sleep(30000);
            }

            // EditorApplication.update += Update;
            //Debug.Log("Up and running app version: " + Application.version + " Unity version: " + Application.unityVersion);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsAppUpdateAvailable()
    {
        ProcessCall processCall = new ProcessCall();
        string playstoreVersion = processCall.GetVersion().ay_android_version;
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
