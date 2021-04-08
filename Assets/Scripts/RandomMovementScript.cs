using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementScript : MonoBehaviour
{
    public Transform objectTransform;
    public LineRenderer originalLine;
    public LineRenderer bezierLine;   
    public float time = 15f;

    /// <summary>
    /// Defines movement trajectory for the object based on a randomly generated trajectory and a given time
    /// </summary>
    public void StartRandomMovement()
    {
        var trajectory = GenerationMethods.GeneratePath(-200f, 100f, 2, -250f, -450f, 35);
        var BezierTrajectory = BezierCurve.BezierDraw(0.08f, trajectory);
        
        DrawScript.DrawLine(trajectory, originalLine);
        DrawScript.DrawLine(BezierTrajectory, bezierLine);

        //Setting the starting position of the ball to the first point of trajectory
        objectTransform.position = BezierTrajectory[0];
        
        
        DOTween.Play(GenerationMethods.GenerateSequence(BezierTrajectory, objectTransform, time));
    }

    
    
}
