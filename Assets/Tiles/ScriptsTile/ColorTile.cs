using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ColorTile : BasicTile
{
#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/2D/Tiles/ColorTile")]
    public static void CreateColorTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Color Tile", "New Color Tile", "Asset", "Save Color Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<ColorTile>(), path);
    }
#endif
}
