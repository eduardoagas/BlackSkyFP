using UnityEngine;

public class BirdTarget : MonoBehaviour
{
    public void OnHit(WeaponEffectData weaponEffect)
    {
        Debug.Log("Bird hit!");
        HitEffectManager.Instance.ApplyHitEffect(transform.position, weaponEffect);
        gameObject.SetActive(false);

        GameObject panel = FindParentPanel();
        if (panel != null && AllBirdsInactive(panel))
        {
            panel.SetActive(false);
            Debug.Log("All birds gone. Deactivating panel: " + panel.name);
        }
    }

    GameObject FindParentPanel()
    {
        Transform current = transform;

        while (current != null)
        {
            if (current.name.Contains("MiniGamePanel"))
            {
                return current.gameObject;
            }
            current = current.parent;
        }

        return null;
    }

    bool AllBirdsInactive(GameObject panel)
    {
        // Procurar por todos os BirdTarget ativos abaixo do painel
        BirdTarget[] birds = panel.GetComponentsInChildren<BirdTarget>(includeInactive: false);
        return birds.Length == 0;
    }
}
