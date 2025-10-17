using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Animator animator;
    [SerializeField] private float XInput;
    [SerializeField] private float XMoveSpeed;
    [SerializeField] private float XJumpForce;

    [SerializeField] private SpriteRenderer tSpriteRenderer;

    [SerializeField] private Transform rayTransform;
    [SerializeField] private LayerMask targetMask;

     [Header("Audio")]
    [SerializeField] private AudioClip AttackingClip;

    private Rigidbody2D tRb;
    private bool isGrounded;
    private bool isLastOnRight;


    private void Start()
    {
        tRb = GetComponent<Rigidbody2D>();
        isLastOnRight = true;
    }

    public void SeXInput(float val)
    {
        XInput = val;
        if (XInput > 0 || XInput < 0)
        {
            isLastOnRight = XInput > 0;
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void Update()
    {
        tSpriteRenderer.flipX = !isLastOnRight;
    }

    private void FixedUpdate()
    {
        tRb.linearVelocityX = XInput * XMoveSpeed;
    }

    public void ApplyJump()
    {
        if (isGrounded == false) return;
        tRb.AddForce(Vector2.up * XJumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
        
    }

    public void ApplyAttacking()
    {
        Vector2 direction = isLastOnRight ? Vector2.right : Vector2.right * -1;
        RaycastHit2D isHit = Physics2D.Raycast(rayTransform.position, direction, 1, targetMask);
        animator.SetTrigger("Attacking");
        SoundManager.instance.PlaySFX(AttackingClip);
        
        Debug.DrawRay(rayTransform.position, direction * 1, Color.black, 100);
        if (isHit.collider != null)
        {
            Debug.Log("Hit Name : " + isHit.collider.name);
            EnemyMovement hitEnemy = isHit.collider.GetComponentInParent<EnemyMovement>();
            
            if (hitEnemy != null)
            {
                Destroy(hitEnemy.gameObject);
                
            }
        }
    }
       

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGround", true);

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        animator.SetBool("isGround", false);
    }




}
