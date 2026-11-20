using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement8Dir : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;          // top-down: ingen gravitation
        rb.freezeRotation = true;      // karaktären ska inte snurra vid krockar
    }

    private void Update()
    {
        input = Vector2.zero;

        var kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.wKey.isPressed || kb.upArrowKey.isPressed)    input.y += 1;
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed)  input.y -= 1;
            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) input.x += 1;
            if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  input.x -= 1;
        }

        // Normalisera så att diagonalt inte går snabbare än rakt
        input = input.normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}