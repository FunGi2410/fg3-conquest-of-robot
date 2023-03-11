using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    public float fireRate = 5;
    public float muzzleVelocity = 5;

    float nextFireTime;

    public void Shoot()
    {
        if(Time.time > this.nextFireTime)
        {
            this.nextFireTime = Time.time + 1 / this.fireRate;
            Projectile newProjectile = Instantiate(this.projectile, this.muzzle.position, this.muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(this.muzzleVelocity);
        }
    }
}
