using UnityEngine;
using UnityEngine.Events;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private DialogueNPC npc;

    // Körs när spelaren plockar upp föremålet.
    // Koppla t.ex. PrefabSpawner.Spawn hit i Inspector.
    [SerializeField] private UnityEvent onPickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        npc.CompleteQuest();
        onPickedUp.Invoke();
        gameObject.SetActive(false);   // föremålet "plockas upp"
    }
}
