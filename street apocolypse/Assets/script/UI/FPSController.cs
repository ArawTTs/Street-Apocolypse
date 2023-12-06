using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSController : MonoBehaviour
{
    public void FPSChanger30()
    {
        Application.targetFrameRate = 30;
    }

    public void FPSChanger60()
    {
        Application.targetFrameRate = 60;
    }

    public void FPSChanger120()
    {
        Application.targetFrameRate = 120;
    }
}

