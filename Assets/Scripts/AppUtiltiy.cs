using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppUtiltiy : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenPodcast()
    {
        Application.OpenURL("http://tiny.cc/AY-podcast");
    }

    public void FeedbackMail()
    {
        Application.OpenURL("mailto:gncapps@googlegroups.com?subject=Feedback/Bug%20Report%20of%20Akram%20Youth%20AR");
    }
}
