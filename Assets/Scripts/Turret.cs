using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<GameObject> enemys = new List<GameObject>();
    public float attackRate = 0.5f; //多少秒攻击一次
    private float timer = 0;

    public GameObject bulletPrefeb;
    public Transform firePosition;
    public Transform head;

    private void Start()
    {
        timer = attackRate;
    }

    private void Update()
    {
        Attack();           
    }

    void Attack()
    {
        timer += Time.deltaTime;

        while (enemys.Count > 0)
        {
            if (enemys[0] == null)
            {
                enemys.RemoveAt(0);
            }
            else
            {
                break;
            }
        }

        if (enemys.Count == 0)
        {
            return;
        }

        if (timer > attackRate)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);

            GameObject bullet = GameObject.Instantiate(bulletPrefeb, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().Target = enemys[0].transform;
            timer = 0;
        }

        
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
