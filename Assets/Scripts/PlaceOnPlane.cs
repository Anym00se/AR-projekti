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


    void Awake()
    {
        planeManager = gameObject.GetComponent<ARPlaneManager>();

        planeManager.planePrefab = arenaPlanePrefab;
    }
}
