using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 10f;

    public LayerMask collisionMask;

    float timer = 0f;
    public float timeLife = 1f;
    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
    private void Update()
    {
        float moveDistance = this.speed * Time.deltaTime;
        this.CheckColission(moveDistance);
        this.timer += Time.deltaTime;
        if(this.timer > this.timeLife)
        {
            Destroy(gameObject);
            this.timer = 0f;
        }
        transform.Translate(Vector2.right * moveDistance);
    }

    void CheckColission(float moveDistance)
    {
        //Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, moveDistance, this.collisionMask);

        if(hit.collider != null)
        {
            this.OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit2D hit)
    {
        print(hit.collider.gameObject.name);
        Destroy(gameObject);
    }
}
