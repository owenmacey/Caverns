using UnityEngine;

public class movement : MonoBehaviour
{
    //Movement variables
    public float speed = 5f; // Speed of the object
    private Rigidbody2D rb;
    private float moveInput;

    //Jumping variables
    public float jumpForce = 10f;    // How high the player jumps
    private bool isGrounded;          // Is the player touching the ground?
    public Transform groundCheck;     // Empty GameObject at player's feet for checking ground
    public float checkRadius = 0.2f;  // Radius for ground check circle
    public LayerMask whatIsGround;    // Layer(s) considered ground
    private bool jumpRequest = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Move the player

        if (jumpRequest)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequest = false;
        }
    }
}
