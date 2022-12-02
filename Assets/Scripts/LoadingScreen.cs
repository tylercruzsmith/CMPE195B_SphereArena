using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSoccer(){
        SceneManager.LoadScene("BallGame");
    }

    public void LoadBowling(){
        SceneManager.LoadScene("BowlingGame");
    }

     public void LoadMaze(){
        SceneManager.LoadScene("MazeGame");
    }

     public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
}