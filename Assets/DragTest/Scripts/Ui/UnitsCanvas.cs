using UnityEngine;
using UnityEngine.UI;

public class UnitsCanvas : MonoBehaviour
{
    [SerializeField] private UnitsData unitsData;
    [SerializeField] private Transform content;

    private void Start()
    {
        SpawnUnits();
    }

    private void SpawnUnits()
    {
        for (int i = 0; i < unitsData.units.Length; i++)
        {
            GameObject uiUnit = Instantiate(unitsData.units[i].uiPrefab, Vector2.zero, Quaternion.identity, content);
            uiUnit.GetComponent<UnitDrag>().Init(unitsData.units[i]);
        }
    }
}
