using UnityEngine;

public class HitEffect : MonoBehaviour
//TODO: DELETE THIS
{
    private ParticleSystem particles;
    private AudioSource audioSource;

    void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (particles != null)
            particles.Play();

        if (audioSource != null)
            audioSource.Play();

        float maxDuration = 0f;

        if (particles != null)
        {
            var main = particles.main;
            maxDuration = main.duration + main.startLifetime.constantMax;
        }

        if (audioSource != null)
        {
            maxDuration = Mathf.Max(maxDuration, audioSource.clip.length);
        }

        Destroy(gameObject, maxDuration);
    }
}