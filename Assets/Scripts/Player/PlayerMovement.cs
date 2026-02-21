using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private InputHandler input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputHandler>();
    }

    void Update()
    {
        // Use the MoveInput from our InputHandler
        rb.linearVelocity = input.MoveInput * speed;

        if (input.MoveInput.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
        } 
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}