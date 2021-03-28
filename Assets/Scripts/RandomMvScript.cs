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

    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        List<Vector3> _trajectory = new List<Vector3>();

        foreach (var g in GeneratePath())
        {
            _trajectory.Add(g);
            Debug.Log(g.x+" "+" "+g.y+" "+g.z);
            
        }
        lr.positionCount = _trajectory.Count;
        tr.position = _trajectory[0];
        
        foreach (var t in _trajectory)
        {
            mySequence.Append(transform.DOMove(t, 0.8f).SetSpeedBased().SetEase(Ease.Linear));
            lr.SetPosition(_trajectory.IndexOf(t), t);
        }
        

        DOTween.Play(mySequence);

    }

    public IEnumerable<Vector3> GeneratePath()
    {
        List<Vector3> path = new List<Vector3>();

        int DotAmount = Convert.ToInt32(UnityEngine.Random.Range(20f, 50f));

        for(int i = 0; i < DotAmount; i++)
        {
            path.Add(new Vector3(UnityEngine.Random.Range(-200f, 100f), 2, UnityEngine.Random.Range(-500f, -200f)));
        }
        IEnumerable<Vector3> sorted = path.OrderBy(v => v.x).ThenBy(v => v.z);

        return sorted;
    }
}
