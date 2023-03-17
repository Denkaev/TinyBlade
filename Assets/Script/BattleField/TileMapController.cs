using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    public Tilemap tilemap; // ������ �� �������, �� ������� ����� ��������� �������
    public GameObject prefab; // ������ �� ������ �������, ������� �� ����� ���������

    private void Update()
    {
        // ���������, ������ �� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // �������� ������� ������� �� ������
            Vector3 mousePos = Input.mousePosition;

            // ����������� ������� ������� �� �������� ��������� � ������� ����������
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // �������� ����, �� ������� ��������� ������
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);

            // ������� ������ �� �����
            GameObject newObj = Instantiate(prefab, tilemap.CellToWorld(cellPos), Quaternion.identity);

            // ������ ��������� ������ �������� �������� ��������
            newObj.transform.parent = tilemap.transform;
        }
    }
}
