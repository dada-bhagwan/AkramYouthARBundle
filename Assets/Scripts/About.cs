using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class About : MonoBehaviour
{

    public Text my_text;
    // Start is called before the first frame update
    void Start()
    {
        my_text = GameObject.Find("version").GetComponent<Text>();
        Debug.Log("############## mytext:" + my_text);
        my_text.text = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
