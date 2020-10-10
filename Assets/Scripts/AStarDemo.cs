using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace AStar
{
    public class AStarDemo : MonoBehaviour
    {
        void Start()
        {
            int[,] array = {
                           { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                           { 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1},
                           { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1},
                           { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1},
                           { 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1},
                           { 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
                           { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                           { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
                           };
            Maze maze = new Maze(array);
            Point start = new Point(1, 1);
            Point end = new Point(6, 10);
            var parent = maze.FindPath(start, end, false);

            Stack<Point> stack = new Stack<Point>();
            while (parent != null)
            {
                stack.Push(parent);
                parent = parent.ParentPoint;
            }
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                Point point = stack.Pop();
                sb.Append("(");
                sb.Append(point.X);
                sb.Append(",");
                sb.Append(point.Y);
                sb.Append(")");
                sb.Append("->");
            }
            sb.Remove(sb.Length - 2, 2);
            Debug.Log("Print path:");
            Debug.Log(sb.ToString());
        }
    }
}
