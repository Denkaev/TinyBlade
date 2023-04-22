using UnityEngine;

[CreateAssetMenu(fileName = "MapSettings", menuName = "Settings/MapSettings", order = 0)]
public class MapSettings : ScriptableObject
{
    public Vector2Int size = new Vector2Int(10, 20);
    public float borderSize = 2f;
    public Sprite[] cellSprites;
    public GameObject cellPrefab;
}
