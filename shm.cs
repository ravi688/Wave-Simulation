using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shm : MonoBehaviour {

    private Rigidbody rb;
    private float meanpos;
    private Vector3 MeanPos3;

    public float mass;
    public float k;
    public float impulseMagnitude = 1f;

    public float amplitude = 1f;
    public float angularfrequency = 10f;
    public float phase = Mathf.PI/10f;      
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        meanpos = transform.position.y;
        MeanPos3 = transform.position;
	}
    void Update()
    {
        MeanPos3.y += SHM_Eq(amplitude, angularfrequency, phase);
        transform.position = MeanPos3;
    }
    float SHM_Eq(float amp, float ang_freq, float phase)
    {
        float disp = amp * Mathf.Sin(ang_freq * Time.time + phase);
        return disp;
    }
    void SHM()
    {
        if (Input.GetKeyDown(KeyCode.I))
            impulse(impulseMagnitude);
        force();
    }
    void force()
    {

        rb.AddForce(0, -k * (transform.position.y - meanpos), 0);
    }
    void impulse(float magnitude)
    {
        rb.AddForce(0, magnitude, 0);
    }
}
