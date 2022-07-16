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
        {
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                tilemap.RefreshTile(position);
            }
        }
        m_go = Instantiate(Resources.Load("BasicFloorCube")) as GameObject;
        m_go.transform.position = location;
        //m_go.transform.rotation = Quaternion.Euler(-90, 0, 0);
        m_go.transform.parent = GameObject.Find("Tilemap").transform;

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