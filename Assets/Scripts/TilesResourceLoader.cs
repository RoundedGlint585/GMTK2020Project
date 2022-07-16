
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilesResourceLoader
{
    private const string Horizontal = "horizontal";
    private const string StartStop = "start_stop";
    private const string BasicTile = "BasicTile";

    public static Tile GetHorizontalTile()
    {
        return GetTileByName(BasicTile);
    }

    public static Tile GetStartStopTile()
    {
        return GetTileByName(BasicTile);
    }

    public static Tile GetBaseTile()
    {
        return GetTileByName(BasicTile);
    }

    private static Tile GetTileByName(string name)
    {
        return (Tile)Resources.Load("ColorTile", typeof(ColorTile));
    }
}
