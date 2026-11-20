using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueNPC : MonoBehaviour
{
    [Header("NPC")]
    [SerializeField] private string npcName = "Greta";

    [Header("Dialog")]
    [TextArea] [SerializeField] private string[] firstMeetingLines;   // första gången man pratar
    [TextArea] [SerializeField] private string[] notDoneLines;        // pratar igen, uppgiften inte klar
    [TextArea] [SerializeField] private string[] doneLines;           // uppgiften är klar

    [Header("UI")]
    [SerializeField] private TMP_Text dialogueText;

    private bool playerInRange;
    private bool hasTalked;
    private bool questDone;

    private string[] currentLines;
    private int lineIndex;
    private bool isTalking;

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        if (!playerInRange || Keyboard.current == null) return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!isTalking) StartDialogue();
            else NextLine();
        }
    }

    // Anropa från QuestTrigger eller ett UnityEvent
    public void CompleteQuest()
    {
        questDone = true;
    }

    private void StartDialogue()
    {
        if (questDone)        currentLines = doneLines;
        else if (!hasTalked)  currentLines = firstMeetingLines;
        else                  currentLines = notDoneLines;

        if (currentLines == null || currentLines.Length == 0) return;

        hasTalked = true;      // räknas som pratat direkt när första samtalet startar
        isTalking = true;
        lineIndex = 0;
        ShowLine();
    }

    private void NextLine()
    {
        lineIndex++;
        if (lineIndex < currentLines.Length) ShowLine();
        else EndDialogue();
    }

    private void EndDialogue()
    {
        isTalking = false;
        if (playerInRange) ShowPrompt();
        else Hide();
    }

    private void ShowLine()
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = $"<b>{npcName}:</b> {currentLines[lineIndex]}";
    }

    private void ShowPrompt()
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = $"Tryck E för att prata med {npcName}";
    }

    private void Hide()
    {
        dialogueText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;
        ShowPrompt();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
        isTalking = false;
        Hide();
    }
}