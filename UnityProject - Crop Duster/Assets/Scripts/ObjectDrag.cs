using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] int gridSnapSize = 5;
    [SerializeField] GameObject WorldResourceTile;

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean m_ClickAction;

    public SteamVR_Input_Sources m_CancelTargetSource;
    public SteamVR_Action_Boolean m_CancelClickAction;

    public bool isVR = true;

    Pointer pointer;


    bool triggered = false;

    private GameObject _drag;
    private Vector3 screenPosition;
    private Vector3 offset;


    private void Awake()
    {
        pointer = GameObject.Find("PR_Pointer").GetComponent<Pointer>();

    }

    void Update()
    {

        if (isVR)
        {
            if (_drag == null)
            {
                Transform draggingObject = transform;

                Vector3 rayPoint = pointer.m_Dot.transform.position;
                Vector3 snappedRayPoint = rayPoint;
                snappedRayPoint.x = (Mathf.RoundToInt(rayPoint.x / gridSnapSize) * gridSnapSize);
                snappedRayPoint.z = (Mathf.RoundToInt(rayPoint.z / gridSnapSize) * gridSnapSize);
                draggingObject.position = snappedRayPoint;

            }

            if (m_ClickAction.GetStateDown(m_TargetSource))
            {
                if (!triggered)
                {
                    _drag = null;
                    Instantiate(WorldResourceTile, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }


            }

            if (m_CancelClickAction.GetStateDown(m_CancelTargetSource))
            {
                Destroy(gameObject);
            }

        }
        else
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
