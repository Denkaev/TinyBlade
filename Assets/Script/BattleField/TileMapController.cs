using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    public Tilemap tilemap; // ссылка на тайлмап, на которой будем создавать объекты
    public GameObject prefab; // ссылка на префаб объекта, который мы будем создавать

    private void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию курсора на экране
            Vector3 mousePos = Input.mousePosition;

            // Преобразуем позицию курсора из экранных координат в мировые координаты
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Получаем тайл, на котором находится курсор
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);

            // Создаем объект на тайле
            GameObject newObj = Instantiate(prefab, tilemap.CellToWorld(cellPos), Quaternion.identity);

            // Делаем созданный объект дочерним объектом тайлмапы
            newObj.transform.parent = tilemap.transform;
        }
    }
}
