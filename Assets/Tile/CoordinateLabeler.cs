﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;
    

    void Awake() 
    {
      label = GetComponent<TextMeshPro>();
      wayPoint = GetComponentInParent<WayPoint>();
      DisplayCoordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
          DisplayCoordinates();
          UpdateObjectName();
        }

        ColorCoordinates();
    }

    void ColorCoordinates()
    {
      
    }

    void DisplayCoordinates()
    {
      coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
      coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

      label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
      transform.parent.name = coordinates.ToString();
    }
}
