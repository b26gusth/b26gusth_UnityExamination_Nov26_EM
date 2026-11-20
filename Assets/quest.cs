using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private DialogueNPC npc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        npc.CompleteQuest();
        gameObject.SetActive(false);   // t.ex. ett föremål som "plockas upp"
    }
}