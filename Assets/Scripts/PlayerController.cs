using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    new Rigidbody2D rigidbody;
    [SerializeField] float speed;
    float size;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        size = transform.localScale.x;
    }

    void FixedUpdate()
    {
        rigidbody.velocity = Vector2.Lerp(
            rigidbody.velocity,
            moveInput * speed,
            0.1f
        );
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            Vector3.one * size,
            0.3f
        );
        Camera.main.orthographicSize = Mathf.Lerp(
            Camera.main.orthographicSize,
            size * (5 + rigidbody.velocity.magnitude * 0.04f),
            0.3f
        );
    }

    public void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
            return;
        if (collision.transform.localScale.x > transform.localScale.x)
            return;
        size += collision.transform.localScale.x / 2f;
        Camera.main.orthographicSize += collision.transform.localScale.x / 2f;
        Destroy(collision.gameObject);
    }
}
