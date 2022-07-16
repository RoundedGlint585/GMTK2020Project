using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilesResourceLoader
{
    private const string Horizontal = "horizontal";
    private const string StartStop = "start_stop";
    private const string BaseTile = "clean";

    public static ColorTile GetHorizontalTile()
    {
        return GetTileByName(Horizontal);
    }

    public static ColorTile GetStartStopTile()
    {
        return GetTileByName(StartStop);
    }

    public static ColorTile GetBaseTile()
    {
        return GetTileByName(BaseTile);
    }

    private static ColorTile GetTileByName(string name)
    {
        return new ColorTile(new Color(1,1,1), (Tile)Resources.Load(name, typeof(Tile)));
    }
}
