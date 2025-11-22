using UnityEngine;

public class MouseController : MonoBehaviour
{

    public float jetpackForce = 75.0f;
    private Rigidbody2D playerRigidbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate() 
    {
    bool jetpackActive = Input.GetButton("Fire1");
    if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetpackForce));
        }
    }
}
