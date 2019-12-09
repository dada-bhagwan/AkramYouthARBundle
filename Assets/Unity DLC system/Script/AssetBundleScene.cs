using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class AssetBundleScene : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    [Header("UI Stuff")]
    public Transform rootContainer;
    public Button prefab;
    public Text laelText;


    static AssetBundle assetBundel;
    IEnumerator Start()
    {
        if (!assetBundel)
        {
            using (WWW www = new WWW(url))
            {
                yield return www;
                if (!string.IsNullOrEmpty(www.error))
                {
                    Debug.Log(www.error);
                    yield break;
                }
                assetBundel = www.assetBundle;

            }
        }
        string[] scenes = assetBundel.GetAllScenePaths();
        foreach (var item in scenes)
        {
            laelText.text = Path.GetFileNameWithoutExtension(item);
            var clone = Instantiate(prefab.gameObject) as GameObject;
            clone.GetComponent<Button>().AddEventListener(laelText.text, LoadAssetBundelScens);

            clone.SetActive(true);
            clone.transform.SetParent(rootContainer);
            //Debug.Log(item);
            //Debug.Log(Path.GetFileNameWithoutExtension(item));
        }

    }
    public void LoadAssetBundelScens(string scenName)
    {
        SceneManager.LoadScene(scenName);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate
        {
            OnClick(param);
        });
    }
}