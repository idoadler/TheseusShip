using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lake : MonoBehaviour
{
    public Part[] parts;
    public Mesh[] meshes;
    public Material[] materials;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var part in parts)
        {
            part.meshFilter.mesh = meshes[Random.Range(0, meshes.Length)];
            part.meshRenderer.material = materials[Random.Range(0, materials.Length)];
        }
    }

    private void Reset()
    {
        parts = GetComponentsInChildren<Part>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
