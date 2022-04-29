using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Barista : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

 
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, new Vector2(15,0), Range);
        Debug.DrawRay(transform.position, new Vector2(15, 0));
       
            if (rayInfo.collider.gameObject.tag == "Enemy")
            {
                if (Detected == false)
                {
                    if (Time.time > nextTimeToFire)
                    {
                        nextTimeToFire = Time.time + 1 / FireRate;
                        shoot();
                    }
                Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        
        if (Detected)
        {
            Gun.transform.right = -Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        Quaternion quaternion = Quaternion.Euler(0,0,Mathf.Atan2(Direction.y,Direction.x)* Mathf.Rad2Deg);
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, quaternion);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(15,0).normalized * Force);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}