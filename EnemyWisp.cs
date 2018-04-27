using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyWisp : Enemy
{

    public Transform pos1; //Left most position of wisp path
    public Transform pos2; //Right most position of wisp path

    public NavMeshAgent nav;
    public Transform player;
    GameObject wispvisionlight;

    float StartTime;
    float DistanceToDestination;
    float SpeedFactor;
    bool directionswitch;
    bool idle;
    bool returning;
    void Start()
    {

        StartTime = Time.time; //time at beginning of scene
        DistanceToDestination = Vector3.Distance(pos1.position, pos2.position); //total distance between two lerp points
        SpeedFactor = 1.0f;
        directionswitch = false; //true = pos1 to pos2 -> , false pos2 to pos1 <-
        transform.Rotate(0, 90, 0, Space.Self); //rotates the mesh to begin with

        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        idle = true;

        var distancebetweenpos = Vector3.Distance(pos1.transform.position, transform.position);

        transform.position = pos1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(returning && Vector3.Distance(pos1.transform.position, transform.position) < 1)
        {
            returning = false;
            idle = true;
            nav.SetDestination(pos2.transform.position);
        }
       
        if(idle)
        {
            Lerp2();
        }






    }

    void Lerp()
    {
        float currentDuration = (Time.time - StartTime) * SpeedFactor; //calculates the current time compared to to start time to get duration
        float journeyFraction = currentDuration / DistanceToDestination; //calculating distance travelled per second


        if (directionswitch == true) //if ->, lerp between pos1 and pos2
        {
            transform.position = Vector3.Lerp(pos1.position, pos2.position, journeyFraction);
        }
        if (directionswitch == false) //if <- lerp between pos2 and pos2
        {
            transform.position = Vector3.Lerp(pos2.position, pos1.position, journeyFraction);
        }



        if ((transform.position.x == pos2.position.x) || (transform.position.x == pos1.position.x)) //handles changing the direction of the wisp
        {
            StartTime = Time.time; //reset time
            currentDuration = 0.0f; //reset duraction
            directionswitch = !directionswitch; //switch directionbool

            transform.Rotate(0, 180, 0, Space.Self); //rotate sprite 180 degrees in the y axis (to have spotlight pointing the right way)
        }




    }

    void Lerp2()
    {

        if(Vector3.Distance(pos1.transform.position, transform.position)<1)
        {
            nav.SetDestination(pos2.transform.position);
        }
        if (Vector3.Distance(pos2.transform.position, transform.position) < 1)
        {
            nav.SetDestination(pos1.transform.position);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        idle = false;
        nav.enabled = true;
        nav.speed = 5f;
        nav.SetDestination(player.position);
        Debug.Log("trigger entered");
       
    }
    void OnTriggerExit(Collider col)
    {
        returning = true;
        nav.speed = 1;
        Vector3 navvec = pos1.position;
        nav.SetDestination(navvec);
        Debug.Log("trigger exited");
    }
}