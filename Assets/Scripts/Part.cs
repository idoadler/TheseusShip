using UnityEngine;

public class Part : MonoBehaviour
{
    public bool isUsed;
    public bool isDropped;

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
