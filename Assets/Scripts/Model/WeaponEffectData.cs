using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponEffect", menuName = "Weapons/Weapon Effect")]
public class WeaponEffectData : ScriptableObject
{
    public GameObject hitEffectPrefab;
    public AudioClip hitSound;
}
