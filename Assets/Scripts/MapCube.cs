using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    [HideInInspector]
    public bool isUpgraded = false;
    public GameObject buildEffect;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public  void BuildTurret(GameObject turretPrefeb)
    {
        isUpgraded = false;
        turretGo = GameObject.Instantiate(turretPrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

    private void OnMouseEnter()
    {
        if (turretGo == null && !EventSystem.current.IsPointerOverGameObject())
        {
            renderer.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
