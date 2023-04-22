using UnityEngine;

public class TestField : MonoBehaviour
{
    [SerializeField] private MapSettings sets;

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        for (int x = 0; x < sets.size.x; x++)
            for (int y = 0; y < sets.size.y; y++)
            {
                SpriteRenderer cell = Instantiate(sets.cellPrefab, new Vector3(x, y, 0), Quaternion.identity, transform).GetComponent<SpriteRenderer>();
                cell.sprite = sets.cellSprites[Random.Range(0, sets.cellSprites.Length)];
            }
    }
}
