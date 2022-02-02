using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimovement : MonoBehaviour
{
    public Transform[] waypoints; //waypoint variable
    public int speed; // speed settings

    private int waypointIndex; // keep track of which waypoint 
    private float dist; // keep track of distance between object

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        waypointIndex = 0; // starting point 
        transform.LookAt(waypoints[waypointIndex].position); // making sure the ai faces towards the waypoint
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            anim.SetInteger("AnimationPar", 1);
            increaseIndex();
        }
        else
        {
            anim.SetInteger("AnimationPar", 1);
        }
        patrol();
    }
    void patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // get axis of the ai
    }

    // incrementing our index
    void increaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            
            waypointIndex = 0;
        }
       
            transform.LookAt(waypoints[waypointIndex].position);
    }
}
