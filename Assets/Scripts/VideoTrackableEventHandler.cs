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

    protected override void OnTrackingLost()
    {
        
        var objVideoCont=mTrackableBehaviour.GetComponentsInChildren<VideoController>();

        for(int i=0;i<objVideoCont.Length;i++) {
            mTrackableBehaviour.GetComponentsInChildren<VideoController>()[i].Pause();
        }

        base.OnTrackingLost();
    }
    
 	protected override void OnTrackingFound()
    {

        base.OnTrackingFound();

        if (autoplay) {
            var objVideoCont=mTrackableBehaviour.GetComponentsInChildren<VideoController>();

            for(int i=0;i<objVideoCont.Length;i++) {
                mTrackableBehaviour.GetComponentsInChildren<VideoController>()[i].Play();
            }
        }
    }

    #endregion // PROTECTED_METHODS
}
