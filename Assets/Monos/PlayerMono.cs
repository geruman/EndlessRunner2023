using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMono : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    
    [SerializeField] private LayerMask layerSuelo;
    [SerializeField] private LayerMask layerObstaculo;
    [SerializeField] private bool invincible;
    [SerializeField] private PlayerData _playerData;
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
        RaycastHit2D rayCastSuelo = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerSuelo);
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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==7&&!invincible)
        {
            rb.velocity = new Vector2(-6, 6);
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
            rb.velocity = new Vector2(0, _playerData.goingDownForce);
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
            rb.velocity = new Vector2(0, _playerData.doubleJumpForce);
            canDoubleJump=false;
        }
    }

    private void CheckJump()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&!animator.GetBool("isJumping"))
        {
            
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(0, _playerData.jumpForce);
        }
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
