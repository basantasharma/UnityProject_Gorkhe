using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float damage = 10f;
    public float range = 5f;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

   void Shoot()
   {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }

   }
}
