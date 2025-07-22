using UnityEngine;

public class CrosshairFollow : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
            transform.position = target.position;
    }
}
