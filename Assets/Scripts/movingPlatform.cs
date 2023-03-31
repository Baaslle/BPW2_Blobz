using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float amp;
    public float freq;

    public void Update()
    {
        transform.localPosition = new Vector3(Sine(amp, freq), 0, 0);
    }

    private float Sine(float amplitude, float frequency)
    {
        return Mathf.Sin(Time.time * frequency) * amplitude;
    }
}