using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
/*
 * sunzhao:2018-7-12
 * 绘制图形，提供、维护 points，points可以转换成 Shape 类型
 * 
 */
public class DrawShape : MonoBehaviour {

    public enum ShapeType
    {
        Point,   // 点
        Segment, // 线段
        Polyline,// 折线
        Polygon, // 多边形
        Curve    // Bezier曲线， 四次三阶
    }

    public ShapeType shapeType = ShapeType.Point;
    public Material mat;
    public Color col = Color.red;
     
    private List<PathPoint> points; // 存放一组点,可以转换成各种二维图形
    private List<List<PathPoint>> pointsList; // 存放所有组的点

    private bool onlyPoints = true; // 为true时只绘制点
    // Use this for initialization
    void Start()
    {
        mat.color = col;
        points=new List<PathPoint>();
        pointsList=new List<List<PathPoint>>();
        pointsList.Add(points);

        LuaState luaState=new LuaState();
        luaState.DoString("print('hello world 世界')");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// 0 是左键,点击后添加一个点
        {
            var pos1 = Input.mousePosition;
            PathPoint point=new PathPoint(pos1.x,pos1.y);
            
            points.Add(point);
        }
        if (Input.GetMouseButtonUp(0))
        {      
        }
        if (Input.GetMouseButtonUp(1)) // 1 是右键，点击后说明一组点已经生成结束，开始生成下一组
        {
           points=new List<PathPoint>();
           pointsList.Add(points);
        }
        if (Input.GetMouseButtonDown(2))
        {
            onlyPoints = !onlyPoints;
        }
    }
    void OnPostRender()
    {
        if (onlyPoints)
        {
            DrawPoint();
            return;
        }
        switch (shapeType)
        {
            case ShapeType.Point:
                DrawPoint();
                break;
            case ShapeType.Segment:
                DrawSegment();
                break;
            case ShapeType.Polyline:
                DrawPolyLine();
                break;
            case ShapeType.Polygon:
                DrawPolygon();
                break;
            default: break;
        }
    }

    void DrawPoint()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Color(col);
        GL.Begin(GL.LINES);
        foreach (List<PathPoint> pointList in pointsList)
        {
            foreach (var point in pointList)
            {
                float size = 0.003f;
                GL.Vertex3(point.X/Screen.width,point.Z/Screen.height,0);
                GL.Vertex3(point.X / Screen.width+size, point.Z / Screen.height+size, 0);

            }

        }
        GL.End();
        GL.PopMatrix();
    }

    void DrawSegment()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Color(col);
        GL.Begin(GL.LINES);
        foreach (var pointList in pointsList)
        {
            foreach (var point in pointList)
            {
                GL.Vertex3(point.X / Screen.width, point.Z / Screen.height, 0);
            }
        }
        GL.End();
        GL.PopMatrix();
    }

    void DrawPolyLine()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Color(col);
       
        foreach (var pointList in pointsList)
        {
            GL.Begin(GL.LINE_STRIP);
            foreach (var point in pointList)
            {
                GL.Vertex3(point.X / Screen.width, point.Z / Screen.height, 0);
            }
            GL.End();
        }
      
        GL.PopMatrix();
    }

    void DrawPolygon()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Color(col);

        foreach (var pointList in pointsList)
        {
            GL.Begin(GL.LINE_STRIP);
            foreach (var point in pointList)
            {
                GL.Vertex3(point.X / Screen.width, point.Z / Screen.height, 0);
            }
            GL.Vertex3(pointList[0].X/Screen.width,pointList[0].Z/Screen.height,0);
            GL.End();
        }

        GL.PopMatrix();
    }
}
