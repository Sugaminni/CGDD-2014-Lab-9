using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    //1
    public Renderer background;
    public Renderer foreground;
    //2
    public float backgroundSpeed = 0.02f;
    public float foregroundSpeed = 0.06f;
    //3
    public float offset = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // increases the offset based on time
    void Update()
    {
        float backgroundOffset = offset * backgroundSpeed;
        float foregroundOffset = offset * foregroundSpeed;

        background.material.mainTextureOffset = new Vector2(backgroundOffset, 0);
        foreground.material.mainTextureOffset = new Vector2(foregroundOffset, 0);
    }
}
