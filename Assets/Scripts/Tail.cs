using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    private float pointSpacing = .1f;
    public Transform Snake;

    private LineRenderer _lr;
    private EdgeCollider2D _edgeCollider;

    private List<Vector2> points;

    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        if (_lr == null)
        {
            Debug.LogError("Line Renderer is null.");
        }

        _edgeCollider = GetComponent<EdgeCollider2D>();
        if (_edgeCollider == null)
        {
            Debug.LogError("Edge Collider is null.");
        }

        points = new List<Vector2>();

        SetPoint();
    }


    void Update()
    {
        if (Vector3.Distance(points.Last(),Snake.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    void SetPoint()
    {
        if (points.Count > 1)
        {
            _edgeCollider.points = points.ToArray<Vector2>();
        }
        points.Add(Snake.position);
        _lr.positionCount = points.Count;
        _lr.SetPosition(points.Count - 1, Snake.position);
    }
}
