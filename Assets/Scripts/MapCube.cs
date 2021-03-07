using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    public GameObject buildEffect;


    public  void BuildTurret(GameObject turretPrefeb)
    {
        turretGo = GameObject.Instantiate(turretPrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }
}
