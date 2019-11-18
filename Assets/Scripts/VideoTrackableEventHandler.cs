/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VideoTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PROTECTED_METHODS

    public bool autoplay = true;
    bool isFirst = true;
    public GameObject rotatePanel;
    public static bool isTrakingFound = false;
    GameObject HelpPanel;
    string[] RotateTargetName = new string[3] { "01_Front_Page", "05_Chicken", "07_Glasses"};

   
    protected override void OnTrackingLost()
    {
        isTrakingFound = false;
        var objVideoCont=mTrackableBehaviour.GetComponentsInChildren<VideoController>();
        var objAudioCon = mTrackableBehaviour.GetComponentsInChildren<AudioSource>();
        Animation[] animationComponents = GetComponentsInChildren<Animation>();
        Animator[] animatorComponents = GetComponentsInChildren<Animator>();
        for (int i=0;i<objVideoCont.Length;i++) {
            mTrackableBehaviour.GetComponentsInChildren<VideoController>()[i].Pause();
        }

        for (int i=0;i< objAudioCon.Length;i++) {
            mTrackableBehaviour.GetComponentsInChildren<AudioSource>()[i].Pause();
        }

        foreach (Animation component in animationComponents) {
            component.Stop();
            // component.Rewind();
        }

        foreach (Animator component in animatorComponents)
        {
            component.enabled = false;
            // component.Rewind();
        }
        if (rotatePanel != null)
        {
            rotatePanel.SetActive(false);
        }

        //HelpPanel.SetActive(true);
        base.OnTrackingLost();
    }
    
 	protected override void OnTrackingFound()
    {
        HelpPanel = GameObject.Find("HelpText");
        if (HelpPanel != null)
        {
            HelpPanel.SetActive(false);
        }
        isTrakingFound = true;
        base.OnTrackingFound();
        foreach (string x in RotateTargetName)
        {
            if (mTrackableBehaviour.TrackableName.Contains(x))
            {
                Debug.Log("############ TrackingFound:" + rotatePanel);
                if (rotatePanel != null)
                {
                    rotatePanel.SetActive(true);
                }
            }
        }

        if (autoplay) {
            var objVideoCont=mTrackableBehaviour.GetComponentsInChildren<VideoController>();
            var objAudioCon = mTrackableBehaviour.GetComponentsInChildren<AudioSource>();
            Animation[] animationComponents = GetComponentsInChildren<Animation>();
            Animator[] animatorComponents = GetComponentsInChildren<Animator>();
            for (int i=0;i<objVideoCont.Length;i++) {
                mTrackableBehaviour.GetComponentsInChildren<VideoController>()[i].Play();
            }
            for (int i = 0; i < objAudioCon.Length; i++) {
                mTrackableBehaviour.GetComponentsInChildren<AudioSource>()[i].Play();
            }
            if (true)//isFirst)
            {
                Debug.Log("##########    animation:" + animationComponents);
                if(animationComponents != null)
                {
                    foreach (Animation component in animationComponents)
                    {
                        Debug.Log("########## ani:" + component);
                        component.Rewind();
                        component.Play();
                    }
                }
                if(animationComponents != null)
                {
                    foreach (Animator component in animatorComponents)
                    {
                        component.enabled = true;
                        component.Rebind();
                    }
                }
                isFirst = false;
            }
        }
    }

    #endregion // PROTECTED_METHODS
}
