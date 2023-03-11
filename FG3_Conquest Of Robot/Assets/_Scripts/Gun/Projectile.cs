using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 10f;

    float timer = 0f;
    public float timeLife = 1f;
    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
    private void Update()
    {
        this.timer += Time.deltaTime;
        if(this.timer > this.timeLife)
        {
            Destroy(gameObject);
            this.timer = 0f;
        }
        transform.Translate(Vector2.right * Time.deltaTime * this.speed);
    }
}
