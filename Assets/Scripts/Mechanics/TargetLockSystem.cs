using UnityEngine;

public class TargetLockSystem : MonoBehaviour
{
    public GameObject crosshairPrefab;
    private GameObject currentCrosshair;
    private Transform currentTarget;
    private PlayerVision vision;

    public float lockLossDelay = 0.3f; // tempo em segundos antes de perder o lock
    private float lockLossTimer = 0f;

    public Transform CurrentTarget { get => currentTarget; }

    private void Awake()
    {
        vision = GetComponent<PlayerVision>();
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            ClearLock();
            return;
        }

        if (!IsTargetStillVisible())
        {
            lockLossTimer += Time.deltaTime;
            if (lockLossTimer >= lockLossDelay)
            {
                ClearLock();
            }
        }
        else
        {
            lockLossTimer = 0f; // reset do timer se alvo visível
        }
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

    private bool IsTargetStillVisible()
    {
        var enemies = vision.GetVisibleEnemies();
        foreach (var enemy in enemies)
        {
            if (enemy.transform == currentTarget)
                return true;
        }
        return false;
    }

    private void ClearLock()
    {
        currentTarget = null;

        if (currentCrosshair != null)
        {
            Destroy(currentCrosshair);
            currentCrosshair = null;
        }
    }
}
