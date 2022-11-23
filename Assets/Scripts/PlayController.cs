using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Material[] materials;
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] GameObject notify;
    public float Speed = 10;

    private Rigidbody _rigidbody;
    private Renderer thisRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        thisRenderer = this.GetComponent<Renderer>();
        int index = Random.Range(0, 3);
        thisRenderer.material.SetColor("_Color", materials[index].color);
    }

    // Update is called once per frame
    void Update()
    {
        if(Speed > 20)
            Speed = 20;
        if((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && !notify.activeInHierarchy) {
            _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed);
        }
    }

}
