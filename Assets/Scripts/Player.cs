using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private const float gravity = 9.8f;
    public float flying = 3f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private float rotationSpeed = 7f;
    private float rotationAngle = 45f;
    private Quaternion targetRotation;

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.1f, 0.1f);
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            direction = Vector3.up * flying;
        }
        direction.y += -gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        if (direction.y > 0)
        {
            targetRotation = Quaternion.Euler(0, 0, rotationAngle);
        }
        else
        {
            targetRotation = Quaternion.Euler(0, 0, -rotationAngle);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Crash")
        {
            Object.FindFirstObjectByType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            Object.FindFirstObjectByType<GameManager>().Scoring();
        }
    }

    public void ResetPosition()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        transform.rotation = Quaternion.identity;
        direction = Vector3.zero;
    }
}
