using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARPlaneManager))]
public class PlaceOnPlane : MonoBehaviour
{
    private ARPlaneManager planeManager;
    public GameObject arenaPlanePrefab;
    public GameObject topPrefab;
    private GameObject arena;  // The actual game arena -> spawned when a plane detected


    void Awake()
    {
        planeManager = gameObject.GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach(var trackedPlane in eventArgs.added)
        {
            if (!arena)
            {
                arena = Instantiate(arenaPlanePrefab, trackedPlane.transform);
            }
        }
    }
}
