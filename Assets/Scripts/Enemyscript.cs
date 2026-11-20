using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemyscript : MonoBehaviour
{
    [Header("Rörelse")]
    [SerializeField] private float distance = 2f;   // hur långt upp/ner från startpositionen
    [SerializeField] private float speed = 2f;      // hur snabbt den åker

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Åker mjukt upp och ner runt startpositionen
        float offsetY = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + new Vector3(0f, offsetY, 0f);
    }

    // Om enemyns collider har "Is Trigger" ibockat
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) KillPlayer();
    }

    // Om enemyns collider INTE är trigger
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) KillPlayer();
    }

    private void KillPlayer()
    {
        // Spelaren "dör" och scenen startar om från början
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
