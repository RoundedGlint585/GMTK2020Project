using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilesResourceLoader
{
    private const string Horizontal = "horizontal";
    private const string StartStop = "start_stop";
    private const string BaseTile = "clean";

    public static Tile GetHorizontalTile()
    {
        return GetTileByName(Horizontal);
    }

    public static Tile GetStartStopTile()
    {
        return GetTileByName(StartStop);
    }

    public static Tile GetBaseTile()
    {
        return GetTileByName(BaseTile);
    }

    private static Tile GetTileByName(string name)
    {
        return (Tile)Resources.Load(name, typeof(Tile));
    }
}
