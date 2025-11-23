using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    private Rigidbody2D playerRigidbody;
    public Transform groundCheckTransform;
    private bool isGrounded;
    public LayerMask groundCheckLayerMask;
    private Animator mouseAnimator;
    public ParticleSystem jetpack;
    private bool isDead = false;
    private uint coins = 0;

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

    // Handles collecting coins
    void CollectCoin(Collider2D coinCollider)
    {
        coins++;
        Destroy(coinCollider.gameObject);
    }


    // Handles collision with lasers and coins
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coins"))
        {
            CollectCoin(collider);
        }
        else
        {
            HitByLaser(collider);
        }

    }

    // Marks the player as dead when hit by a laser
    void HitByLaser(Collider2D laserCollider)
    {
        isDead = true;
        mouseAnimator.SetBool("isDead", true);
    }


    // Adjusts the jetpack particle system based on whether the jetpack is active
    void AdjustJetpack(bool jetpackActive)
    {
        var jetpackEmission = jetpack.emission;
        jetpackEmission.enabled = !isGrounded;
        if (jetpackActive)
        {
            jetpackEmission.rateOverTime = 300.0f;
        }
        else
        {
            jetpackEmission.rateOverTime = 75.0f;
        }
    }


    // Ensures mouse movement and jetpack functionality as well as death status
    void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        jetpackActive = jetpackActive && !isDead;

        if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetpackForce));
        }

        if (!isDead)
        {
            Vector2 newVelocity = playerRigidbody.linearVelocity;
            newVelocity.x = forwardMovementSpeed;
            playerRigidbody.linearVelocity = newVelocity;
        }

        UpdateGroundedStatus();
        AdjustJetpack(jetpackActive);


    }
}
