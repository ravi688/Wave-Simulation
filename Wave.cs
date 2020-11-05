using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private Transform[] bodies;
    private MeshRenderer[] renderers;
    private Vector3 disp;
    public enum color
    {
        blue,
        green,
        red,
        yellow,
        white,
    }

    
    public float amplitude = 2f;
    public float angularfrequency = 5f;
    public float constant = 5f;
    public  float position = 0;
    public float phase = 0;
    public float jDistance = 0;
    public float colorgradient;
    public color __color;
	// Use this for initialization
	void Start () {
        bodies = GetComponentsInChildren<Transform>();
        renderers = GetComponentsInChildren<MeshRenderer>();
        disp = new Vector3(0, 0, 0);
        
	}
    
    void Update()
    {
        foreach (Transform item in bodies)
        {
            
            disp = item.position;
           
            disp.y = jDistance + wave(amplitude, angularfrequency, constant, item.position.x,phase);
            item.position = disp;
            
        }
        foreach (MeshRenderer item in renderers)
        {
            item.material.color = _color();
        }
    }
    Color _color()
    {
        switch (__color)
        {
            case color.blue :
                return Color.blue;
            case color.white :
                return Color.white;
            case color.green :
                return Color.green;
            case color.red :
                return Color.red; 
            case color.yellow :
                return Color.yellow;
            default :
                return Color.yellow;
        }
    }
    float wave(float amp, float ang_freq, float constant,float pos, float phase = 0)
    {
        float disp = amp * Mathf.Sin(constant * pos - ang_freq * Time.time + phase);
        return disp;
    }
}
