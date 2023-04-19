using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlockController : MonoBehaviour
{
    public float cohesionSTR = 0;
    public float separationSTR = 0;

    public Slider cSlider;
    public Slider sSlider;

    // Update is called once per frame
    void Update()
    {
        cohesionSTR = cSlider.value;
        separationSTR = sSlider.value;
    }
}
