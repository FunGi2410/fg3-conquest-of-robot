using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent pathFinder;
    Transform target;

    private void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        this.pathFinder = GetComponent<NavMeshAgent>();
        this.pathFinder.updateRotation = false;
        this.pathFinder.updateUpAxis = false;
        
        StartCoroutine(this.UpdatePath());
    }

    private void Update()
    {
        //this.pathFinder.SetDestination(this.target.position);
    }


    IEnumerator UpdatePath()
    {
        float refresRate = 0.3f;

        while (this.target != null)
        {
            Vector3 targetPos = new Vector3(this.target.position.x, 0f, this.target.position.y);
            this.pathFinder.SetDestination(targetPos);
            yield return new WaitForSeconds(refresRate);
        }
    }
}
