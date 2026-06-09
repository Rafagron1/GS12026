using UnityEngine;

public class ObjetoMovimento : MonoBehaviour, IHit
{
    [SerializeField] private float speedx;
    [SerializeField] private float speedy;
    [SerializeField] private float lifeTime;
    [SerializeField] private bool isTimed;
    private float vida = 3;

    private float timer;

    private void OnEnable()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        transform.position += Vector3.right * speedx * Time.deltaTime;
        transform.Translate(Vector2.up * speedy * Time.deltaTime);
        transform.Rotate(0f, 0f, 40 * Time.deltaTime);
    

        timer -= Time.deltaTime;

        if (timer <= 0 && isTimed)
        {
            gameObject.SetActive(false);
        }
    }
    public void Hit(GameObject source)
    {
        if (vida > 0)
        {
            vida = vida - 1;
        }
        else
        {
            vida = 3;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jogador"))
        {
            IHit receiver =
                other.GetComponent<IHit>();

            if (receiver != null)
            {
                receiver.Hit(gameObject);
            }

            gameObject.SetActive(false);
        }
    }
}
