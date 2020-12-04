using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Habrador_Computational_Geometry
{
    //Axis-Aligned-Bounding-Box, which is a rectangle in 2d space aligned along the x-y axis
    public struct AABB2
    {
        public MyVector2 min;
        public MyVector2 max;


        //We know the min and max values
        public AABB2(float minX, float maxX, float minY, float maxY)
        {
            this.min = new MyVector2(minX, minY);
            this.max = new MyVector2(maxX, maxY);
        }


        //We have a list with points and want to find the min and max values
        public AABB2(List<MyVector2> points)
        {
            MyVector2 p1 = points[0];

            float minX = p1.x;
            float maxX = p1.x;
            float minY = p1.y;
            float maxY = p1.y;

            for (int i = 1; i < points.Count; i++)
            {
                MyVector2 p = points[i];

                if (p.x < minX)
                {
                    minX = p.x;
                }
                else if (p.x > maxX)
                {
                    maxX = p.x;
                }

                if (p.y < minY)
                {
                    minY = p.y;
                }
                else if (p.y > maxY)
                {
                    maxY = p.y;
                }
            }

            this.min = new MyVector2(minX, minY);
            this.max = new MyVector2(maxX, maxY);
        }
    }



    //Axis-Aligned-Bounding-Box, which is a box in 3d space aligned along the x-y-z axis
    public struct AABB3
    {
        public MyVector3 max;
        public MyVector3 min;



        //Bounds is a Unity data structure
        //You can get it from either mesh (local space)
        //or mesh renderer world space
        public AABB3(Bounds bounds)
        {
            this.max = bounds.max.ToMyVector3();
            this.min = bounds.min.ToMyVector3();
        }



        //Its common that we want to display this box for debugging, so return a list with edges that form the box
        public List<Edge3> GetEdges()
        {
            //Get the corners
            //top is y-axis, front is z-axis, and right is x-axis
            MyVector3 topFR = new MyVector3(max.x, max.y, max.z);
            MyVector3 topFL = new MyVector3(min.x, max.y, max.z);
            MyVector3 topBR = new MyVector3(max.x, max.y, min.z);
            MyVector3 topBL = new MyVector3(min.x, max.y, min.z);

            MyVector3 bottomFR = new MyVector3(max.x, min.y, max.z);
            MyVector3 bottomFL = new MyVector3(min.x, min.y, max.z);
            MyVector3 bottomBR = new MyVector3(max.x, min.y, min.z);
            MyVector3 bottomBL = new MyVector3(min.x, min.y, min.z);


            List<Edge3> edges = new List<Edge3>()
            {
                new Edge3(topFR, topFL),
                new Edge3(topFL, topBL),
                new Edge3(topBL, topBR),
                new Edge3(topBR, topFR),

                new Edge3(bottomFR, bottomFL),
                new Edge3(bottomFL, bottomBL),
                new Edge3(bottomBL, bottomBR),
                new Edge3(bottomBR, bottomFR),

                new Edge3(topFR, bottomFR),
                new Edge3(topFL, bottomFL),
                new Edge3(topBL, bottomBL),
                new Edge3(topBR, bottomBR),
            };

            return edges;
        }



        //Get all corners of the box
        public HashSet<MyVector3> GetCorners()
        {
            //Get the corners
            //top is y-axis, front is z-axis, and right is x-axis
            MyVector3 topFR = new MyVector3(max.x, max.y, max.z);
            MyVector3 topFL = new MyVector3(min.x, max.y, max.z);
            MyVector3 topBR = new MyVector3(max.x, max.y, min.z);
            MyVector3 topBL = new MyVector3(min.x, max.y, min.z);

            MyVector3 bottomFR = new MyVector3(max.x, min.y, max.z);
            MyVector3 bottomFL = new MyVector3(min.x, min.y, max.z);
            MyVector3 bottomBR = new MyVector3(max.x, min.y, min.z);
            MyVector3 bottomBL = new MyVector3(min.x, min.y, min.z);


            HashSet<MyVector3> corners = new HashSet<MyVector3>()
            {
                topFR,
                topFL,
                topBR,
                topBL,

                bottomFR,
                bottomFL,
                bottomBR,
                bottomBL,
            };

            return corners;
        }
    }
}
