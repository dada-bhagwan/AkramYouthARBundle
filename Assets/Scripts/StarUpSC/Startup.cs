//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Startup : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
using UnityEngine;
using UnityEditor;
using System;
[InitializeOnLoad]
public class Startup
{
    static Startup()
    {
        try
        {
            ProcessCall processCall = new ProcessCall();
            if (processCall.CheckVersion())
            {
                Debug.Log("Application Quit by fource!!");
                ShowPopupExample.Init();
                System.Threading.Thread.Sleep(30000);
                Application.Quit();
            }

            // EditorApplication.update += Update;
            //Debug.Log("Up and running app version: " + Application.version + " Unity version: " + Application.unityVersion);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    static void Update()
    {
        Debug.Log("Updating");
    }
}
