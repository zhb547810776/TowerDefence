using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    private TurretData selectedTurretData;

    public int money = 1000;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                //点击左键  并且没有点击UI
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit ;
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (mapCube.TurretGo == null)
                    {
                        //可以创建炮台
                        if (money > selectedTurretData.cost)
                        {
                            money -= selectedTurretData.cost;
                            mapCube.BuildTurret(selectedTurretData.turretPrefeb);
                            //selectedTurretData = null;
                        }
                        else
                        {
                            //提示钱不够了
                        }
                    }
                    else
                    {
                        //升级炮台
                    }
                }
            }
        }
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }
}
