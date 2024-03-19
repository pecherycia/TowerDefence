using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;




    public bool CreateTower(Tower tower, Vector3 prefabTransform)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false; }


        if (bank.CurrentBalance >= cost)
        {
            bank.WithDraw(cost);
            Instantiate(tower.gameObject, prefabTransform, Quaternion.identity);
            return true;
        }


        return false;
    }
}
