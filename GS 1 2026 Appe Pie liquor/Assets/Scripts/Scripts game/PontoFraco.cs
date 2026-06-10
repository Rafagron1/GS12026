using UnityEngine;

public class PontoFraco : MonoBehaviour, IHit
{
    public float bossHP;
    private float speed = 2;
    [SerializeField] private GameObject overlayPanel;

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
            AbrirOverlay();
            gameObject.SetActive(false);
        }
    }
    public void AbrirOverlay()
    {
        overlayPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}