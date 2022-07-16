using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/ScriptsTile/ColorTile")]
public class ColorTile : MonoBehaviour
{
    public Color _color;
    public Tile _tile;

    public ColorTile(Color color, Tile tile)
    {
        _color = color;
        _tile = tile;
    }

    public void updateColor ()
    {
        _tile.color = new Color(0.4f, 0.5f, 0.3f);
    }
}
