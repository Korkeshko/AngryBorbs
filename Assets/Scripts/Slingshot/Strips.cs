using UnityEngine;

public class Strips : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LineRenderer backlineRenderer;
    [SerializeField] private LineRenderer frontlineRenderer;
    private int pointCount = 2;
    private int startPoint = 0;
    private int endPoint = 1;  

    private void Start() // Awaike() --
    {
        backlineRenderer.positionCount = pointCount;
        backlineRenderer.SetPosition(startPoint, backlineRenderer.transform.position);
  
        frontlineRenderer.positionCount = pointCount;
        frontlineRenderer.SetPosition(startPoint, frontlineRenderer.transform.position);
    }

    private void Update()
    {
        backlineRenderer.SetPosition(endPoint, target.position);
        frontlineRenderer.SetPosition(endPoint, target.position);
    }
}