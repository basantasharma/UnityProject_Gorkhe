using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class BulletFire : MonoBehaviour
{
    public ParticleSystem MuzzleFlash;

    //public float BulletFired = 0f;
    public float damage = 10f;
    public float range = 5f;

    public float FireRate = 100f;
    public float NextTimeToFire = 0f;
    

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= NextTimeToFire && Cursor.lockState != CursorLockMode.None)
        {
            NextTimeToFire = Time.time + (1f / FireRate) ;
            Shoot();
            this.GetComponent<AudioSource>().Play();
            //BulletFired += 1f;
            //Debug.Log(BulletFired);
        }
        
    }

   void Shoot()
   {
        MuzzleFlash.Play();
       
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
       
       
   }
}
