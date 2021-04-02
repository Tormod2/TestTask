using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeScript : MonoBehaviour
{   
    public TMP_Text currentLap;
    public TMP_Text lastLap;    
    private float _time;   

    void Update()
    {
        _time += Time.deltaTime;
        currentLap.text = $"Текущий круг: {Mathf.FloorToInt(_time % 60)}";
    }

    public void Refresh()
    {                     
        lastLap.text = "Прошлый круг: " + currentLap.text.Remove(0, 14);
        _time = 0f;
    }
}
