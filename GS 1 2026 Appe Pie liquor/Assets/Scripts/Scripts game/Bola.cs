using UnityEngine;

public class Bola : MonoBehaviour, IHit
{
    [SerializeField] private float speedx;
    [SerializeField] private float kickForce = 8f;
    [SerializeField] private float lifeTime;

    private Rigidbody2D rb;
    private bool energized;
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnEnable()
    {
        timer = lifeTime;
    }
    private void Update()
    {
        if (!energized)
        {
            transform.Translate(Vector2.right * speedx * Time.deltaTime);
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Hit(GameObject source)
    {
        Vector2 direction =
            ((Vector2)transform.position -
             (Vector2)source.transform.position).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * kickForce, ForceMode2D.Impulse);

        energized = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!energized)
            return;

        if (other.CompareTag("Inimigo"))
        {
            IHit receiver =
                other.GetComponent<IHit>();

            if (receiver != null)
            {
                receiver.Hit(gameObject);
            }
        }
    }
}