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

    private TurretData turretData;
    public GameObject buildEffect;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public  void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        isUpgraded = false;
        turretGo = GameObject.Instantiate(turretData.turretPrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

    public void UpgrateTurret(out TurretData turretData)
    {
        turretData = this.turretData;
        if (isUpgraded)
        {
            return;
        }
        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefeb, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

    public bool SaleTurret(out TurretData turretDataBeforeSale)
    {
        turretDataBeforeSale = turretData;
        bool isUpgradedBeforeSale = isUpgraded;
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData = null;

        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);

        return isUpgradedBeforeSale;
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
