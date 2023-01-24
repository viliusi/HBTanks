using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {

    }

    public void Player1()
    {
        SceneManager.LoadScene(3);
    }

    public void Player2()
    {
        SceneManager.LoadScene(3);
    }

    public void Player3()
    {
        SceneManager.LoadScene(3);
    }

    public void Player4()
    {
        SceneManager.LoadScene(3);
    }
}
