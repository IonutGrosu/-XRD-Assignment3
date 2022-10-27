using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    public void InstantiateCaller(GameObject prefab)
         {
             Instantiate(prefab, SpawnPoint.position, Quaternion.identity);
         }
}
