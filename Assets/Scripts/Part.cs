using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Part : MonoBehaviour
{
    public bool isUsed;
    public bool isDropped;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    private void Reset()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Drop()
    {
        isDropped = true;
        var r = gameObject.GetComponent<Rigidbody>();
        r.isKinematic = false;
        r.useGravity = true;
    }

    public void Destroy()
    {
        Invoke(nameof(ReallyDestroy), 10);
    }

    public void ReallyDestroy()
    {
        Destroy(gameObject);
    }
}
