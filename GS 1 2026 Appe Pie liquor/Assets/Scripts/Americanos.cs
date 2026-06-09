using System.Collections;
using UnityEditor.EditorTools;
using UnityEngine;

public class Americanos : MonoBehaviour, IHit
{
    [Header("Movimento")]
    public float moveSpeed = 2f;
    public float moveDuration = 1f;


    [Header("Disparo")]
    private Transform target;
    private Globais tiroInimigoPool;
    public float fireRate = 1f;
    private Transform firePosition;

    private EnemySpawner meuSpawner;
    private float vida = 2f;
    private void Awake()
    {
        if (transform.childCount > 0)
        {
            firePosition = transform.GetChild(0);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(MoveRoutine());
        StartCoroutine(FireRoutine());
    }

    IEnumerator MoveRoutine()
    {
        float timer = 0f;

        while (timer < moveDuration)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(1f / fireRate);
        }
    }

        void Fire()
    {
        GameObject bullet = tiroInimigoPool.GetEnemyBullet();

        if (bullet == null)
            return;

        
        bullet.transform.position = firePosition.position;

        
        Vector3 direction =
            (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        bullet.SetActive(true);

        TiroInimigo projectile = bullet.GetComponent<TiroInimigo>();

        if (projectile != null)
        {
            projectile.Launch(direction);
        }
    }
    public void DefinirSpawner(EnemySpawner spawner)
    {
        meuSpawner = spawner;
    }
    public void Initialize(Transform player, Globais poolManager)
    {
        this.target = player;
        this.tiroInimigoPool = poolManager;
    }
    public void Hit(GameObject source)
    {
        if (vida > 0)
        {
            vida = vida-1;
        }
        else
        {
            if (meuSpawner != null)
                meuSpawner.Liberar();
            vida = 2;
            gameObject.SetActive(false);
        }
    }
}
