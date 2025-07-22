using System.Collections;
using UnityEngine;

public class BirdPhaseController : MonoBehaviour
{
    [System.Serializable]
    public class BirdEvent
    {
        public GameObject birdObject;    // Agora referenciamos o GameObject já existente na cena
        public Vector2 targetPosition;
        public float delay;              // Tempo para ativar o pássaro
        public float moveDuration = 1.5f;
    }

    public BirdEvent[] birdEvents;

    void OnEnable()
    {
        // Inicialmente desativa todos os pássaros
        foreach (var e in birdEvents)
        {
            if (e.birdObject != null)
                e.birdObject.SetActive(false);
        }
        StartCoroutine(RunPhase());
    }

    IEnumerator RunPhase()
    {
        foreach (var e in birdEvents)
        {
            yield return new WaitForSeconds(e.delay);

            if (e.birdObject != null)
            {
                e.birdObject.SetActive(true);
                RectTransform rt = e.birdObject.GetComponent<RectTransform>();
                if (rt != null)
                {
                    StartCoroutine(MoveBird(rt, e.targetPosition, e.moveDuration));
                }
                else
                {
                    Debug.LogWarning("Bird object does not have RectTransform component.");
                }
            }
        }
    }

    IEnumerator MoveBird(RectTransform bird, Vector2 target, float duration)
    {
        Vector2 start = bird.anchoredPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            bird.anchoredPosition = Vector2.Lerp(start, target, elapsed / duration);
            yield return null;
        }
        bird.anchoredPosition = target;
    }
}
