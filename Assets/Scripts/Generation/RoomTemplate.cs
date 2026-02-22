using UnityEngine.Tilemaps;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLabRoom", menuName = "Lab Room")]
public class RoomTemplate : ScriptableObject
{
    public Vector2Int dimensions;

    [Header("Exits")]
    public bool North; public bool South; public bool East; public bool West;

    [TextArea(15, 20)]
    public string layout = "WWWWW\nW...W\nW.E.W\nWWWWW";

    [Header("Mapping Palette")]
    public TileBase wallTile;
    public TileBase floorTile;
    public GameObject enemyPrefab;
    public GameObject consolePrefab; // Decoration
    public GameObject itemPickupPrefab;
}