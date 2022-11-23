using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameObject player;
    [SerializeField] Material[] materials;
    [SerializeField] TMPro.TMP_Text scoreText;

    private Renderer playerRenderer;
    private Renderer thisRenderer;

    private Animator animator;

    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = player.GetComponent<Renderer>();
        thisRenderer = this.GetComponent<Renderer>();
        // animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(animator.GetBool("isTrigger"))
        //     animator.SetBool("isTrigger", false);
    }

    void OnTriggerEnter(Collider c) {
        int score = int.Parse(scoreText.text);     
        if(playerRenderer.material.color != thisRenderer.material.color)
            gameController.PopUp("Game Over", score);
        else {
            int x = 0, z = 0;
            do {
                x = Random.Range(-23, 24);
                z = Random.Range(-23, 24);
            } while(!gameController.checkNewPosition(x, z)); 
            this.transform.position = new Vector3(this.transform.position.x, -2, this.transform.position.z);
            StartCoroutine(initPoint(x,z));                
            score++;
            scoreText.SetText("" + score);
            int index = 0;
            do {
                index = Random.Range(0, 3);
            } while (playerRenderer.material.color == materials[index].color);
            playerRenderer.material.SetColor("_Color", materials[index].color);
        }
        if(score == 10)
            gameController.PopUp("Victory", score);
    }

    IEnumerator initPoint(int x, int z)
    {
        yield return new WaitForSeconds(1);
        this.transform.position = new Vector3(x, 1, z); 
    }                                                                                   
}
