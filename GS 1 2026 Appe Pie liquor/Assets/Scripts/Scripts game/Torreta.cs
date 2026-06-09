using System.Collections;
using UnityEngine;

public class Torreta : MonoBehaviour, IHit
{
    private float vida;
    [SerializeField] private float vidaTorreta;
    [SerializeField] private Transform target;
    [SerializeField] private Globais tiroInimigoPool;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform firePosition;


    private void OnEnable()
    {
        vida = vidaTorreta;
        StartCoroutine(FireRoutine());

    }
    private void OnDisable()
    {
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
    public void Hit(GameObject source)
    {
        if (vida > 0)
        {
            vida = vida - 1;
            PontoFraco vidaTotal = GetComponentInParent<PontoFraco>();
            if (vidaTotal != null)
            {
                vidaTotal.bossHP -= 1;
            }
        }
        else
        {
            vida = vidaTorreta;
            gameObject.SetActive(false);
        }
    }
}