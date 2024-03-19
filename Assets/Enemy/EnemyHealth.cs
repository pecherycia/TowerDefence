using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amunt hit points when enemies die")]
    [SerializeField] int difficultyRump = 1;

    int currentHitPoints = 0;

    Enemy enemy;
    void OnEnable()
    {

        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        ProccesHit();
    }

    private void ProccesHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints+=difficultyRump;
            enemy.RewardGold();
        }
    }
}
