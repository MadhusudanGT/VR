using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlacementManager : MonoBehaviour
{
    public GameObject[] flowers;
    public XROrigin origin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    public List<ARRaycastHit> rayCastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //shoot RayCast
            //plane the object randomly
            //disable the plane and plane manager

            bool collision = raycastManager.Raycast(Input.mousePosition, rayCastHits, TrackableType.PlaneWithinPolygon);
            if (collision)
            {
                GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                _object.transform.position = rayCastHits[0].pose.position;
            }

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled = false;
        }
    }
}
