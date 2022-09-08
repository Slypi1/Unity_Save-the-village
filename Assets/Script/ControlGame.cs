using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlGame : MonoBehaviour
{
    [SerializeField] private Button _pauseGame;
    [SerializeField] private Sprite _pausespriteOn;
    [SerializeField] private Sprite _pausespriteOff;
    [SerializeField] private Image _pauseImage;

    [SerializeField] private Button _noSound;
    [SerializeField] private Sprite _noSoundOn;
    [SerializeField] private Sprite _noSoundOff;

    [SerializeField] private Image _Image;

    private bool _pauseGameActiv;
    private bool _onSoundActiv;
    public void PauseGame()
    {

        if (_pauseGameActiv)
        {
            Time.timeScale = 0;
            _pauseGame.image.sprite = _pausespriteOn;
            _pauseImage.gameObject.SetActive (true);
        }
        else
        {
            Time.timeScale = 1;
            _pauseGame.image.sprite = _pausespriteOff;
            _pauseImage.gameObject.SetActive(false);
        }
        _pauseGameActiv = !_pauseGameActiv;
    }
    public void NoSound()
    {

        if (_onSoundActiv)
        {

            AudioListener.volume = 0;
            _noSound.image.sprite = _noSoundOff;
        }
        else
        {
            AudioListener.volume = 1;
            _noSound.image.sprite = _noSoundOn;
        }
        _onSoundActiv = !_onSoundActiv;
    }

    public void AgainGame()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ProceedGame()
    {
        _Image.gameObject.SetActive(false);
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
