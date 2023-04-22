using UnityEngine;

[System.Serializable]
public class UnitData
{
    public Sprite sprite;
    public GameObject uiPrefab;
    public GameObject gamePrefab;
    public Color color;
}

[CreateAssetMenu(fileName = "UnitsData", menuName = "Data/UnitsData", order = 0)]
public class UnitsData : ScriptableObject
{
    public UnitData[] units;
}
