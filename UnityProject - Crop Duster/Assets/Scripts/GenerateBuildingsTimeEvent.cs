using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuildingsTimeEvent : MonoBehaviour
{
    public GameObject BuildingPreFabs;
    public int xPOS;
    public int zPOS;
    public int PreFabCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropPrefabs());
    }

    private void Update()
    {
        
    }

    IEnumerator DropPrefabs()
    {
        while (PreFabCount < 5)// prefab count
        {
            // passing random range settings 
            xPOS = Random.Range(1, 20);
            zPOS = Random.Range(1, 20);
            Instantiate(BuildingPreFabs, new Vector3(xPOS, 0, zPOS), Quaternion.identity);
            yield return new WaitForSeconds(10f);
            PreFabCount += 1;
        }
    }
}
