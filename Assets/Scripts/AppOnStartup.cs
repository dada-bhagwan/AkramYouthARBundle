// Demonstration of RuntimeInitializeOnLoadMethod and the argument it can take.
using System;
using UnityEngine;

class AppOnStartup
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        Debug.Log("################## Before first Scene loaded");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoadRuntimeMethod()
    {
        Debug.Log("############## After first Scene loaded");
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("################### RuntimeMethodLoad: After first Scene loaded");
    }

    static void CheckVersion()
    {
        try
        {
            Debug.Log("############################### Inside Startup");
            ProcessCall processCall = new ProcessCall();
            if (!processCall.CheckVersion())
            {
                Debug.Log("############################### Application Quit by fource!!");
                ShowPopupExample.OpenWin();
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
}
