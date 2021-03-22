using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    public Lake[] prefabs;
    public Vector3 lakeSize;
    public Vector2Int numberOfLakes;
    private Vector2Int currentLake;
    private Dictionary<Vector2Int, Lake> visiblePart;

    public void UpdatePos(Vector3 pos)
    {
        if((int)(pos.x / lakeSize.x) != currentLake.x
            || (int)(pos.y / lakeSize.y) != currentLake.y)
            Debug.Log("x");
    }
}
