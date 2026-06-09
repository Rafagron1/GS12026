using UnityEngine;

public class PontoFraco : MonoBehaviour, IHit
{
    public float bossHP;
    private float speed = 2;

    private void Awake()
    {
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= 7)
        {
            speed = 0;
        }
    }
    public void Hit(GameObject source)
    {
        if (bossHP > 0)
        {
            bossHP -= 3;
        }
        else
        {
            Debug.Log("Cabo");
            gameObject.SetActive(false);
        }
    }
}