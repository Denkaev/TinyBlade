using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    Transform ground = default;
    [SerializeField]
    GameTile tilePrefab = default;
    Vector2Int size;
    //Ќедостаточно разделить на двумерный массив, надо хранить в нем тип тайла и при генерации добавить шанс применени€ каждого тайла
    GameTile[][] tiles;

    public void Initialize(Vector2Int size)
    {
        this.size = size;
        ground.localScale = new Vector3(size.x, size.y, 1f);
        Vector2 offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);
        tiles = new GameTile[size.y][];
        for (int i = 0, y = 0; y < size.y; y++)
        {
            tiles[y] = new GameTile[size.x];
            for (int x = 0; x < size.x; x++, i++)
            {
                GameTile tile = tiles[y][x] = Instantiate(tilePrefab);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3(x - offset.x, 0f, y - offset.y);
            }
        }
    }
}