using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.XR.WSA.WebCam;

public class PathPoint
{
      public float X, Z; // 坐标

      private PathPoint _prev; // 指向该点的上一个顶点
      private PathPoint _next; // 该点指向的下一个顶点

      public PathPoint() { }

      public PathPoint(float x, float z)
      {
        X = x;
        Z = z;
      }
      public void SetPrev(PathPoint prev)
      {
          this._prev = prev;
      }
      public PathPoint GetPrev()
      {
          return _prev;
      }

      public void SetNext(PathPoint next)
      {
          this._next = next;
      }
      public PathPoint GetNext()
      {
          return _next;
      } 
     
 }
 
