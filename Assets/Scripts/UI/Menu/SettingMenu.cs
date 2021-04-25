
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public event UnityAction VolumeOfSoundsIsChanged; // TODO : rename event

    [SerializeField] private Button _mute;
    [SerializeField] private Button _edit;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _apply;

    private void OnEnable()
    {
        _mute.Click += ResetVolumeOfMusic;
        _edit.Click += EditGameSetting;
        _apply.Click += ApplyChangeOfSetting;
    }

    private void OnDisable()
    {
        _mute.Click -= ResetVolumeOfMusic;
        _edit.Click -= EditGameSetting;
        _apply.Click -= ApplyChangeOfSetting;
    }

    private void ResetVolumeOfMusic()
    {
        _slider.value = 0;
    }

    private void EditGameSetting() // TODO : rename method
    {
        _slider.gameObject.SetActive(true);
        _apply.gameObject.SetActive(true);
        _edit.gameObject.SetActive(false);
    }

    private void ApplyChangeOfSetting()
    {
        _edit.gameObject.SetActive(true);
        _slider.gameObject.SetActive(false);
        _apply.gameObject.SetActive(false);

        VolumeOfSoundsIsChanged?.Invoke();
    }
}
