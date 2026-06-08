using UnityEngine;
using UnityEngine.InputSystem;


public class Nelso : MonoBehaviour, IHit
{
    [SerializeField] private float speed;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float cD;
    private float internalCD;
    public Globais bulletPool;
    public Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Vector2.zero;
        internalCD = internalCD - Time.deltaTime;
        if (Mouse.current.leftButton.wasPressedThisFrame && internalCD <= 0)
        {
            GameObject friendlyBullet = bulletPool.GetFriendlyBullet();
            internalCD = cD;
            if (friendlyBullet != null)
            {
                friendlyBullet.transform.position = firePoint.position;
                friendlyBullet.transform.rotation = firePoint.rotation;
                friendlyBullet.SetActive(true);

                
            }
        }

        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;

        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        Vector2 nextPosition =
            rb.position + movement * speed * Time.fixedDeltaTime;

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.y = Mathf.Clamp(nextPosition.y, minY, maxY);

        rb.MovePosition(nextPosition);
    }
    public void Hit(GameObject source)
    {
        Debug.Log("Você foi atingido");
    }
}
