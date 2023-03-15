using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARPlaneManager))]
public class PlaceOnPlane : MonoBehaviour
{
    private List<ARPlane> arPlanes = new List<ARPlane>();
    private ARPlaneManager planeManager;
    public GameObject arenaPlanePrefab;
    public GameObject topPrefab;

    private GameObject arena;


    void Awake()
    {
        planeManager = gameObject.GetComponent<ARPlaneManager>();

        planeManager.planePrefab = arenaPlanePrefab;
    }

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void Update()
    {
        return;
        // Destroy additional planes over a few frames
        if (arPlanes.Count > 1)
        {
            Destroy(arPlanes[arPlanes.Count - 1]);
        }
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        return;
        foreach(var trackedPlane in eventArgs.added)
        {
            arPlanes.Add(trackedPlane);
        }

        foreach(var trackedPlane in eventArgs.removed)
        {
            arPlanes.Remove(trackedPlane);
        }
    }
}
