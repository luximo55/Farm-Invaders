using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 5;
    public float RangeX;

    public GameObject ProjectilePrefab;

    [SerializeField] //atribut za prikazivanje privatne varijable u inspectoru
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //provjera jesmo li unutar granica
        if (transform.position.x < -RangeX)
		{
            transform.position = new Vector3(RangeX, transform.position.y, transform.position.z);
		}

        if (transform.position.x > RangeX)
		{
            transform.position = new Vector3(-RangeX, transform.position.y, transform.position.z);
		}


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * Speed);

        //provjera Fire tipke
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Instantiate(ProjectilePrefab, transform.position, ProjectilePrefab.transform.rotation);
    }
}
