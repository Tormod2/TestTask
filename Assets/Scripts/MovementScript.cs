using DG.Tweening;
using Dropbox.Api;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class MovementScript : MonoBehaviour
{
    
    public Transform tr;
    public LineRenderer lr;
    private Data _data;

    private void Start()
    {
        _data = DownloadScript.GetData();
        Sequence mySequence = DOTween.Sequence();
        List<float> distances = new List<float>();
        float sumDistance = 0f;                      
        tr.position = _data.Trajectory[0];

        if (_data.Loop == true)
        {
            _data.Trajectory.Add(_data.Trajectory[0]);
            mySequence.SetLoops(-1);
                    
        }       
        for (int i = 0; i < _data.Trajectory.Count - 1; i++)
        {
            distances.Add(Vector3.Distance(_data.Trajectory[i], _data.Trajectory[i + 1]));
            sumDistance += Vector3.Distance(_data.Trajectory[i], _data.Trajectory[i + 1]);
        }
        lr.positionCount = _data.Trajectory.Count;
        lr.SetPositions(_data.Trajectory.ToArray());
        _data.Trajectory.RemoveAt(0);
        foreach (var t in _data.Trajectory)
        {
            mySequence.Append(transform.DOMove(t, _data.Time*distances[_data.Trajectory.IndexOf(t)] / sumDistance).SetSpeedBased().SetEase(Ease.Linear));
            lr.SetPosition(_data.Trajectory.IndexOf(t)+1, t);
        }        
        DOTween.Play(mySequence);
    }
}





