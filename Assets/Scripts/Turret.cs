using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    public float attackRate = 0.5f; //多少秒攻击一次
    private float timer = 0;

    public GameObject bulletPrefeb;
    public Transform firePosition;

    private void Start()
    {
        timer = attackRate;
    }

    private void Update()
    {
        if (enemys.Count > 0 && timer >= attackRate)
        {
            Attack();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void Attack()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefeb,firePosition.position,firePosition.rotation);
        bullet.GetComponent<Bullet>().Target = enemys[0].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }
}
