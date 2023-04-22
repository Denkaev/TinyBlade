using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private MapSettings sets;

    private void Start()
    {
        PlaceCamera();
    }

    private void PlaceCamera()
    {
        Camera.main.transform.position = new Vector3((float)(sets.size.x - 1) / 2f, (float)(sets.size.y - 1) / 2f, -10f);
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float verticalSize = (float)sets.size.y / 2f + (float)sets.borderSize;
        float horizontalSize = ((float)sets.size.x / 2f + (float)sets.borderSize) / aspectRatio;
        Camera.main.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
    }
}
