using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    public float playerSpeed = 1f;
    public float jumpSpeed = 1f,jumpNextTime,jumpFrequency=1f;
    public Transform groundCheckTransform;
    public float groundRadius;
    public LayerMask groundLayer;
    private bool facingRight = true;
    private bool isGround = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        if (playerRB.velocity.x < 0 && facingRight)
            FlipFace();
        else if (playerRB.velocity.x > 0 && !facingRight)
            FlipFace();
        if(Input.GetAxis("Vertical")>0&&isGround&&(jumpNextTime<Time.timeSinceLevelLoad))
        {
            jumpNextTime = Time.timeSinceLevelLoad + jumpFrequency;
            playerjump();
        }    
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, playerRB.velocity.y);    
        playerAnimator.SetFloat("playerSpeed",Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void playerjump()
    {
        playerRB.AddForce(new Vector2(0,jumpSpeed));
    }

    void onGroundCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheckTransform.position, groundRadius,groundLayer);
        playerAnimator.SetBool("playerJump",isGround);
    }
}