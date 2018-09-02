using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Bezier 四次三阶 
 */
public class Curve : Shape {

    public void BezierToPoints(int nPoints)
    {
        int n = GetPathPoints().Count - 1;
        float t, delt;
        delt = 1 /(float) nPoints;
        t = 0.0f;
        List<PathPoint> results=new List<PathPoint>();
        for (int i = 0; i <= nPoints; i++)
        {
            PathPoint point = Decas(n, t);
            t += delt;
        }
    }

    private PathPoint Decas(int n, float t)
    {
        return  null;
    }

}
