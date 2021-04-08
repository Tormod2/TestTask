using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MovementScript : MonoBehaviour
{   
    public Transform objectTransform;
    public LineRenderer line;   
    public UnityEvent loopends;
    public UnityEvent endOfTheLine;
    private Data _data;
    
    // Gets data at application launch     
    private void Start()
    {
        _data = DownloadScript.GetData();
    }

    /// <summary>
    /// Defines movement trajectory for the object based on a loaded data
    /// </summary>
    public void StartMovement()
    {
        var startPoint = _data.Trajectory[0];

        //Setting the starting position of the ball to the first point of trajectory
        objectTransform.position = startPoint;

        if(_data.Loop == true)
        {
            _data.Trajectory.Add(startPoint);
        }
        DrawScript.DrawLine(_data.Trajectory, line);
        var sequence = GenerationMethods.GenerateSequence(_data.Trajectory, objectTransform, _data.Time);

        if (_data.Loop == true)
        {
            sequence.OnComplete(() => {
                loopends?.Invoke();
                sequence.Restart();
            });
        }
        else
        {
            sequence.OnComplete(() => {
                endOfTheLine?.Invoke();
            });
        }

        DOTween.Play(sequence);
    }
}





