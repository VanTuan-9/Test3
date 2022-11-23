using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] pointsObj;
    [SerializeField] GameObject player;
    [SerializeField] GameObject notify;    
    [SerializeField] GameObject score;
    [SerializeField] TMPro.TMP_Text notifyText;
    [SerializeField] TMPro.TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        notify.SetActive(false);
        initPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && notify.activeInHierarchy)
            Retry();
    }

    public void PopUp(string title, int score) {
        notifyText.SetText(title + "\nScore: " + score);
        notify.SetActive(true);
    }

    public void Retry() {
        notify.SetActive(false);
        scoreText.SetText("0");
        initPoint();
    }

    public bool checkPos(int x1, int x2, int z1, int z2) {
        if(x1 + z1 < 6)
            return false;
        if(Mathf.Abs(x1 - x2) <= 3 || Mathf.Abs(z1 - z2) <= 3)
            return false;
        return true;
    }
    public bool checkNewPosition(int x, int z) {
        foreach (var item in pointsObj)
        {   
            if(Mathf.Abs(x - item.transform.position.x) <= 3 || Mathf.Abs(z - item.transform.position.z) <= 3)
                return false;
        }
        return true;
    }

    public void initPoint() {
        int x1 = 0, x2 = 0, z1 = 0, z2 = 0, x3 = 0, z3 = 0;
        do {
            x1 = Random.Range(-23, 24);
            z1 = Random.Range(-23, 24);
            x2 = Random.Range(-23, 24);
            z2 = Random.Range(-23, 24);
            x3 = Random.Range(-23, 24);
            z3 = Random.Range(-23, 24);
        } while(!checkPos(x1, x2, z1, z2) || !checkPos(x1, x3, z1, z3) || !checkPos(x3, x2, z3, z2));
        pointsObj[0].transform.position = new Vector3(x1, 1 , z1);
        pointsObj[1].transform.position = new Vector3(x2, 1 , z2);
        pointsObj[2].transform.position = new Vector3(x3, 1 , z3);
        player.transform.position = new Vector3(0, 1, 0);
    }

    public void changeCamera() {
        if(Camera.main.depth == -1) {
            Camera.main.depth = 1;
        }
        else
            Camera.main.depth = -1;
    }
}
