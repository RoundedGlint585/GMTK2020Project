using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BasicTile : Tile
{
    public Sprite[] m_Sprites;
    public Sprite m_Preview;
    public Mesh m_Mesh;
    public GameObject m_go;
    public MeshRenderer m_MeshRenderer;
    public Material m_material;
    public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        for (int yd = -1; yd <= 1; yd++)
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                tilemap.RefreshTile(position);
            }
    }

    void Start()
    {
        m_go = new GameObject("Empty");
        m_go.AddComponent<MeshFilter>();
        MeshRenderer mr = m_go.AddComponent<MeshRenderer>();
        m_go.GetComponent<MeshFilter>().mesh = m_Mesh;
        mr.sharedMaterial = m_material;

    }
    void Update()
    {
       
    }
#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/2D/Tiles/BasicTile")]
    public static void CreateBaseTile()
    { 
        string path = EditorUtility.SaveFilePanelInProject("Save Basic Tile", "New Basic Tile", "Asset", "Save Basic Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BasicTile>(), path);
    }
#endif
}