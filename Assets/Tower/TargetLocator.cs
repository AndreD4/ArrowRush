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
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
