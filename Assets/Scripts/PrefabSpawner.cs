using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;   // t.ex. Particle System-prefaben
    [SerializeField] private Transform target;    // t.ex. spelaren – prefaben skapas som barn och följer med

    // Anropas från ett UnityEvent (t.ex. On Picked Up på QuestTrigger)
    public void Spawn()
    {
        if (prefab == null || target == null) return;
        Instantiate(prefab, target.position, Quaternion.identity, target);
    }
}
