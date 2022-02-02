using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] int gridSnapSize = 5;
    [SerializeField] GameObject WorldResourceTile;




    bool triggered = false;

    private GameObject _drag;
    private Vector3 screenPosition;
    private Vector3 offset;


    void Update()
    {
        if (_drag == null)
        {
            Transform draggingObject = transform;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float planeY = 0;
            float distance;

            Plane plane = new Plane(Vector3.up, Vector3.up * planeY);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 rayPoint = ray.GetPoint(distance);
                Vector3 snappedRayPoint = rayPoint;
                snappedRayPoint.x = (Mathf.RoundToInt(rayPoint.x / gridSnapSize) * gridSnapSize);
                snappedRayPoint.z = (Mathf.RoundToInt(rayPoint.z / gridSnapSize) * gridSnapSize);
                draggingObject.position = snappedRayPoint;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!triggered)
            {
                _drag = null;
                Instantiate(WorldResourceTile, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }


        }

        if (_drag != null)
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            _drag.transform.position = new Vector3(currentPosition.x, _drag.transform.position.y, currentPosition.z);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "Building")
        {
            triggered = true;
            Debug.Log(triggered);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "Building")
        {
            triggered = false;
            Debug.Log(triggered);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tile"  || other.gameObject.tag == "Building")
        {
            triggered = true;
            Debug.Log(triggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tile" || other.gameObject.tag == "Building")
        {
            triggered = false;
            Debug.Log(triggered);
        }
    }
}
