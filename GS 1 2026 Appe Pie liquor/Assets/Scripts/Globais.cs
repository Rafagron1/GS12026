using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Globais : MonoBehaviour
{
    [SerializeField] private GameObject friendlyBulletPrefab;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject misselPrefab;
    [SerializeField] private GameObject powerPrefab;
    [SerializeField] private GameObject asteroidePrefab;
    private int poolShotSize = 50;
    private int enemyShotPool = 200;
    private int enemyPoolSize = 10;
    private int misselPoolSize = 30;
    private int powerPoolSize = 5;
    private int asteroidePoolSize = 10;
    private GameObject[] friendlyBullets;
    private GameObject[] enemyBullets;
    private GameObject[] enemies;
    private GameObject[] misseis;
    private GameObject[] powers;
    private GameObject[] asteroides;
    [SerializeField] private Transform jogador;
    [SerializeField] private EnemySpawner[] spawners;

    private float fase1Duracao = 30f;
    private float fase2Duracao = 45f;
    private float fase3Duracao = 60f;
    private Vector3 powerUpPos = new Vector3(11.5f, 0f, 0f);
    private Coroutine spawnRoutine;

    private void Awake()
    {
        friendlyBullets = new GameObject[poolShotSize];
        for (int i = 0; i < poolShotSize; i++)
        {
            friendlyBullets[i] = Instantiate(friendlyBulletPrefab);
            friendlyBullets[i].SetActive(false);
        }
        enemyBullets = new GameObject[enemyShotPool];
        for (int i = 0; i < enemyShotPool; i++)
        {
            enemyBullets[i] = Instantiate(enemyBulletPrefab);
            enemyBullets[i].SetActive(false);
        }
        enemies = new GameObject[enemyPoolSize];
        for (int i = 0; i < enemyPoolSize; i++)
        {
            enemies[i] = Instantiate(enemyPrefab);
            //enemies[i].SetActive(false);
            enemies[i].GetComponent<Americanos>().Initialize(jogador, this);
        }
        misseis = new GameObject[misselPoolSize];
        for (int i = 0; i < misselPoolSize; i++)
        {
            misseis[i] = Instantiate(misselPrefab);
            //enemies[i].SetActive(false);
            misseis[i].GetComponent<Missel>().Initialize(jogador);
        }
        powers = new GameObject[powerPoolSize];
        for (int i = 0; i < powerPoolSize; i++)
        {
            powers[i] = Instantiate(powerPrefab);
            powers[i].SetActive(false);
        }
        asteroides = new GameObject[asteroidePoolSize];
        for (int i = 0; i < asteroidePoolSize; i++)
        {
            asteroides[i] = Instantiate(asteroidePrefab);
            asteroides[i].SetActive(false);
        }
    }
    private void Start()
    {
        spawnRoutine = StartCoroutine(ControleDeFases());
    }
    void Update()
    {

    }
    public GameObject GetFriendlyBullet()
    {
        for (int i = 0; i < friendlyBullets.Length; i++)
        {
            if (!friendlyBullets[i].activeInHierarchy)
            {
                return friendlyBullets[i];
            }
        }

        return null;
    }
    public GameObject GetEnemyBullet()
    {
        for (int i = 0; i < enemyBullets.Length; i++)
        {
            if (!enemyBullets[i].activeInHierarchy)
            {
                return enemyBullets[i];
            }
        }

        return null;
    }
    public GameObject GetEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }

        return null;
    }
    public GameObject GetMissel()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!misseis[i].activeInHierarchy)
            {
                return misseis[i];
            }
        }

        return null;
    }
    public GameObject GetPower()
    {
        for (int i = 0; i < powers.Length; i++)
        {
            if (!powers[i].activeInHierarchy)
            {
                return powers[i];
            }
        }

        return null;
    }
    public GameObject GetAsteroide()
    {
        for (int i = 0; i < asteroides.Length; i++)
        {
            if (!asteroides[i].activeInHierarchy)
            {
                return asteroides[i];
            }
        }

        return null;
    }
    public void SpawnarAmericanoAleatorio()
    {
        List<EnemySpawner> livres = new List<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (!spawner.Ocupado)
                livres.Add(spawner);
        }

        if (livres.Count == 0)
            return;

        EnemySpawner escolhido =
            livres[Random.Range(0, livres.Count)];

        GameObject inimigo = GetEnemy();

        if (inimigo != null)
        {
            escolhido.Spawnar(inimigo);

            Americanos script = inimigo.GetComponent<Americanos>();

            script.DefinirSpawner(escolhido);
        }
    }
    public void SpawnarMisselAleatorio()
    {
        List<EnemySpawner> livres = new List<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (!spawner.Ocupado)
                livres.Add(spawner);
        }

        if (livres.Count == 0)
            return;

        EnemySpawner escolhido =
            livres[Random.Range(0, livres.Count)];

        GameObject inimigo1 = GetMissel();

        if (inimigo1 != null)
        {
            escolhido.Spawnar(inimigo1);

            Missel script = inimigo1.GetComponent<Missel>();

            script.DefinirSpawner(escolhido);
        }
    }
    public void SpawnarPowerAleatorio()
    {
        List<EnemySpawner> livres = new List<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (!spawner.Ocupado)
                livres.Add(spawner);
        }

        if (livres.Count == 0)
            return;

        EnemySpawner escolhido =
            livres[Random.Range(0, livres.Count)];

        GameObject power = GetPower();

        if (power != null)
        {
            escolhido.Spawnar(power);

            Bola script = power.GetComponent<Bola>();

            script.DefinirSpawner(escolhido);
        }
    }
    private void SpawnPowerUp()
    {
        GameObject powerUp = GetPower();

        if (powerUp == null)
            return;

        powerUp.transform.position = powerUpPos;
        powerUp.SetActive(true);
    }
    public void SpawnarAsteroideAleatorio()
    {
        List<EnemySpawner> livres = new List<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (!spawner.Ocupado)
                livres.Add(spawner);
        }

        if (livres.Count == 0)
            return;

        EnemySpawner escolhido =
            livres[Random.Range(0, livres.Count)];

        GameObject inimigo = GetEnemy();

        if (inimigo != null)
        {
            escolhido.Spawnar(inimigo);

            Americanos script = inimigo.GetComponent<Americanos>();

            script.DefinirSpawner(escolhido);
        }
    }
    private void BossFight()
    {

    }
    private IEnumerator ControleDeFases()
    {
        yield return StartCoroutine(Fase1());
        yield return StartCoroutine(Fase2());
        yield return StartCoroutine(Fase3());

        BossFight();
    }
    private IEnumerator Fase1()
    {
        float tempo = 0f;

        while (tempo < fase1Duracao)
        {
            yield return new WaitForSeconds(5f);
            tempo += 5f;
            SpawnarAsteroideAleatorio();


            if (Random.value < 0.25f)
            {
                SpawnarAmericanoAleatorio();
            }
            if (Random.value < 0.5f)
            {
                SpawnarAsteroideAleatorio();
            }

        }
    }
    private IEnumerator Fase2()
    {
        SpawnPowerUp();

        float tempo = 0f;

        while (tempo < fase2Duracao)
        {
            yield return new WaitForSeconds(5f);
            tempo += 5f;
            SpawnarAsteroideAleatorio();
            SpawnarAmericanoAleatorio();

            if (Random.value < 0.25f)
                SpawnarAmericanoAleatorio();

            if (Random.value < 0.75f)
                SpawnarAsteroideAleatorio();

            if (Random.value < 0.25f)
                SpawnarMisselAleatorio();

            if (Random.value < 0.25f)
                SpawnPowerUp();

        }
    }
    private IEnumerator Fase3()
    {
        SpawnPowerUp();

        SpawnarMisselAleatorio();
        SpawnarMisselAleatorio();

        float tempo = 0f;

        while (tempo < fase3Duracao)
        {
            yield return new WaitForSeconds(4f);
            tempo += 4f;
            SpawnarAsteroideAleatorio();
            SpawnarAsteroideAleatorio();
            SpawnarAmericanoAleatorio();

            if (Random.value < 0.5f)
                SpawnarAmericanoAleatorio();

            if (Random.value < 0.5f)
                SpawnarMisselAleatorio();

            if (Random.value < 0.5f)
                SpawnPowerUp();

        }
    }
}
