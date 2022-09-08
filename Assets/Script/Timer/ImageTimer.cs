using UnityEngine;
using UnityEngine.UI;

namespace Timers
{
    public class ImageTimer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audio;

        public float maxTine;
        public bool startTime;

        private Image _image;
        private float _currentTime;
        
        void Start()
        {
            _image = GetComponent<Image>();
            _currentTime = maxTine;
        }
        void Update()
        {
            startTime = false;
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                startTime = true;
                _currentTime = maxTine;
                _audio.Play();
            }
            _image.fillAmount = _currentTime / maxTine;
        }
    }
}
