using UnityEngine;

public class MouseController : MonoBehaviour
{

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    private Rigidbody2D playerRigidbody;
    public Transform groundCheckTransform;
    private bool isGrounded;
    public LayerMask groundCheckLayerMask;
    private Animator mouseAnimator;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        mouseAnimator = GetComponent<Animator>();

    }

    // Updates the grounded status of the player
    void UpdateGroundedStatus()
    {
        //1
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
        //2
        mouseAnimator.SetBool("isGrounded", isGrounded);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetpackForce));
        }
        Vector2 newVelocity = playerRigidbody.linearVelocity;
        newVelocity.x = forwardMovementSpeed;
        playerRigidbody.linearVelocity = newVelocity;
        UpdateGroundedStatus();
    }
}
