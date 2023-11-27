using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] Button button1;
    void Awake()
    {
        button1.onClick.AddListener(StartGame);
    }
    void Start()
    {
     Cursor.visible=true;  
     Cursor.lockState=CursorLockMode.None;
    }

    private void StartGame(){
        SceneManager.LoadScene(1);
    }
}
