using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIgatherer : MonoBehaviour
{
    public float SightRange, GatherRange;
    public Transform Stone;
    NavMeshAgent Astronaut;
    public LayerMask AstronautMask;
    public LayerMask TileLayer;
    public LayerMask StoneMask;
    public float WalkRange = 100f;
    bool WalkRangeSet = false;
    Vector3 randomPOS;
    Animator anim;
    List<MineStoneScript> mineStones;
    // Start is called before the first frame update
    private void Awake()
    {
        Astronaut=GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool inSightRange = Physics.CheckSphere(transform.position, SightRange, StoneMask);
        if (inSightRange)
        {
            anim.SetInteger("AnimationPar", 1);// setting animation parameters
            MineStoneScript closestStone = FindStonesClosest();
            GatherStone(closestStone);
        }
        else
        {
            anim.SetInteger("AnimationPar", 1);// setting animation parameters
            Patrol();
        }
        
    }
    //find and return closest stones (change settings for other resources)
    MineStoneScript FindStonesClosest()
    {
        mineStones = new List<MineStoneScript>(FindObjectsOfType<MineStoneScript>());
        MineStoneScript closestStone = mineStones[0]; 
        float closestDistance = 0f;

        foreach(MineStoneScript mineStone in mineStones)
        {
            float newDistance = Vector3.Distance(transform.position, mineStone.transform.position);
            if (newDistance < closestDistance) 
            {
                closestDistance = newDistance;
                closestStone = mineStone;
            }
        }
        mineStones.Clear();
        return closestStone;
    }
    void Patrol()
    {
        // assigning new position
        if (!WalkRangeSet)
        {
            SearchNewPoints();
        }
        // move to new position
        if (WalkRangeSet)
        {
            Astronaut.SetDestination(randomPOS);
        }
        // checks if reached or not
        Vector3 DistancetoNewPoint = transform.position - randomPOS;
        if(DistancetoNewPoint.magnitude < 1f)
        {
            WalkRangeSet = false;
        }
    }
    //Searching new points to move
    void SearchNewPoints()
    {
        float randomX = Random.Range(-WalkRange, WalkRange);
        float randomZ = Random.Range(-WalkRange, WalkRange);

        randomPOS = new Vector3(randomX + transform.position.x, transform.position.y, randomZ + transform.position.z);

        if (Physics.Raycast(randomPOS, -transform.position, 5f, TileLayer))
        {
            WalkRangeSet = true;
        }
    }
    void GatherStone(MineStoneScript closestStone)
    {
      
        Astronaut.SetDestination(closestStone.transform.position);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, GatherRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag =="MineStoneTag")
        {
            Destroy(other.transform.gameObject);
        }
    }
}
