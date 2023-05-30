using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour

{
  [SerializeField] List<WayPoint> path = new List<WayPoint>();
  [SerializeField] [Range(0f,5f)] float Speed = 1f;

    void Start() 
    {
      StartCoroutine(FollowPath());
    }

    void FindPath()
    {
      path.Clear();

      GameObject parent = GameObject.FindGameObjectWithTag("Path");

      foreach(Transform child in parent.transform)
      {
         path.Add(child.GetComponent<WayPoint>());
      }
    }


    IEnumerator FollowPath() 
    {
      foreach(WayPoint wayPoint in path)
      {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = wayPoint.transform.position;
        float travelPercent = 0f;

        transform.LookAt(endPosition);

        while(travelPercent <1f)
        {
          travelPercent +=Time.deltaTime * Speed;
          transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
          yield return new WaitForEndOfFrame();
        }
      }
    }
   
}
