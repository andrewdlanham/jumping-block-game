using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // PlayerMovement Script
    public PlayerMovement movement;

    // Rigidbody componenet
    public Rigidbody rb;

    // Initialize variables
    public float forwardForce;
    public float sidewaysForce;
    public float jumpForce;
    public float fastFallForce;
    public Vector3 defaultRotation;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        forwardForce = 2000f;
        sidewaysForce = 100f;
        jumpForce = 500f;
        fastFallForce = -500f;
    }

    // Fixed update function for physics
    void FixedUpdate()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            if (canJump) {
                rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                canJump = false;
                Debug.Log("Jumped");
            }
            
        }

        if (Input.GetKey("s"))
        {
            transform.rotation = Quaternion.Euler(defaultRotation);
            rb.AddForce(0, fastFallForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f) 
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }

        if (collisionInfo.collider.tag ==  "Ground")
        {
            canJump = true;
        }
    }

}
