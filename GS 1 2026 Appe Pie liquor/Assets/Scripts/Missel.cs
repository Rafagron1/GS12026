using UnityEngine;

public class Missel : MonoBehaviour, IHit
{
    [Header("Alvo")]
    public Transform target;

    [Header("Perseguição")]
    public float trackingSpeed = 3f;
    public float trackingDuration = 3f;

    [Header("Investida")]
    public float dashSpeed = 8f;

    private float timer;
    private bool isTracking = true;

    private Vector3 lastKnownPosition;
    private Vector3 dashDirection;
    private float vida = 1;
    private EnemySpawner meuSpawner;

    private void OnEnable()
    {
        timer = trackingDuration;
        isTracking = true;
    }

    private void Update()
    {
        if (isTracking)
        {
            TrackTarget();
        }
        else
        {
            DashToLastPosition();
        }
    }
    public void DefinirSpawner(EnemySpawner spawner)
    {
        meuSpawner = spawner;
    }

    private void TrackTarget()
    {
        if (target == null)
            return;

        timer -= Time.deltaTime;

        lastKnownPosition = target.position;

        Vector3 direction =
            (target.position - transform.position).normalized;

        transform.position += direction * trackingSpeed * Time.deltaTime;

        // Opcional: faz o objeto olhar para o alvo
        float angle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle+180);

        if (timer <= 0)
        {
            isTracking = false;

            dashDirection =
                (lastKnownPosition - transform.position).normalized;
        }
    }

    private void DashToLastPosition()
    {
        transform.position += dashDirection * dashSpeed * Time.deltaTime;

        // Mantém a rotação da investida
        float angle =
            Mathf.Atan2(dashDirection.y, dashDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle+180);
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
    public void Initialize(Transform player)
    {
        this.target = player;
    }
    public void Hit(GameObject source)
    {
        if (vida > 0)
        {
            vida = vida - 1;
        }
        else
        {
            if (meuSpawner != null)
                meuSpawner.Liberar();
            vida = 1;
            gameObject.SetActive(false);
        }
    }
}