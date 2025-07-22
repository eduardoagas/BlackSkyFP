using UnityEngine;

public class TargetLockSystem : MonoBehaviour
{
    public GameObject crosshairPrefab;
    private GameObject currentCrosshair;
    private Transform currentTarget;
    private PlayerVision vision;

    public Transform CurrentTarget { get => currentTarget; }

    private void Awake()
    {
        vision = GetComponent<PlayerVision>();
    }

    public void LockNearestTarget()
    {
        var enemies = vision.GetVisibleEnemies();
        if (enemies.Length == 0) return;

        Transform closest = enemies[0].transform;
        float minDist = Vector2.Distance(transform.position, closest.position);

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                closest = enemy.transform;
                minDist = dist;
            }
        }

        currentTarget = closest;
        if (currentCrosshair != null)
            Destroy(currentCrosshair);

        currentCrosshair = Instantiate(crosshairPrefab, currentTarget.position, Quaternion.identity, currentTarget);
    }
}
