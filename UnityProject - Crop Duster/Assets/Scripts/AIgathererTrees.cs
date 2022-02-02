using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIgathererTrees : MonoBehaviour
{
    public float SightRange, GatherRange;
    public Transform Tree;
    NavMeshAgent Astronaut;
    public LayerMask AstronautMask;
    public LayerMask TileLayer;
    public LayerMask TreeMask;
    public float WalkRange = 100f;
    bool WalkRangeSet = false;
    Vector3 randomPOS;
    Animator anim;
    List<TreeScript> mineTrees;
    // Start is called before the first frame update
    private void Awake()
    {
        Astronaut = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool inSightRange = Physics.CheckSphere(transform.position, SightRange, TreeMask);
        if (inSightRange)
        {
            anim.SetInteger("AnimationPar", 1);// setting animation parameters
            TreeScript closestTree = FindTreesClosest();
            GatherTree(closestTree);
        }
        else
        {
            anim.SetInteger("AnimationPar", 1);// setting animation parameters
            Patrol();
        }

    }
    //find and return closest stones (change settings for other resources)
    TreeScript FindTreesClosest()
    {
        // creating new list
        mineTrees = new List<TreeScript>(FindObjectsOfType<TreeScript>());
        TreeScript closestTree = mineTrees[0];
        float closestDistance = 0f;

        foreach (TreeScript mineTree in mineTrees)
        {
            float newDistance = Vector3.Distance(transform.position, mineTree.transform.position);
            if (newDistance < closestDistance)
            {
                closestDistance = newDistance;
                closestTree = mineTree;
            }
        }
        mineTrees.Clear();
        return closestTree;
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
        if (DistancetoNewPoint.magnitude < 1f)
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
    void GatherTree(TreeScript closestTree)//set move to destination
    {

        Astronaut.SetDestination(closestTree.transform.position);
    }
    private void OnDrawGizmosSelected()//drawing gizmos
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, GatherRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }
    private void OnTriggerEnter(Collider other)//collision property
    {
        if (other.transform.gameObject.tag == "TreeTag")
        {
            Destroy(other.transform.gameObject);
        }
    }
}
