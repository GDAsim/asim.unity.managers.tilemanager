using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using asim.unity.extensions;
using asim.unity.managers.tilemanager;


public class TileManager_Example : MonoBehaviour
{
    /*Assign Tilemap Text File*/
    [SerializeField] TextAsset TilemapTextFile;

    void Start()
    {
        SpawnTiles();
    }

    public void SpawnTiles()
    {
        if (!TilemapTextFile) return;

        char[][] charArray = AssetsExtentions.ReadCharArrayTextAsset(TilemapTextFile);
        SimpleTile_TileManager.Instance.SpawnTilesetFromCharArray(charArray);
    }
    public void RemoveTiles()
    {
        SimpleTile_TileManager.Instance.Removetiles();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(TileManager_Example))]
public class TileManager_ExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Call the Update to all serialized object that appears in inspector
        serializedObject.Update();

        DrawPropertiesExcluding(serializedObject);

        TileManager_Example t = target as TileManager_Example;

        if (GUILayout.Button("Spawn Tiles")) t.SpawnTiles();

        if (GUILayout.Button("Remove All Tiles")) t.RemoveTiles();

        //Apply property modifications. Unity docs not explained clearly
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
