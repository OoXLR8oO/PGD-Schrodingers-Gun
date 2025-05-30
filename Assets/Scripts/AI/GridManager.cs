using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap obstacleTilemap; // Assign your obstacles tilemap here
    public Vector2Int gridSize; // e.g. (width, height)
    public Vector3 originPosition; // world position of grid bottom-left tile
    public float tileSize = 1f; // size of each tile

    private bool[,] walkableGrid;

    private void Awake()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        walkableGrid = new bool[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 worldPos = originPosition + new Vector3(x * tileSize, y * tileSize, 0f);
                Vector3Int tilePos = obstacleTilemap.WorldToCell(worldPos);
                TileBase tile = obstacleTilemap.GetTile(tilePos);

                // If no tile, then walkable. If tile exists (obstacle), then blocked.
                walkableGrid[x, y] = (tile == null);
            }
        }
    }

    public bool IsWalkable(Vector2Int gridPos)
    {
        if (gridPos.x < 0 || gridPos.x >= gridSize.x || gridPos.y < 0 || gridPos.y >= gridSize.y)
            return false;
        return walkableGrid[gridPos.x, gridPos.y];
    }

    public Vector3 GridToWorld(Vector2Int gridPos)
    {
        return originPosition + new Vector3(gridPos.x * tileSize + tileSize / 2, gridPos.y * tileSize + tileSize / 2, 0);
    }

    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        Vector3 relativePos = worldPos - originPosition;
        int x = Mathf.FloorToInt(relativePos.x / tileSize);
        int y = Mathf.FloorToInt(relativePos.y / tileSize);
        return new Vector2Int(x, y);
    }
}