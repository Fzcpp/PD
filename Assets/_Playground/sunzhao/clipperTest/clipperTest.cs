using System;
using System.Collections;
using System.Collections.Generic;
using ClipperLib;
using UnityEngine;
 

public class clipperTest : MonoBehaviour {
static List<IntPoint> GetEllipsePoints(IntRect bounds)
{
    List < IntPoint > points=new List<IntPoint>();
    points.Add(new IntPoint(bounds.left, bounds.bottom));

        points.Add(new IntPoint(bounds.left,bounds.top));
    points.Add(new IntPoint(bounds.right, bounds.top));
    points.Add(new IntPoint(bounds.right,bounds.bottom));
    
    return points;
}

    public   Material material;
    
    void DrawPolygons(List<List<IntPoint>> p, Color color )
 {
      GL.PushMatrix();
      material.SetPass(0);
      GL.LoadOrtho();  
      foreach (var points in p)
        {  
            GL.Begin(GL.QUADS);//绘制类型为四边形
           //GL.Begin(GL.TRIANGLE_STRIP);
            GL.Color(color);
            Debug.Log(points[0].X+","+points[0].Y+";"+points[2].X+","+points[2].Y);
          //  GL.Vertex3(x / Screen.width, y / Screen.height, 0);//['vɜ:teks] n. 最高点；顶点
          //  GL.Vertex3(x / Screen.width, y2 / Screen.height, 0);
           // GL.Vertex3( x2 / Screen.width,  y2/ Screen.height, 0);
           // GL.Vertex3( x2 / Screen.width, y / Screen.height, 0);
            for(int i=0;i<points.Count;i++)
                GL.Vertex3(points[i].X / Screen.width, points[i].Y / Screen.height, 0);//['vɜ:teks] n. 最高点；顶点

            GL.End();
        }   
      GL.PopMatrix();
 }

    private List<List<IntPoint>> subjs;
    private List<List<IntPoint>> clips;
    private List<List<IntPoint>> solution;
    // Use this for initialization
    private IntPoint GenerateRandomPoint(int l, int t, int r, int b, System.Random rand)
    {
        int Q = 10;
        return new IntPoint(
            Convert.ToInt64(  rand.Next(r / Q) * Q + l + 10     ),
            Convert.ToInt64( rand.Next(b / Q) * Q + t + 10)   );
    }
    void Start ()
    {
        
        subjs = new List<List<IntPoint>>(3);
	    subjs.Add(GetEllipsePoints(new IntRect(100, 250, 300, 50)));
	    subjs.Add(GetEllipsePoints(new IntRect(125, 130, 275, 80)));
	    subjs.Add(GetEllipsePoints(new IntRect(125, 220, 275, 170)));

        clips = new List<List<IntPoint>>(1);
        clips.Add(GetEllipsePoints(new IntRect(140, 270, 220, 20)));

        solution = new List<List<IntPoint>>();
	    Clipper c = new Clipper();
        c.AddPaths(subjs, PolyType.ptSubject, true);
	    c.AddPaths(clips, PolyType.ptClip, true);
        c.Execute(ClipType.ctIntersection, solution);
        Debug.Log("Solution:");
        foreach (var s in solution)
        {
            string info="";
            for(int i=0;i<s.Count;i++)
                info=info+s[i].X+","+s[i].Y+"  "  ;
            Debug.Log(info);
        }
        Debug.Log("end"); 
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnRenderObject()
    {
        DrawPolygons(subjs, new Color(0x80, 0x33, 0xFF,0xFF));//0x8033FFFF));
         DrawPolygons(clips, new Color(0x80,0xFF,0xFF,0x33));//0x80FFFF33
        DrawPolygons(solution, new Color(0x40,0x80,0x80,0x80));//0x40808080
    }
}
