using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMono : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    
    [SerializeField] private LayerMask layerSuelo;
    [SerializeField] private LayerMask layerObstaculo;
    [SerializeField] private bool invincible;

    bool canDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayCastSuelo = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layerSuelo);

        if (rayCastSuelo==true)
        {
            TouchGround();
            CheckJump();

        }
        else
        {
            CheckDoubleJump();
            CheckIfDoubleJumpFinished();
            CheckIfJumpFinished();
            CheckGoingDown();
            
        }




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==7&&!invincible)
        {
            if(collision.gameObject.tag == "PushUp")
            {
                this.transform.position = new Vector2(transform.position.x, transform.position.y+0.5f);
            }
            animator.SetBool("pepsi", true);
        }

    }

    private void CheckIfJumpFinished()
    {
        if (animator.GetBool("isJumping")&&rb.velocity.y<=0)
        {
            animator.SetBool("isFallingFromJump", true);
        }
    }

    private void CheckGoingDown()
    {
        if (Input.GetKey(KeyCode.DownArrow)&&!animator.GetBool("isGoingDown"))
        {
            animator.SetBool("isGoingDown", true);
            rb.velocity = new Vector2(0, -7);
            canDoubleJump = false;

        }
    }

    private void CheckIfDoubleJumpFinished()
    {
        if (animator.GetBool("isDoubleJumping")&&rb.velocity.y<=0)
        {
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isFallingFromJump", true);
        }

    }

    private void TouchGround()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isGoingDown", false);
        animator.SetBool("isDoubleJumping", false);
        animator.SetBool("isFallingFromJump", false);
        canDoubleJump = true;
    }

    private void CheckDoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&!animator.GetBool("isDoubleJumping")&&canDoubleJump)
        {
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isFallingFromJump", false);
            animator.SetBool("isDoubleJumping", true);
            rb.velocity = new Vector2(0, 7);
            canDoubleJump=false;
        }
    }

    private void CheckJump()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&!animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(0, 9);
        }
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
