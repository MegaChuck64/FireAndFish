using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float jumpForce;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new(0, 0, vertical);//not using horizontal
        rb.AddRelativeForce(movement * moveSpeed);

        // Rotate the player horizontally
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new(0, mouseX, 0);
        transform.Rotate(rotateSpeed * Time.deltaTime * rotation);

        // rotate the player to look up and down
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 cameraRotation = new(-mouseY, 0, 0);
        Camera.main.transform.Rotate(rotateSpeed * Time.deltaTime * cameraRotation);
        


        // Jump the player
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        
        //if not moving then stop
        if (horizontal == 0 && vertical == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        //clamp speed
        rb.velocity = new Vector3(
            Mathf.Clamp(
                rb.velocity.x, -moveSpeed, moveSpeed), 
                rb.velocity.y, 
                Mathf.Clamp(rb.velocity.z, -moveSpeed, moveSpeed));
    }
}
