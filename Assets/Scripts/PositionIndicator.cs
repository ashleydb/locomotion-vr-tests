using UnityEngine;
using System.Collections;
using System;

public class PositionIndicator : MonoBehaviour
{
    // For LineRenderer
    public Color lineColor = Color.yellow;
    public Vector3 lineStartPos;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.SetColors(lineColor, lineColor); // TODO: Change colors depending on PlayerController.moveState
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(2);
    }

    void Update()
    {
        // Draw a short line, straight up
        Vector3[] points = new Vector3[2];
        points[0] = lineStartPos;
        points[1] = lineStartPos;
        points[1].y += 1.0f;
        lineRenderer.SetPositions(points);
    }

    public void PrintDebugMessage()
    {
        Debug.Log("You called PositionIndicator::PrintDebugMessage().");
    }
}
