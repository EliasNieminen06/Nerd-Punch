using System.Collections;
using UnityEngine;

public class Nerd2MovementManual : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float airSpeed = 2f;
    [SerializeField] private float jumpingPower = 8f;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] public bool attacked = false;
    [SerializeField] private bool waited = false;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal2");

        if (Input.GetButtonDown("Jump2") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump2") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        if (attacked)
        {
            if (waited)
            {
                if (IsGrounded())
                {
                    attacked = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!attacked)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            } 
            else
            {
                rb.velocity = new Vector2(horizontal * airSpeed, rb.velocity.y);
            }

        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Attacked()
    {
        wait();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator wait()
    {
        waited = false;
        yield return new WaitForSeconds(0.2f);
        waited = true;
    }
}
