using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//保存炮台的相关数据
[System.Serializable]
public class TurretData
{
    public GameObject turretPrefeb;
    public int cost;
    public GameObject turretUpgradedPrefeb;
    public int costUpgraded;
    public TurretType type;
}
public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandardTurret
}