using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 moveDirection;

    public void Launch(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        // Opcional: desativa após alguns segundos
        CancelInvoke();
        Invoke(nameof(DisableProjectile), 2f);
    }

    void DisableProjectile()
    {
        gameObject.SetActive(false);
    }
}