using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void HomeClicked(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/HomeScreen");
    }
}
