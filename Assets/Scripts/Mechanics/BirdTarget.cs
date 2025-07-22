using UnityEngine;

public class BirdTarget : MonoBehaviour
{
    public void OnHit()
    {
        Debug.Log("Bird hit!");
        Destroy(gameObject); // ou faça uma animação de morte
    }
}
