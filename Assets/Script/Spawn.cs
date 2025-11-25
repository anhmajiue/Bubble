using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject bubblesPrefab;
    public float xRange = 8f;
 
    public float spawnInterval = 1f;
    public float time = 0f;
    


    // Start is called before the first frame update
    void Start()
    {
       
    }
    
   void SpawnBubble()
    {
        
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange),-2f, 0f);                       
       

        Instantiate(bubblesPrefab, spawnPos , Quaternion.identity);

    }

    

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnInterval)
        {
            SpawnBubble();
           
            time=0f;
        }
 
    }
    
}
