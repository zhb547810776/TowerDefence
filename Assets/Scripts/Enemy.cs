using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] positions;
    private int index = 0;
    public float EnemySpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoints.positions;
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
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * EnemySpeed);

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
        //受伤
    }
}
