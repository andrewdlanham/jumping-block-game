using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Rigidbody componenet
    public Rigidbody rb;

    // Initialize variables
    public float forwardForce = 250f;
    public float sidewaysForce = 100f;
    public float jumpForce = 100f;
    public float fastFallForce = -500f;
    public Vector3 defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        /*
        rb.useGravity = false;
        rb.AddForce(0, 200, 500);
        */
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
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
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
}
