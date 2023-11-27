using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private int heartinput;
    [SerializeField] Image[] hearts;
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
    }


    void Update()
    {
        for(int i=0;i<hearts.Length;i++){
            if(i<heartinput){
                hearts[i].enabled=true;
            }
            else{
                hearts[i].enabled=false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene(0);
        }
    }
    public void reduceHealth(){
        if(heartinput<=0)
        {
            SceneManager.LoadScene(0);
        }
        heartinput--;
    }


}
