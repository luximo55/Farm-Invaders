using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float Speed = 50;
    public float TopBound = 30;
    
    void Start()
    {
        
    }

    void Update()
    {
        Move();

        if (transform.position.z > TopBound)
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
