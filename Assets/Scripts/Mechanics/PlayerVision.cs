using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float[] visionRadii = { 3f, 5f, 10f };
    public LayerMask enemyLayer;
    private int currentIndex = 1;

    public bool showVisionGizmos = true;

    public float CurrentRadius => visionRadii[currentIndex];

    public void ToggleRadius()
    {
        currentIndex = (currentIndex + 1) % visionRadii.Length;
    }

    public Collider2D[] GetVisibleEnemies()
    {
        return Physics2D.OverlapCircleAll(transform.position, CurrentRadius, enemyLayer);
    }

    private void OnDrawGizmos()
    {
        if (!showVisionGizmos) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, CurrentRadius);
    }
}
