using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private List<Vector3> linePos;
             private bool startDraw = false;
             private Vector3 oldMousePosition;
         public float StepSize = 80f;//每次差值的步长
          public float size = 60f;//每个单独模块的宽度
           public Material LineMaterial;
           public Color color = Color.red;
             public float roud = 30;
    // Use this for initialization
    void Start () {
        linePos = new List<Vector3>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	    if (Input.GetMouseButtonDown(0))
	    {
	       oldMousePosition = Input.mousePosition;
	       color = Color.red;
	       startDraw = true;
	    }
	    if (Input.GetMouseButtonUp(0))
	    {
	       startDraw = false;
	       linePos.Clear();//清理绘制点，不然每帧都会重新绘制
	    }
	    if (Input.GetMouseButtonDown(1))
	    {
	       oldMousePosition = Input.mousePosition;
	       startDraw = true;
	        color = Color.white;
	    }
	    if (Input.GetMouseButtonUp(1))
	     {
	         startDraw = false;
	       linePos.Clear();//清理绘制点，不然每帧都会重新绘制
	     }
	    if (startDraw)
	    {
	        if (StepSize == 0) return;
	        var newMousePosition = (Vector2)Input.mousePosition;
	        if (Vector2.Distance(newMousePosition, oldMousePosition) < size) return;
	        float stepCount = Vector2.Distance(oldMousePosition, newMousePosition) / StepSize + 1;
	        for (int i = 0; i < stepCount; i++)
	        {
	            var subMousePosition = Vector3.Lerp(oldMousePosition, newMousePosition, i / stepCount);
	            linePos.Add(subMousePosition);
	        }
	        oldMousePosition = newMousePosition;

        }
    }
    public void OnRenderObject()
    {
         GL.PushMatrix();
         LineMaterial.SetPass(0);
         for (int i = 0; i<linePos.Count - 1; i++)
         {
             Vector3 startPos = linePos[i];
             Vector3 endPos = linePos[i + 1];
             DrawLineFun(startPos.x, startPos.y, endPos.x, endPos.y);
         }
         GL.PopMatrix();
    }
    void DrawLineFun(float x1, float y1, float x2, float y2)
    {
        DrawRect(x1 - roud, y1 - roud, 2 * roud, color);
    }

     void DrawRect(float x, float y, float width, Color myColor)
     {
         float height = width;
         //绘制2D图像  
         GL.LoadOrtho();
         GL.Begin(GL.QUADS);
         GL.Color(myColor);
         GL.Vertex3(x / Screen.width, y / Screen.height, 0);
         GL.Vertex3(x / Screen.width, (y + height) / Screen.height, 0);
         GL.Vertex3((x + width) / Screen.width, (y + height) / Screen.height, 0);
         GL.Vertex3((x + width) / Screen.width, y / Screen.height, 0);
        GL.End();
 
    }
}
