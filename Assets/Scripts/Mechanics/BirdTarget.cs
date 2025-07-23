using UnityEngine;

public class BirdTarget : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Awake()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void OnHit()
    {
        Debug.Log("Bird hit!");

        HitEffectManager.Instance?.ApplyWorldHitEffect(transform.position);

        gameObject.SetActive(false);

        GameObject panel = FindParentPanel();
        if (panel != null && AllBirdsInactive(panel))
        {
            panel.SetActive(false);
            Debug.Log("All birds gone. Deactivating panel: " + panel.name);
        }
    }

    public void ResetBird()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        gameObject.SetActive(true);
    }

    GameObject FindParentPanel()
    {
        Transform current = transform;
        while (current != null)
        {
            if (current.name.Contains("MiniGamePanel"))
                return current.gameObject;
            current = current.parent;
        }
        return null;
    }

    bool AllBirdsInactive(GameObject panel)
    {
        BirdTarget[] birds = panel.GetComponentsInChildren<BirdTarget>(includeInactive: false);
        return birds.Length == 0;
    }
}
