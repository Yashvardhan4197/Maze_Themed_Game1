using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartController : MonoBehaviour
{
    [SerializeField]Button restart;
    [SerializeField]Button quit;
    [SerializeField]Button Lobby;
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(restartGame);
        quit.onClick.AddListener(QuitGame);
        Lobby.onClick.AddListener(GoLobby);
    }

    void restartGame(){
        SceneManager.LoadScene(1);
    }
    void QuitGame(){
        Application.Quit();
    }

    void GoLobby(){
        SceneManager.LoadScene(0);
    }
}
