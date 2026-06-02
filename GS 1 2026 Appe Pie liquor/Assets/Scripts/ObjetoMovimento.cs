using UnityEngine;

public class ObjetoMovimento : MonoBehaviour
{
    [SerializeField] private float speedx;
    [SerializeField] private float speedy;
    [SerializeField] private float lifeTime;
    [SerializeField] private bool isTimed;

    private float timer;

    private void OnEnable()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speedx * Time.deltaTime);
        transform.Translate(Vector2.up * speedy * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0 && isTimed)
        {
            gameObject.SetActive(false);
        }
    }
}
