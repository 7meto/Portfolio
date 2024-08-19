using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bullettransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    
    void Start()
    {
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>(); 
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));

        Vector3 direction = mousePos - transform.position;
        direction.z = 0; 

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0; 
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        { 
            canFire = false;
            Instantiate(bullet, bullettransform.position, Quaternion.identity);
     
        }

    }


}
