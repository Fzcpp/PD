using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * sunzhao：2018-7-11
 * 
 * Shape 是所有二维图形的基类，维护点的链表
 * 
 * 
 */
public class Shape  {

	// Use this for initialization

    private List<PathPoint> _points;

    // 增加顶点
    public void AddPathNode(PathPoint point)
    {
        if (_points.Count == 0)
        {
            _points.Add(point);
        }
        else
        {
            PathPoint temp = _points[_points.Count-1];
            temp.SetNext(point);  
            point.SetPrev(temp); 
            _points.Add(point);
        }
       
    }
    // 删除顶点，point 必须是_points中的对象
    public void DeletePathNode(PathPoint point)
    {
        if (point == null || _points.Contains(point) == false)
            return;
        PathPoint prev = point.GetPrev();
        PathPoint next = point.GetNext();
        if(prev!=null)
            prev.SetNext(next);      // 目标节点的上一个顶点指向目标的下一个顶点
        if(next!=null)
            next.SetPrev(prev);       // 目标节点的下一个节点指向目标的上一个节点

        _points.Remove(point);
    }

    // 获取顶点
    public List<PathPoint> GetPathPoints()
    {   
        return _points;
    }
}
