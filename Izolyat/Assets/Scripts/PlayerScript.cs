using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 20f;
    public int jumpForce = 16000;
    private Rigidbody2D rb;

    private bool faceRight = true;
    int inMove = 0;
    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float moveX = Input.GetAxis("Horizontal");
        
        rb.MovePosition(rb.position + Vector2.right*moveX*speed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * jumpForce);

        if (moveX > 0 && !faceRight)
            flip();
        else if (moveX < 0 && faceRight)
            flip();

        if (moveX == 0)
            inMove = 0;
        else
            inMove = 1;

        ChangeAnimation();
    }

    void ChangeAnimation()
    {
        animator.SetInteger("inMove", inMove);
    }
    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    }

    void InMovie()
    {
        
    }
}
