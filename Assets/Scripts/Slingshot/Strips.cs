using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strips : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private LineRenderer lineRenderer;
    private int pointCount = 2;
    private int startPoint = 0;
    private int endPoint = 1;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointCount;
        lineRenderer.SetPosition(startPoint, transform.position);
    }

    private void Update()
    {
        lineRenderer.SetPosition(endPoint, target.position);
    }
}
