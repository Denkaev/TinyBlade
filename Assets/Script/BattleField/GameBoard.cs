using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Transform ground = default;
    [SerializeField] private GameTile tilePrefab = default;
    [SerializeField] private List<GameTile> tilePrefabList = new List<GameTile>();
    [SerializeField] private List<int> tilePrefabFrequency = new List<int>();
    private List<int> ComulativeProbability = new List<int>();
    Vector2Int size = default;
    public GameTile[][] tiles;
    private int summa = 0;

    //private void Awake()
    //{
    //    for (int i = 0; i <= tilePrefabList.Count; i++)
    //    {
    //        summa = summa + tilePrefabFrequency[i];
    //        //Ќадо бы проверку тут что tilePrefabFrequency не короче tilePrefabList
    //        ComulativeProbability.Add(summa);
    //    }
    //}

    public void Initialize(Vector2Int size)
    {
        for (int i = 0; i < tilePrefabList.Count; i++)
        {
            summa = summa + tilePrefabFrequency[i];
            //Ќадо бы проверку тут что tilePrefabFrequency не короче tilePrefabList
            ComulativeProbability.Add(summa);
        }
        this.size = size;
        ground.localScale = new Vector3(size.x, size.y, 1f);
        Vector2 offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);
        tiles = new GameTile[size.y][];
        for (int i = 0, y = 0; y < size.y; y++)
        {
            tiles[y] = new GameTile[size.x];
            for (int x = 0; x < size.x; x++, i++)
            {
      //          GameTile tile = tiles[y][x] = Instantiate(tilePrefab);
                GameTile tile = tiles[y][x] = Instantiate(RandomTilePrefab());
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3(x - offset.x, 0f, y - offset.y);
            }
        }
    }

    GameTile RandomTilePrefab()
    {
        GameTile RandomTile = tilePrefab;
        int RandomTileNumber = Random.Range(0, summa);
        //Ќадо бы проверку что все списки одной длинны
        for (int i = 0; i < tilePrefabList.Count; i++)
        {
            if (RandomTileNumber <= ComulativeProbability[i])
            {
                RandomTile = tilePrefabList[i];
                break;
            }
              
        }
        //Ќа случай ошибки
        return RandomTile;
    }

    public GameTile GetTile(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1))
        {
            //size размер пол€ и получение тайла нужного
            //однако у нас поле разбито на двумерный массив и по идее нам легче получить нужную плитку
            //пока берем любую
            int x = (int)(hit.point.x + size.x * 0.5f);
            int y = (int)(hit.point.z + size.y * 0.5f);
            //if (x >= 0 && x < size.x && y >= 0 && y < size.y)
            //{
            //    return tiles[x + y * size.x];
            //}
            //return tiles[hit.point.x)][hit.point.y];
            //return tiles[x][y];
            return tiles[1][1];
        }
        return null;

        public void ArrangeUnit(GameTile tile)
        {

        //    if (tile.Content.Type == GameTileContentType.Wall)
        //    {
        //        tile.Content = contentFactory.Get(GameTileContentType.Empty);
        //                }
        //    else if (tile.Content.Type == GameTileContentType.Empty)
        //    {
        //        tile.Content = contentFactory.Get(GameTileContentType.Wall);
            
        //    }
        //}

    }
}