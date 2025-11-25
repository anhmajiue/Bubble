using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Shoot : MonoBehaviour
{
    
    

    public float maxDistance = 100f; 
    public LayerMask bubbleLayer;    
    public int score = 0;  
    
    public GameScene GameScene;
    void Start()
    {
        
    }

    

    void Shooting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, bubbleLayer))
        {
            
            
            //Destroy(hit.collider.gameObject);
            BubbleRise bubble = hit.collider.GetComponent<BubbleRise>();
            if (bubble != null)
            {
                bubble.OnHit();   
                
                GameScene.AddScore(1);
                Debug.Log("Score: " + score);
            }


        }
    }
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }
   
   
}
