using UnityEngine;

public class Tiros : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    

    private float timer;

    private void OnEnable()
    {
        timer = lifeTime;
        
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.CompareTag("Inimigo") || other.CompareTag("PowerUP"))
            {
                IHit receiver = other.GetComponent<IHit>();

                if (receiver != null)
                {
                    receiver.Hit(gameObject);
                }
                
                gameObject.SetActive(false);
            }
        
    }
}