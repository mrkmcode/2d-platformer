using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite cpOff, cpOn; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            CheckpointController.instance.DeactivateCheckpoints();
            
            theSR.sprite = cpOn;

            CheckpointController.instance.SetSpawnPoint(new Vector3(transform.position.x + 2, transform.position.y, transform.position.z));
        }
    }

    public void resetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
