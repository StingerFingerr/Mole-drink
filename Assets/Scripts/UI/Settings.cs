using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class Settings: MonoBehaviour
    {
        public Slider sensSlider;
        public float minSens=5;
        public float maxSens=120;
        public TextMeshProUGUI sensValueText;

        public Slider musicSlider;
        public TextMeshProUGUI musicValueText;
        
        public Slider effectsSlider;
        public TextMeshProUGUI effectsValueText;
        
        public AudioMixer masterAudio;

        private bool _markerActive;
        private bool _isInited;

        private void Awake()
        {
            if (_isInited is false)
            {
                Init();
            }
        }

        private void OnEnable()
        {
            _markerActive = MarkerController.instance.IsActive;
            
            MarkerController.instance.Hide();
            
            sensSlider.onValueChanged.AddListener(ChangeSens);
            musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
            effectsSlider.onValueChanged.AddListener(ChangeEffectsVolume);

            Time.timeScale = 0;
        }

        private void Init()
        {
            _isInited = true;
            
            ChangeSens(MouseRotation.sensitivity/120);
            ChangeMusicVolume(1);
            ChangeEffectsVolume(1);
        }

        private void OnDisable()
        {
            if(_markerActive)
                MarkerController.instance.Show();
            else
                MarkerController.instance.Hide();
            
            sensSlider.onValueChanged.RemoveListener(ChangeSens);
            musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
            effectsSlider.onValueChanged.RemoveListener(ChangeEffectsVolume);

            Time.timeScale = 1;

            UiController.instance.SetUiClicked();
        }

        private void ChangeSens(float sens)
        {
            float newSense = Mathf.Lerp(minSens, maxSens, sens);
            MouseRotation.sensitivity = newSense;
            sensValueText.text = $"{(int)(newSense)}";
            UiController.instance.SetUiClicked();
        }
        
        private void ChangeMusicVolume(float vol)
        {
            masterAudio.SetFloat("MusicVolume", Mathf.Lerp(-30, 20, vol));
            musicValueText.text = $"{(int)(vol * 100)}%";
            UiController.instance.SetUiClicked();
        }

        private void ChangeEffectsVolume(float vol)
        {
            masterAudio.SetFloat("EffectsVolume", Mathf.Lerp(-30, 20, vol));
            effectsValueText.text = $"{(int)(vol * 100)}%";
            UiController.instance.SetUiClicked();
        }
    }
}