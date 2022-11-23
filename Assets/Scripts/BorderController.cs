using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int check = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c) {
        float x = -player.transform.position.x;
        float z = -player.transform.position.z; 
        if(check == 1) {
            int k = -1;
            if(player.transform.position.x > 0)
                k = 1;
            player.transform.position = new Vector3(x + k, 1, -z);

            if(Input.GetButton("Horizontal") && Input.GetButton("Vertical")) {
                
            }

        }
        else {
            int k = -1;
            if(player.transform.position.z > 0)
                k = 1;
            player.transform.position = new Vector3(-x, 1, z + k);
        }
    }
}
