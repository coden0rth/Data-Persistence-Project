using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text playerName;
    public Text scoreText;
    public InputField inputField;

void Start(){
    DataManager.Instance.LoadData();
    playerName.text = DataManager.Instance.playerName;
    scoreText.text = DataManager.Instance.playerScore.ToString();
}
public void StartGameButton(){
    if(playerName.text != null){
        DataManager.Instance.currentPlayer = inputField.text;
        SceneManager.LoadScene("main");
    
    }
}

public void ExitGameButton(){
    Application.Quit();
}

}
