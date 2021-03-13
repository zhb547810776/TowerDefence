using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;

    public float bulletSpeed = 40;
    private Transform target;
    public GameObject explosionEffectPrefeb;

    public Transform Target {set => target = value; }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().GetDamage(damage);
            GameObject effect = GameObject.Instantiate(explosionEffectPrefeb, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(gameObject);
        }
    }
}
