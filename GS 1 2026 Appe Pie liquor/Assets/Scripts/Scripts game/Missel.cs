using UnityEngine;

public class Missel : MonoBehaviour, IHit
{
    [SerializeField] private Transform target;

    public float trackingSpeed = 3f;
    public float trackingDuration = 3f;
    public float dashSpeed = 8f;

    private float timer;
    private bool isTracking = true;

    private Vector3 lastKnownPosition;
    private Vector3 dashDirection;

    private float vida = 1;

    private void OnEnable()
    {
        timer = trackingDuration;
        isTracking = true;
    }

    private void Update()
    {
        if (isTracking)
            TrackTarget();
        else
            DashToLastPosition();
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

        float angle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + 180);

        if (timer <= 0)
        {
            isTracking = false;
            dashDirection = (lastKnownPosition - transform.position).normalized;
        }
    }

    private void DashToLastPosition()
    {
        transform.position += dashDirection * dashSpeed * Time.deltaTime;

        float angle =
            Mathf.Atan2(dashDirection.y, dashDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + 180);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jogador"))
        {
            IHit receiver = other.GetComponent<IHit>();

            if (receiver != null)
                receiver.Hit(gameObject);

            gameObject.SetActive(false);
        }
    }

    public void Hit(GameObject source)
    {
        if (vida > 0)
        {
            vida--;
        }
        else
        {
            vida = 1;
            gameObject.SetActive(false);
        }
    }
}