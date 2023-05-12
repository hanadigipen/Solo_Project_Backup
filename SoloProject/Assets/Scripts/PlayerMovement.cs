using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    public bool cubeIsOnTheGround = true;

  

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        // For moving left and right
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -2)
        {
            // if the players position is -5 kill the player
            Die();
        }

        if(Input.GetKeyDown(KeyCode.Space) && cubeIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            cubeIsOnTheGround = true;
        }
    }

    public void Die()
    {
        alive = false;
        // restart game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // will reload scene we are currently in
    }

    
}
