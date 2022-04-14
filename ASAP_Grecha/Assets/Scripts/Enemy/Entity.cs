using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private CameraController _cameraController;
    public virtual void GetDamage()
    {

    }
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
