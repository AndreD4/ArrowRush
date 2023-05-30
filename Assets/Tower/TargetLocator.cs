using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    

    
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
        weapon.LookAt(target);
    }
}
