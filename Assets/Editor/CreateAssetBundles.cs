using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CreateAssetBundles : MonoBehaviour
{
    [MenuItem("Assets/Build AsserBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundels", BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);
        
    }
}
