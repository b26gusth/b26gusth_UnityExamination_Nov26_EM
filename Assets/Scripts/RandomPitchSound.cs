using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomPitchSound : MonoBehaviour
{
    [SerializeField] private float minPitch = 0.7f;
    [SerializeField] private float maxPitch = 1.4f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // Spelar ljudet med slumpad pitch. Kan också anropas från ett UnityEvent.
    public void Play()
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }

    // Spelar ljudet när spelaren går in i triggern
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Play();
    }
}