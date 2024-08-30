using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotateClock : MonoBehaviour
{
    public RectTransform ClockGO;
    public TextMeshProUGUI dayText;

    public float minuteToDay;
    public float degreeAtStart;
    public bool isRotating;

    public int day;
    private bool minToggle;
    // Start is called before the first frame update
    void Start()
    {
        minToggle = false;
        day = 1;
        degreeAtStart = ClockGO.rotation.eulerAngles.z;
        isRotating = false;
        Debug.Log("IN " + getClockEulerRotationZ());
    }

    public void StartTime() {
       
        if(Mathf.FloorToInt(getClockEulerRotationZ()) < degreeAtStart-1)
        {
            minToggle = true;
        }

        if (minToggle && Mathf.FloorToInt(getClockEulerRotationZ()) >= degreeAtStart)
        {
            PauseTime();
        }

        float rot = getClockEulerRotationZ() + Time.deltaTime;
        Debug.Log(ClockGO.localEulerAngles.z);
        ClockGO.Rotate(0, 0, (360 / (60 * minuteToDay)) * Time.deltaTime);
    }

    private void Update()
    {
        if (!isRotating)
        {
            StartTime();
        }
    }

    public void PauseTime()
    {
        isRotating = !isRotating;
    }
    
    public float getClockEulerRotationZ()
    {
        return ClockGO.transform.localEulerAngles.z;
    }
}
