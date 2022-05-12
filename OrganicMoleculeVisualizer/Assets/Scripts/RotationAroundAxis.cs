using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundAxis : Object 
{
    public Vector3 Point;
    public float Angle;
    public Vector3 Axis;

    public RotationAroundAxis(Vector3 point, float angle, Vector3 axis)
    {
        Point = point;
        Angle = angle;
        Axis = axis;
    }
    public void RotateTransform(Transform transform)
    {
        transform.RotateAround(Point, Axis, Angle);
    }
    public override string ToString()
    {
        return System.String.Format("({0}, {1}, {2})", Point, Angle, Axis.ToString());
    }
}
