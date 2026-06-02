using UnityEngine;

public class Globais : MonoBehaviour
{
    public GameObject friendlyBulletPrefab;
    private int poolSize = 50;
    private GameObject[] friendlyBullets;

    private void Awake()
    {
        friendlyBullets = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            friendlyBullets[i] = Instantiate(friendlyBulletPrefab);
            friendlyBullets[i].SetActive(false);
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
}
