using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceOrientation : MonoBehaviour
{

    public bool iaLandscapeLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        if(iaLandscapeLeft)
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        else
            Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
