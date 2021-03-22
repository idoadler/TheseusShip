using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ship : MonoBehaviour
{
    public Part[] parts;
    private Vector3[] positions;
    public int replacementTime = 5;
    public float speed = 1;
    public Transform body;
    public bool sailing = false;
    private Quaternion startRot;

    private void Start()
    {
        startRot = transform.rotation;
        Invoke(nameof(Remove), replacementTime);
        positions = new Vector3[parts.Length];
        for (var i = 0; i < parts.Length; i++)
        {
            positions[i] = parts[i].transform.localPosition;
        }
    }

    public void Update()
    {
        if (sailing)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
            Ocean.instance.RefreshLakes(transform.position);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var p = other.gameObject.GetComponent<Part>();
        if (p.isUsed)
            return;

        for (var i = 0; i < parts.Length; i++)
        {
            if (!parts[i].isDropped) continue;
            p.transform.parent = body;
            p.transform.localPosition = positions[i];
            parts[i].Destroy();
            parts[i] = p;
            p.isUsed = true;
            return;
        }
    }

    public void Remove()
    {
        var p = Random.Range(0, parts.Length);
        parts[p].Drop();
        Invoke(nameof(Remove), replacementTime);
    }

    public void SetRotation(float rot)
    {
        var r = (0.5f - rot) * 45;
        transform.rotation = startRot * Quaternion.Euler(0, r, 0);
    }

    public void SetSailing(bool s)
    {
        sailing = s;
    }
}
