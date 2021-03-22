using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ocean : MonoBehaviour
{
    public static Ocean instance;
    public Lake[] prefabs;
    public int lakeSize = 10;
    public Vector2Int numberOfLakes;
    private Vector2Int currentLake = Vector2Int.one * -10;
    private Dictionary<Vector2Int, Lake> visiblePart = new Dictionary<Vector2Int, Lake>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        RefreshLakes(Vector3.zero);
    }

    public void RefreshLakes(Vector3 pos)
    {
        var newPos = new Vector2Int((int) (pos.x / lakeSize), (int) (pos.z / lakeSize));
        if (newPos == currentLake)
            return;
        
        var itemsToRemove = visiblePart.Where(l => l.Key.y + 1 < newPos.y).ToArray();
        foreach (var item in itemsToRemove)
        {
            item.Value.Destroy();
            visiblePart.Remove(item.Key);
        }

        currentLake = newPos;
        for (var i = -numberOfLakes.x; i < numberOfLakes.x; i++)
        {
            for (var j = 1; j < numberOfLakes.y + 1; j++)
            {
                var lakePos = new Vector2Int(i, j) + newPos;
                if (!visiblePart.ContainsKey(lakePos))
                {
                    var lake = Instantiate(prefabs[Random.Range(0, prefabs.Length)], (Vector3.right*lakePos.x + Vector3.forward*lakePos.y) * lakeSize , Quaternion.identity, transform);
                    visiblePart.Add(lakePos, lake);
                }
            }
        }
    }
}
