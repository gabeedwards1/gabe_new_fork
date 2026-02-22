using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerator : MonoBehaviour
{
    public Tilemap floorMap;
    public Tilemap wallMap;
    public RoomPalette palette;
    public RoomTemplate testRoom;

    [ContextMenu("Generate Test")]
    public void Generate()
    {
        floorMap.ClearAllTiles();
        wallMap.ClearAllTiles();

        // 1. Stamp Floors
        string[] lines = testRoom.layout.Split('\n');
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == '.')
                {
                    floorMap.SetTile(new Vector3Int(x, -y, 0), palette.floorTile);
                }
            }
        }

        // 2. Extrapolate Walls
        BoundsInt bounds = floorMap.cellBounds;
        Vector3Int min = bounds.min - new Vector3Int(1, 1, 0);
        Vector3Int max = bounds.max + new Vector3Int(1, 1, 0);

        for (int x = min.x; x <= max.x; x++)
        {
            for (int y = min.y; y <= max.y; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                // If it's already floor, we don't put a wall here
                if (floorMap.HasTile(pos)) continue;

                int mask = GetFloorNeighborMask(pos);
                if (mask > 0)
                {
                    // This puts the "Cap" (The black line part)
                    wallMap.SetTile(pos, palette.GetWallByMask(mask));

                    // PERSPECTIVE HACK: 
                    // If the floor is BELOW (South) this wall, it's a North Wall.
                    // North walls need that tall blue face to hang down over the floor.
                    // Masks 1, 3, and 9 all have Floor to the South.
                    if (mask == 1 || mask == 3 || mask == 9)
                    {
                        // Place the "Face" tile one unit below
                        Vector3Int facePos = pos + Vector3Int.down;
                        wallMap.SetTile(facePos, palette.verticalWallFace);
                    }
                }
            }
        }
    }

    private int GetFloorNeighborMask(Vector3Int pos)
    {
        int mask = 0;
        if (floorMap.HasTile(pos + Vector3Int.down)) mask += 1; // Floor South
        if (floorMap.HasTile(pos + Vector3Int.left)) mask += 2; // Floor West
        if (floorMap.HasTile(pos + Vector3Int.up)) mask += 4; // Floor North
        if (floorMap.HasTile(pos + Vector3Int.right)) mask += 8; // Floor East
        return mask;
    }
}