using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [SerializeField] private string idItem = "item_01";
    [SerializeField] private float speedx;
    private void Start()
    {
        VerificarEstado();
    }
    private void Update()
    {
        transform.position += Vector3.right * speedx * Time.deltaTime;
        transform.Rotate(0f, 0f, 60 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jogador"))
        {
            Coletar();
        }
    }

    public void Coletar()
    {
        PlayerPrefs.SetInt(idItem, 1);
        PlayerPrefs.Save();

        gameObject.SetActive(false);
    }

    private void VerificarEstado()
    {
        if (PlayerPrefs.GetInt(idItem, 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
