using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private CameraController _cameraController;
    public virtual void GetDamage(float damage) {}
    public virtual void Die( float lives)
    {
        Destroy(this.gameObject);
    }
}
