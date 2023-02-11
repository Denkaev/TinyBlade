using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField]
    Vector2Int boardSize = new Vector2Int(15, 8);

    [SerializeField]
    GameBoard board = default;

    void Awake()
    {
        board.Initialize(boardSize);
    }

    void OnValidate()
    {
        if (boardSize.x < 2)
        {
            boardSize.x = 2;
        }
        if (boardSize.y < 2)
        {
            boardSize.y = 2;
        }
    }

}