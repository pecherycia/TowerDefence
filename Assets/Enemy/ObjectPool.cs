using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField][Range(0f, 50f)] int poolSize = 5;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField][Range(0.1f,30f)] float timeToSpawn = 2f;

    GameObject[] pool;
    private void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    void EnabledObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            EnabledObjectInPool();
            yield return new WaitForSeconds(timeToSpawn);

        }
    }
}


