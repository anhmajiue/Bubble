using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRise : MonoBehaviour
{ 
    public float speed = 1f;
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    void Update()
    {
        if (!isHit)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void OnHit()
    {
        if (isHit)return;

        isHit = true;
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.red;
        }


        Destroy(gameObject, 1f);
    }
}
