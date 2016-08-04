using UnityEngine;
using System.Collections;
using System;

public class Testbed : MonoBehaviour
{
    //public Camera camera;

    //private Vector3 midScreenPoint;
    //private GvrReticle gvrReticule;

    // For LineRenderer
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 2;
    public Vector3 lineStartPos;

    void Start()
    {
        //camera = GetComponent<Camera>();
        //gvrReticule = camera.GetComponent<GvrReticle>();
        //midScreenPoint = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        //lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
    }

    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[lengthOfLineRenderer];
        /*float t = Time.time;
        int i = 0;
        while (i < lengthOfLineRenderer)
        {
            points[i] = new Vector3(i * 0.5F, Mathf.Sin(i + t), 0);
            i++;
        }*/

        points[0] = lineStartPos;
        points[1] = lineStartPos;
        points[1].y += 1.0f;

        lineRenderer.SetPositions(points);

        //Ray ray = camera.ScreenPointToRay(midScreenPoint);
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }

    public void PrintDebugMessage()
    {
        Debug.Log("You called Testbed::PrintDebugMessage().");
    }
}
