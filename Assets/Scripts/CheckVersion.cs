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
            if (processCall.IsAppUpdateAvailable())
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
}
