using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;
    

    
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
      Enemy[] enemies = FindObjectsOfType<Enemy>();
      Transform closestTraget = null;
      float maxDistance = Mathf.Infinity;

      foreach(Enemy enemy in enemies)
      {
        float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

        if(targetDistance < maxDistance)
        {
          closestTraget = enemy.transform;
          maxDistance = targetDistance;

        }
      }

      target = closestTraget;

    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if(targetDistance < range)
        {
          Attack(true);
        }
        else
        {
          Attack(false);
        }
    }

    void Attack(bool isActive)
    {
      var emissionModule = projectileParticles.emission;
      emissionModule.enabled = isActive;
    }
}
