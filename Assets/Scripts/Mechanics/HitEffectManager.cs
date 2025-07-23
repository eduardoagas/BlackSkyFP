using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    public static HitEffectManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ApplyHitEffect(Vector3 worldPosition, WeaponEffectData weaponEffect)
    {
        if (weaponEffect == null) return;

        if (weaponEffect.hitEffectPrefab != null)
        {
            Instantiate(weaponEffect.hitEffectPrefab, worldPosition, Quaternion.identity);
        }

        if (weaponEffect.hitSound != null)
        {
            AudioSource.PlayClipAtPoint(weaponEffect.hitSound, worldPosition);
        }
    }
}
