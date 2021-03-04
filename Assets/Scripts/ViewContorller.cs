using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewContorller : MonoBehaviour
{

    public float Speed = 15;
    public float MouseSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(new Vector3(h, -mouse * MouseSpeed, v) * Time.deltaTime * Speed,Space.World);


    }
}
