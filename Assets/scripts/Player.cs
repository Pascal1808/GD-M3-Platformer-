using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int coins;
    public int health = 100;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Image healthImage;
    public AudioClip jumpClip;
    public AudioClip HurtClip;
    
    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;

    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    
    public int extraJumpsValue = 1;
    private int extraJumps;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            audioSource = GetComponent<AudioSource>();

            extraJumps = extraJumpsValue;
        }

        void Update()
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            if(rb.linearVelocity.x != 0)
            {
                if(rb.linearVelocity.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            if(isGrounded)
            {
                extraJumps = extraJumpsValue;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isGrounded)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
                    PlaySFX(jumpClip);
                }
                else if(extraJumps > 0)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                    extraJumps--;
                    PlaySFX(jumpClip);
                }

            }
            SetAnimation(moveInput);

            healthImage.fillAmount = health / 100f;
        }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if(moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Run");
            }
        }
        else
        {
            if(rb.linearVelocityY > 0)
            {
                animator.Play("Player_jump");
            }
            else
            {
                animator.Play("Player_Fall");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Damage")
       {
            PlaySFX(HurtClip);
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce / 2); 
            StartCoroutine(BlinkRed());

            if(health <= 0)
            {
                Die();
            }
       } 
        else if(collision.gameObject.tag == "BouncePad")
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 2); 
             PlaySFX(jumpClip);
        }
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void PlaySFX(AudioClip audioclip, float volume = 1f)
    {
        audioSource.clip = audioclip;
        audioSource.volume = volume;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "StrawBerry")
        {
            extraJumpsValue = 2;
            Destroy(collision.gameObject);
        }
    }
}