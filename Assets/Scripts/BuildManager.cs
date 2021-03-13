using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    private bool selectLaserTurret;
    private bool selectMissileTurret;
    private bool selectStandardTurret;

    private TurretData selectedTurretData;
    private MapCube selectedMapCube;
    private int money = 800;

    public GameObject upgradeCanvas;
    public Button buttonUpgrade;

    public Animator moneyAnimator;
    Animator upgradeCanvasAnimator;
    public Text moneyText;

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "￥" + money;
    }

    void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!selectLaserTurret && !selectMissileTurret && !selectStandardTurret)
        {
            selectedTurretData = null;
        }

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
                    if (mapCube.turretGo == null)
                    {

                        if (selectedTurretData != null && money < selectedTurretData.cost)
                        {
                            moneyAnimator.SetTrigger("Flicker");
                        }

                        //可以创建炮台
                        if (selectedTurretData != null && money >= selectedTurretData.cost)
                        {
                            StartCoroutine("HideUpgradeUI");
                            ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData);
                            //selectedTurretData = null;
                        }


                    }
                    else
                    {
                        //升级炮台
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine("HideUpgradeUI");
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube = mapCube;

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
        selectLaserTurret = isOn;
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
        selectMissileTurret = isOn;
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
        selectStandardTurret = isOn;
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.transform.position = pos + new Vector3(-0.48f,4.6f,4.2f);
        upgradeCanvas.SetActive(true);
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(0.5f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        if (money >= selectedMapCube.TurretData.costUpgraded)
        {
            selectedMapCube.UpgrateTurret();
            ChangeMoney(-selectedMapCube.TurretData.costUpgraded);
            StartCoroutine("HideUpgradeUI");
        }
        else
        {
            moneyAnimator.SetTrigger("Flicker");
        }

    }
    public void OnSaleButtonDowm()
    {
        bool isUpgrade = selectedMapCube.SaleTurret();
        if (isUpgrade)
        {
            ChangeMoney(selectedMapCube.TurretData.saleUpgraded);
        }
        else
        {
            ChangeMoney(selectedMapCube.TurretData.sale);
        }
        StartCoroutine("HideUpgradeUI");
    }
}
