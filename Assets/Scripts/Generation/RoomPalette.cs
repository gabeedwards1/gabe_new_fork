using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewPalette", menuName = "Lab/Detailed Palette")]
public class RoomPalette : ScriptableObject
{
    public TileBase floorTile;

    [Header("Basic Walls")]
    public TileBase wallNorth; // Floor is South
    public TileBase wallSouth; // Floor is North (The Blue Face)
    public TileBase wallEast;  // Floor is West
    public TileBase wallWest;  // Floor is East

    [Header("Outer Corners")]
    public TileBase cornerNorthEast; // Floor is South + West
    public TileBase cornerNorthWest; // Floor is South + East
    public TileBase cornerSouthEast; // Floor is North + West
    public TileBase cornerSouthWest; // Floor is North + East

    [Header("Specialty")]
    public TileBase verticalWallFace; // The extra face that hangs down
    public TileBase singlePillar;     // Floor on all sides
    public TileBase thinWallHorizontal;
    public TileBase thinWallVertical;

    // This helper replaces the complex array math
    public TileBase GetWallByMask(int mask)
    {
        return mask switch
        {
            1 => wallNorth,
            2 => wallEast,
            4 => wallSouth,
            8 => wallWest,
            3 => cornerNorthEast,
            9 => cornerNorthWest,
            6 => cornerSouthEast,
            12 => cornerSouthWest,
            5 => thinWallHorizontal,
            10 => thinWallVertical,
            15 => singlePillar,
            _ => null
        };
    }
}