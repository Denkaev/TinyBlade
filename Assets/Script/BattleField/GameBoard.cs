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
    //        //Надо бы проверку тут что tilePrefabFrequency не короче tilePrefabList
    //        ComulativeProbability.Add(summa);
    //    }
    //}

    public void Initialize(Vector2Int size)
    {
        for (int i = 0; i < tilePrefabList.Count; i++)
        {
            summa = summa + tilePrefabFrequency[i];
            //Надо бы проверку тут что tilePrefabFrequency не короче tilePrefabList
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
        //Debug.Log("tile [" + tiles.Length + "][" + tiles[0].Length + "]");
    }

    GameTile RandomTilePrefab()
    {
        GameTile RandomTile = tilePrefab;
        int RandomTileNumber = Random.Range(0, summa);
        //Надо бы проверку что все списки одной длинны
        for (int i = 0; i < tilePrefabList.Count; i++)
        {
            if (RandomTileNumber <= ComulativeProbability[i])
            {
                RandomTile = tilePrefabList[i];
                break;
            }

        }
        //На случай ошибки
        return RandomTile;
    }

    //Получаем плитку под мышью
    public GameTile GetTile(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1))
        {
            int x = (int)(hit.point.x + size.x * 0.5f);
            int y = (int)(hit.point.z + size.y * 0.5f);
            return tiles[x][y];
        }
        return null;
    }

    //Размещаем юнит на указаной плитке
    public void ArrangeUnit(GameTile tile, GameObject unit)
    {
       //Надо пересмотреть гайд по башням
        // tile.Content = unit; - тут нужно несколько классов
        //Не понимаю как разместить в нужном месте
        Debug.Log("ArrangeUnit");

        //        tile.Content = contentFactory.Get(GameTileContentType.Empty);
        //tile.Content = contentFactory.Get(towerType);
        //updatingContent.Add(tile.Content);
    }

}
