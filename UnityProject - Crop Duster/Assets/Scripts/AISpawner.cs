using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField] GameObject AIWood;
    [SerializeField] GameObject AIStone;

    private int spawnTotal;

    float xPOS;
    float zPOS;

    private void Start()
    {
        xPOS = transform.position.x;
        zPOS = transform.position.z;

        StartCoroutine(DropPrefabs());
    }
    // Update is called once per frame
    void Update()
    {
        //Instantiate(AIWood, transform.position, Quaternion.identity);
        //Instantiate(AIStone, transform.position, Quaternion.identity);
    }

    IEnumerator DropPrefabs()
    {
        while (spawnTotal < 1)
        {
            Debug.Log("Spawn");

            xPOS = Random.Range(1, 20);
            zPOS = Random.Range(1, 20);
            //Instantiate(AIWood, new Vector3(xPOS, 100, zPOS+45), Quaternion.identity);
            //Instantiate(AIStone, new Vector3(xPOS, 100, zPOS-45), Quaternion.identity);

            Instantiate(AIWood, transform.position, Quaternion.identity);
            Instantiate(AIStone, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(2.0f);
            spawnTotal += 1;
        }
    }
}
