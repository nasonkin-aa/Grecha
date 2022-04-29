using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Barista : MonoBehaviour
{
    public float Range;
    
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;
    public int ZonePlays;
    public List<Transform> listHits;
    Collider2D[] colliderZone;
    bool Check;
    void Update()
    {
            Vector2 targetPos ;
        ////RaycastHit2D rayInfo = Physics2D.Raycast(new Vector3(transform.position.x + ZonePlays, transform.position.y,transform.position.z), Direction, Range);
        /*RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll(new Vector3(transform.position.x + ZonePlays, transform.position.y, transform.position.z), Direction, Range);
        listHits = raycastHit2D.ToList().ConvertAll(b => b.collider.gameObject);*/
        colliderZone = Physics2D.OverlapCircleAll(new Vector3(transform.position.x + ZonePlays, transform.position.y, transform.position.z), ZonePlays);

        Detected = false;
        //for (int i = 0; i < colliderZone.Length; i++)
        //{
        //    if (colliderZone[i].transform.GetComponent<Hero>() == transform.GetComponent<Hero>() )
        //    {
        //        Transform Target ;
        //        Check = false;
        //        Target = colliderZone[0].transform;
        //        targetPos = Target.position;
        //        Direction = targetPos - (Vector2)transform.position;
        //        Debug.Log(transform.GetComponent<Hero>());
        //        Detected = true;
        //        break;
        //    }

        //}
        foreach (Collider2D a in colliderZone)
        {
            if (a.transform.GetComponent<Hero>())
            {
                Transform Target;
                Check = false;
                Target = a.transform;
                targetPos = Target.position;
                Direction = targetPos - (Vector2)transform.position;
                Debug.Log(transform.GetComponent<Hero>());
                Detected = true;
                break;
            }
            else
            {
                Detected = false;
                break;
            }
        }
        

        if (Detected)
        {
            Gun.transform.right = -Direction.normalized;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, quaternion);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * Force  );
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x + ZonePlays, transform.position.y, transform.position.z), Range);
    }
}