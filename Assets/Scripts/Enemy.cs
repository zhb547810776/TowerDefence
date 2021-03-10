using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform[] positions;
    private int index = 0;
    public float enemySpeed = 20;
    public int hp = 300;
    public int totalHp;
    public Slider hpSlider;
    public GameObject explositonEffect;
    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoints.positions;
        totalHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //if (index > positions.Length-1)
        //{
        //    Debug.Log("到达终点");
        //    return;
        //}
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * enemySpeed);

        if(Vector3.Distance(positions[index].position , transform.position) < 0.2f)
        {
            index++;
        }

        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }

    void ReachDestination()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EnemySpawner.EnemyAliveCount--;
    }

    public void GetDaname(int damage)
    {
        if (hp<0)
        {
            return;
        }
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;

        if (hp<=0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explositonEffect, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(gameObject);
    }
}
