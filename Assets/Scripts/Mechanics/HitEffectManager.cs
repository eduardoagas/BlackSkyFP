using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    public static HitEffectManager Instance { get; private set; }

    [Header("World Effects")]
    public GameObject worldHitEffectPrefab;
    public AudioClip hitSound;

    [Header("UI Effects")]
    public GameObject uiHitEffectPrefab;
    public Canvas uiCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ApplyWorldHitEffect(Vector3 position)
    {
        if (worldHitEffectPrefab != null)
            Instantiate(worldHitEffectPrefab, position, Quaternion.identity);

        if (hitSound != null)
            AudioSource.PlayClipAtPoint(hitSound, position);
    }

    public void ApplyUIHitEffect(Vector3 screenPosition)
    {
        if (uiCanvas == null || uiHitEffectPrefab == null)
            return;

        Vector2 uiPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiCanvas.transform as RectTransform,
            screenPosition,
            uiCanvas.worldCamera,
            out uiPosition
        );

        GameObject effect = Instantiate(uiHitEffectPrefab, uiCanvas.transform);
        effect.GetComponent<RectTransform>().anchoredPosition = uiPosition;
    }
}
