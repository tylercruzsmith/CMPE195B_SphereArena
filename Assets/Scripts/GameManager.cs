using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject bball;
    int score = 0;
    GameObject[] pins;
    public TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Return) || bball.transform.position.y < 20) {
            CheckPinsHit();
        }
    }

    void Move() {
        Vector3 position = bball.transform.position;
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -0.525f, 0.525f);
        bball.transform.position = position;
    }

    void CheckPinsHit() {
        for (int i=0; i<pins.Length ;i++){
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf) {
                score ++;
                pins[i].SetActive(false);
            }
        }
        
        scoreDisplay.text = score.ToString();
    }


    
}
