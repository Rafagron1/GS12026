using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Globais : MonoBehaviour
{
    [SerializeField] private GameObject friendlyBulletPrefab;
    [SerializeField] private GameObject enemyBulletPrefab;
    private int poolShotSize = 50;
    private int enemyShotPool = 200;
    private GameObject[] friendlyBullets;
    private GameObject[] enemyBullets;
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
    }
    private void Start()
    {

    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Menu");
        }
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
}
