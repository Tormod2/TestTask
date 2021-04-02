using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class BezierCurve
{
    public static List<Vector3> BezierDraw(float step, List<Vector3> Trajectory)
    {
        List<Vector3> newTrajectory = new List<Vector3>();
        var tempLe = new List<Vector3>();

        for (int j=0;j< Trajectory.Count-2;j+=2) 
        {
            var temp = new List<Vector3>();                      
            temp.Add(Trajectory[j]);
            temp.Add(Trajectory[j+1]);
            temp.Add(Trajectory[j+2]);
            
            
            for (var t = 0f; t < 1 + step; t += step)
            {
                if (t > 1)
                {
                    t = 1;
                }
                var ind = tempLe.Count;
                tempLe.Add(Vector3.zero);

                for (var i = 0; i < temp.Count; i++)
                {
                    var newVector = tempLe[ind];
                    var b = Polinom(temp.Count - 1, t, i);

                    newVector.x += temp[i].x * b;
                    newVector.z += temp[i].z * b;
                    tempLe[ind] = newVector;
                }
            }
            //tempLe.Remove(tempLe.Last());
            newTrajectory.AddRange(tempLe);
            tempLe.Clear();
        }
        if (Trajectory.Count%2==0)
        {
            newTrajectory.Add(Trajectory.Last());
        }
        return newTrajectory;
    }
    public static int Factorial(int n)
    {
        return (n <= 1) ? 1 : n * Factorial(n - 1);
    }
    public static float Polinom(int n, float t, int i)
    {
        return (float)((Factorial(n) / (Factorial(i) * Factorial(n - i))) * Math.Pow(t, i) * Math.Pow(1 - t, n - i));
    }

}


