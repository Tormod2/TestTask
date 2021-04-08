using TMPro;
using UnityEngine;



public class TimeScript : MonoBehaviour
{
    public TMP_Text currentLap;
    public TMP_Text lastLap;
    private float _time;
    private bool _isPressed;

    private void Update()
    {
        if (_isPressed)
        {
            _time += Time.deltaTime;
            currentLap.text = $"Текущее время: {GetSeconds()}";           
        }
    }

    public void Refresh()
    {
        lastLap.text = $"Прошлый круг: {GetSeconds()}";
        _time = 0f;
    }

    private int GetSeconds()
    {
        return Mathf.FloorToInt(_time % 60);
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
