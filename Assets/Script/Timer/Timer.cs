using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour, ITimer
{
    [SerializeField] private float _timerMax;
    [SerializeField] private Button _createButton;
    [SerializeField] private AudioSource _audioTimer;

    private Image _imageTimer;
    private float _timer;
    void Awake()
    {
        FindObjectOfType<TimerSystem>().AddTimer(this);
        _imageTimer = GetComponent<Image>();
        _audioTimer = GetComponent<AudioSource>();
        _imageTimer.gameObject.SetActive(false);
    }   
    private void Update()
    {
        
        if (_timer > 0)
        {
            _createButton.interactable = false;
            _timer -= Time.deltaTime;
            _imageTimer.fillAmount = _timer / _timerMax;           
        }
        else
        {
            _createButton.interactable = true;
            _audioTimer.Pause();
        }
    }
    public void Tick()
    {
        _imageTimer.gameObject.SetActive(true);
        _timer = _timerMax;
        _audioTimer.Play();
    }
}
