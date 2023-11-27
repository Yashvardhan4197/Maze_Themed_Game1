using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] Button button1;
    void Start()
    {
        button1.onClick.AddListener(endLevel);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene(0);
        }
    }
    void endLevel(){
        Application.Quit();
    }
}
