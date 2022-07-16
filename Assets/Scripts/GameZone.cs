using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameZone : MonoBehaviour
{
    public int Level = 1;
    private Dictionary<int, LevelsData.LevelData> _levelData;
    private Tilemap _gameZoneTilemap;
    private GameController _gameController;

    private void Start()
    {
        _levelData = GetComponent<LevelsDataLoader>().ReadLevelsData();
        _gameZoneTilemap = GetComponent<Tilemap>();
        _gameController = FindObjectOfType<GameController>();

        var sizes = _gameController.Size.Split('x');
        var origin = _gameZoneTilemap.origin;
        var cellSize = _gameZoneTilemap.cellSize;
        _gameZoneTilemap.ClearAllTiles();
        var currentCellPosition = origin;
        var width = int.Parse(sizes[0]);
        var height = int.Parse(sizes[1]);

        var ListColorTiles = new List<ColorTile>();

        for(var h = 0; h < height; h++)
        {
            for(var w = 0; w < width; w++)
            {
                _gameZoneTilemap.SetTile(currentCellPosition, TilesResourceLoader.GetBaseTile()._tile);
                currentCellPosition = new Vector3Int((int)(cellSize.x + currentCellPosition.x), currentCellPosition.y, origin.z);
            }
            currentCellPosition = new Vector3Int(origin.x, (int) (cellSize.y+currentCellPosition.y), origin.z);
        }

        _gameZoneTilemap.CompressBounds();
        SetupTiles();
    }

    private void SetupTiles()
    {
        var localTilesPositions = new List<Vector3Int>();

        foreach( var pos in _gameZoneTilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPotisition = new Vector3Int(pos.x, pos.y, pos.z);
            localTilesPositions.Add(localPotisition);
        }

        SetupPath(localTilesPositions, _gameZoneTilemap);
    }

    private void SetupPath(List<Vector3Int> positions, Tilemap tilemap)
    {
        var path = _levelData[Level].path;
        var horizontalTile = TilesResourceLoader.GetStartStopTile()._tile;
        var first = path.First();
        var last = path.Last();

        foreach(var pos in positions.GetRange(index: first, count: Mathf.Abs(first - last)))
        {
            tilemap.SetTile(pos, horizontalTile); 
        }
    }
}
