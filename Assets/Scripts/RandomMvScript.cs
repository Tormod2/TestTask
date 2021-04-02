using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomMvScript : MonoBehaviour
{
    public Transform tr;
    public LineRenderer lr;
    public LineRenderer bezier;

    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        List<Vector3> Trajectory = new List<Vector3>();
        
        foreach (var g in GeneratePath())
        {
            Trajectory.Add(g);            
        }
        
        lr.positionCount = Trajectory.Count;
        tr.position = Trajectory[0];
        
        List<Vector3> BezierTrajectory = BezierCurve.BezierDraw(0.08f, Trajectory);
        bezier.positionCount = BezierTrajectory.Count;

        for (int i = 0; i < BezierTrajectory.Count; i++)
        {
            Vector3 t = BezierTrajectory[i];
            mySequence.Append(transform.DOMove(t, 0.2f).SetSpeedBased().SetEase(Ease.Linear));
            bezier.SetPosition(i, t);
        }
        foreach (var t in Trajectory)
        {           
            lr.SetPosition(Trajectory.IndexOf(t), t);
        }        
        DOTween.Play(mySequence);

    }

    public IEnumerable<Vector3> GeneratePath()
    {
        List<Vector3> path = new List<Vector3>();

        int DotAmount = Convert.ToInt32(UnityEngine.Random.Range(20f, 50f));

        for(int i = 0; i < DotAmount; i++)
        {
            path.Add(new Vector3(UnityEngine.Random.Range(-100f, 100f), 2, UnityEngine.Random.Range(-400f, -200f)));
        }
        IEnumerable<Vector3> sorted = path.OrderBy(v => v.x).ThenBy(v => v.z);

        return sorted;
    }
}
