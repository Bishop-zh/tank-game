using UnityEditor;
using UnityEngine;

public class FixMissingPrefabScripts
{
    [MenuItem("Tools/Fix Missing Prefab Scripts")]
    public static void Fix()
    {
        string path = "Assets/Art/TDSTK/Prefabs/EffectObjects/GunShotMuzzle.prefab";
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError("Prefab not found at: " + path);
            return;
        }

        GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        if (instance == null)
        {
            Debug.LogError("Failed to instantiate prefab.");
            return;
        }

        int totalRemoved = 0;
        Transform[] allTransforms = instance.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in allTransforms)
        {
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(t.gameObject);
            totalRemoved += removed;
        }

        Debug.Log("Removed " + totalRemoved + " missing script component(s).");

        PrefabUtility.SaveAsPrefabAsset(instance, path);
        Object.DestroyImmediate(instance);
        AssetDatabase.SaveAssets();

        Debug.Log("Saved prefab: " + path);
    }
}
