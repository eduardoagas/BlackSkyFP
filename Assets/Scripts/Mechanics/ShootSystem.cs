using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public LayerMask obstacleMask;
    private TargetLockSystem lockSystem;
    public WeaponEffectData weaponEffect;

    void Awake()
    {
        lockSystem = GetComponent<TargetLockSystem>();
    }

    public void TryShoot()
    {
        Transform target = lockSystem.CurrentTarget;
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.position);

        Debug.DrawRay(transform.position, direction * distance, Color.red, 5f);
        // Se houver obstáculo no caminho, cancela
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, obstacleMask);
        if (hit.collider != null)
        {
            Debug.Log("Obstáculo no caminho!");
            return;
        }

        Debug.Log("Acertou o alvo!");
        HitEffectManager.Instance.ApplyWorldHitEffect(target.position);
        MiniGameManager.Instance.StartKillTheBirdMiniGame();
    }

}
