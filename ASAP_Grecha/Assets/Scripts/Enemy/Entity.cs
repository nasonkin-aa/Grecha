using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //private CameraController _cameraController;
    public virtual void GetDamage(float damage) {}
    public virtual void Die()
    {
        this.gameObject.SetActive(false);
    }
   // public virtual void SetDamage(float damage) {}
}
