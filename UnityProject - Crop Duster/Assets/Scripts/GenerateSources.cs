using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSources : MonoBehaviour
{
    public GameObject PreFabs;
    public int xPOS;
    public int zPOS;
    public int PreFabCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) StartCoroutine(DropPrefabs());
    }

    IEnumerator DropPrefabs()
    {
        while(PreFabCount < 5)
        {
            xPOS = Random.Range(1, 20);
            zPOS = Random.Range(1, 20);
            Instantiate(PreFabs, new Vector3(xPOS, 0, zPOS), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            PreFabCount += 1;
        }
    }
}
