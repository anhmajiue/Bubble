using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowDiagonal : MonoBehaviour
{ 
    public LineRenderer line;

    float x, y, z;
 
    private float v0x;
    private float v0z;
    public float gravity = 9.8f;
  
    private float v0y;
    [SerializeField]
    Vector3 v0; // xOy 
    private Vector3 startPosition;
    LineRenderer lineRenderer;

    float deltaTime = 0.1f;

    int numPoints = 100;

    public float t ;
    // Start is called before the first frame update
    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        startPosition = transform.position;

        v0x = v0.x; // StartSpeed * Mathf.Cos(alpha * Mathf.Deg2Rad);
      
        v0y = v0.y; //StartSpeed * Mathf.Sin(alpha * Mathf.Deg2Rad) - gravity * t;
        
        v0z = v0.z;
        PredictTrajectory();
        Debug.Break(); //PAUSE EDITOR
    }
   
    
    void PredictTrajectory()
    {
        lineRenderer.positionCount = numPoints;
        for (int i = 0; i < numPoints; i++)
        {
            float t = i * deltaTime; // khoang thoi gian troi di tai diem thu i
            Vector3 pos = GetPosition(t);
            lineRenderer.SetPosition(i, pos);
        }

    }

    Vector3 GetPosition(float t)
    {
        x = startPosition.x + v0x * t;
        y = startPosition.y + v0y * t - (0.5f * gravity * t * t);
        z = startPosition.z + v0z * t;
        return new Vector3(x, y, z);
    }


    // Update is called once per frame
    void Update()
    {
       
        transform.position = GetPosition(t);
        t = t + Time.deltaTime;



    }
}
