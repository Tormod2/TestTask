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
    private bool _isPressed;

    void Update()
    {
        if (_isPressed)
        {
            _time += Time.deltaTime;
            currentLap.text = $"Текущее время: {Mathf.FloorToInt(_time % 60)}";           
        }
    }

    public void Refresh()
    {
        lastLap.text = "Прошлый круг: " + currentLap.text.Remove(0, 14);
        _time = 0f;
    }

    public void CompleteLine()
    {
        _isPressed = false;
    }
    public void StartTimer()
    {
        _isPressed = true;
    }
}
