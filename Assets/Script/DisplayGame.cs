using UnityEngine;
using UnityEngine.UI;
using GameLogic;

public class DisplayGame : MonoBehaviour
{    
    [SerializeField] private Button _peasantButton;
    [SerializeField] private Button _warriorButton;
   
    [SerializeField] private Image _gameOwerRaid;
    [SerializeField] private Image _gameOverWheat;
    [SerializeField] private Image _victoria;

    void Update()
    {      
        NoActiv();
    }
    void OnEnable()
    {
        GameManager.GameOver += StartGameOver;
    }
    void OnDisable()
    {
        GameManager.GameOver -= StartGameOver;
    }  
    void StartGameOver (int idGameOver)
    {
        if (idGameOver == 0)
            _gameOverWheat.gameObject.SetActive(true);
        else if (idGameOver == 1)
            _gameOwerRaid.gameObject.SetActive(true);
        else _victoria.gameObject.SetActive(true);
         Time.timeScale = 0;
       AudioListener.volume = 0;
    }
    void NoActiv()
    {
        if (GameManager.instance.noCreate <= 5)
        {
            _peasantButton.interactable = false;
            _peasantButton.enabled = false;
            _warriorButton.interactable = false;
            _warriorButton.enabled = false;
        }
        else
        {
            _peasantButton.enabled = true;
            _warriorButton.enabled = true;
        }
    }   
}
