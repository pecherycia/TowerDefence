using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;


    [SerializeField] bool isPlaceble = false;
    public bool IsPlacable { get { return isPlaceble; } }




    void OnMouseDown()
    {
        if (isPlaceble)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab,transform.position);
          
            isPlaceble = !isPlaced;

        }
    }
}
