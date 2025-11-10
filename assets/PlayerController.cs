using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] float movementSpeed = 3f;
    float direction = 0f;

    [Header("Jumping")]
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float normalGravity = 3f;
    [SerializeField] float glideGravity = 0f;

    [Header("Stamina")]
    [SerializeField] float maxGlideStamina = 1.5f;
    [SerializeField] float glideDrainRate = 1f;
    [SerializeField] Image staminaFill;

    [Header("Slide")]
    [SerializeField] BoxCollider2D playerCollider;
    [SerializeField] float slideHeightFactor = 0.5f;

    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private bool isSliding = false;

    private bool isGrounded = false;
    private bool isGliding = false;
    private float glideStamina;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravity;
        glideStamina = maxGlideStamina;

        originalColliderSize = playerCollider.size;
        originalColliderOffset = playerCollider.offset;
    }
    private void Start()
    {
        
    }

    public void Update()
    {
        HandleGlide();
        UpdateUI();
    }
    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * movementSpeed, rb.linearVelocity.y);
    }

    public void MoveRight() => direction = 1.4f;
    public void MoveLeft() => direction = -1f;
    public void MoveStop() => direction = 0f;

    public void JumpButton()
    {
        if (!isGrounded || isSliding) return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    public void GlideButton()
    {
        if (isGrounded || glideStamina <= 0f) return;
        isGliding = true;
        rb.gravityScale = glideGravity;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
    }

    public void StopGlideButton()
    {
        isGliding = false;
        rb.gravityScale = normalGravity;
    }

    void HandleGlide()
    {
        if (isGliding)
        {
            glideStamina -= glideDrainRate * Time.deltaTime;
            if (glideStamina <= 0f)
            {
                glideStamina = 0f;
                StopGlideButton();
            }
        }
        else if (isGrounded && glideStamina < maxGlideStamina)
        {
            glideStamina += glideDrainRate * Time.deltaTime;
            if (glideStamina > maxGlideStamina) glideStamina = maxGlideStamina;
        }
    }

    public void SlideButtonDown()
    {
        if (!isGrounded || isSliding) return;
        isSliding = true;
        playerCollider.size = new Vector2(originalColliderSize.x, originalColliderSize.y * slideHeightFactor);
        playerCollider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - originalColliderSize.y * (1 - slideHeightFactor) / 2f);
    }

    public void SlideButtonUp()
    {
        if (!isSliding) return;
        isSliding = false;
        playerCollider.size = originalColliderSize;
        playerCollider.offset = originalColliderOffset;
    }

    void UpdateUI()
    {
        staminaFill.fillAmount = Mathf.Clamp01(glideStamina / maxGlideStamina);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            StopGlideButton();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
