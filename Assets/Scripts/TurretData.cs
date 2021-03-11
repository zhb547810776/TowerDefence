using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//保存炮台的相关数据
[System.Serializable]
public class TurretData
{
    public GameObject turretPrefeb;
    public int cost;
    public int sale;
    public GameObject turretUpgradedPrefeb;
    public int costUpgraded;
    public int saleUpgraded;
    public TurretType type;
}
public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandardTurret
}