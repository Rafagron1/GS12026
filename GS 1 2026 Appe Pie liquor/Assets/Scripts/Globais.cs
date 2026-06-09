using UnityEditor.EditorTools;
using UnityEngine;

public class Globais : MonoBehaviour
{
    [SerializeField] private GameObject friendlyBulletPrefab;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private GameObject enemyPrefab;
    private int poolShotSize = 50;
    private int enemyShotPool = 200;
    private int enemyPoolSize = 20;
    private GameObject[] friendlyBullets;
    private GameObject[] enemyBullets;
    private GameObject[] enemies;
    [SerializeField] private Transform jogador;
    [SerializeField] private Transform Spawner1;
    [SerializeField] private Transform Spawner2;
    [SerializeField] private Transform Spawner3;
    [SerializeField] private Transform Spawner4;
    [SerializeField] private Transform Spawner5;


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
            enemies[i].GetComponent<Americanos>().Initialize(jogador,this);
            enemies[i].SetActive(false);
        }
    }
    private void Start()
    {
        GameObject enemy = this.GetEnemy();

        if (enemy != null)
        {
            enemy.transform.position = Spawner3.position;
            enemy.SetActive(true);
        }
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
}
