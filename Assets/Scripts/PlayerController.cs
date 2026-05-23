using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Lane Movement")]
    [SerializeField] private float[] lanePositions = { -2f, 0f, 2f };
    [SerializeField] private float laneMoveDuration = 0.2f;

    [Header("Jump")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Transform playerVisual;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string jumpingBoolName = "jumping";

    private int currentLane = 1;
    private bool isGrounded = true;
    private Tween laneTween;

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        Vector3 startPosition = transform.position;
        startPosition.x = lanePositions[currentLane];
        transform.position = startPosition;

        SetJumping(false);
    }

    public void MoveLeft()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        if (currentLane <= 0) return;

        currentLane--;
        MoveToLane();
    }

    public void MoveRight()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        if (currentLane >= lanePositions.Length - 1) return;

        currentLane++;
        MoveToLane();
    }

    private void MoveToLane()
    {
        laneTween?.Kill();

        laneTween = transform.DOMoveX(lanePositions[currentLane], laneMoveDuration)
            .SetEase(Ease.OutQuad);
    }

    public void Jump()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        if (!isGrounded) return;

        isGrounded = false;
        SetJumping(true);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (playerVisual != null)
        {
            playerVisual.DOPunchScale(Vector3.one * 0.15f, 0.2f, 5, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            SetJumping(false);
        }
    }

    private void SetJumping(bool value)
    {
        if (animator != null)
        {
            animator.SetBool(jumpingBoolName, value);
        }
    }
}