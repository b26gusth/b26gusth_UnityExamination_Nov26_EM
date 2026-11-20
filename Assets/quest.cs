using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private DialogueNPC npc;

    [SerializeField] private ParticleSystem particles;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Instantiate(particles, other.transform.position, Quaternion.identity, other.transform);
        npc.CompleteQuest();
        gameObject.SetActive(false);   // t.ex. ett föremål som "plockas upp"
    }
}