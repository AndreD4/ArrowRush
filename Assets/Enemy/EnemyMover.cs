﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour

{
  [SerializeField] List<WayPoint> path = new List<WayPoint>();
  [SerializeField] float waitTime = 1f;

    void Start() 
    {
      StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath() 
    {
      foreach(WayPoint wayPoint in path)
      {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = wayPoint.transform.position;

        transform.position = wayPoint.transform.position;
        yield return new WaitForSeconds(waitTime);
      }
    }
   
}
