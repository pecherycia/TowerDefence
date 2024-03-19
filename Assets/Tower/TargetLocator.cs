using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float TowerRange = 15;
    [SerializeField] ParticleSystem progectTileParticles;
    [SerializeField] Transform weapon;

    Transform target;
   


    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
        
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;


        foreach (Enemy enemy in enemies)
        {
            float targeDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targeDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targeDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < TowerRange)
        {
            weapon.LookAt(target);
            Attack(true);

        }
        else
        {
            Attack(false);
        }
        
    }

    void Attack(bool isActive)
    {
        var emmisionModule = progectTileParticles.emission;
        emmisionModule.enabled = isActive;
    }
}
