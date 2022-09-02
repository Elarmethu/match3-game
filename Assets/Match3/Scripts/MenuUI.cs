using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class responsible about ui dependencies in menu scene.
/// </summary>
public class MenuUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _scoreWindow;
    [SerializeField] private GameObject _settingsWindow;

    [Header("Settings")]
    [SerializeField] private Image _gridText;
    [SerializeField] private Sprite[] _gridTextSprites;
    [SerializeField] private Image _audioText;
    [SerializeField] private Sprite[] _audioTextSprites;

    [Header("Scores")]
    [SerializeField] private Transform _scoreTransform;
    [SerializeField] private GameObject _scorePrefab;

    #region Settings 

    private void SettingsLoader()
    {
        if (!PlayerPrefs.HasKey(PrefsKey.audio))
        {
            PlayerPrefs.SetInt(PrefsKey.grid, 5);
            PlayerPrefs.Save();
        }

        if(!PlayerPrefs.HasKey(PrefsKey.grid))
        {
            PlayerPrefs.SetString(PrefsKey.audio, "Enable");
            PlayerPrefs.Save();
        }

        int grid = PlayerPrefs.GetInt(PrefsKey.grid);
        bool audio = PlayerPrefs.GetString(PrefsKey.audio) == "Enable" ? true : false;

        _audioText.sprite = audio ? _audioTextSprites[0] : _audioTextSprites[1];
        _gridText.sprite = grid == 5 ? _gridTextSprites[0] : _gridTextSprites[1];
    }

    public void ChangeGrid()
    {
        int grid = PlayerPrefs.GetInt(PrefsKey.grid);
        grid = grid == 5 ? grid = 7 : grid = 5;
        _gridText.sprite = grid == 5 ? _gridTextSprites[0] : _gridTextSprites[1];

        PlayerPrefs.SetInt(PrefsKey.grid, grid);
        PlayerPrefs.Save();
    }

    public void ChangeSettings()
    {
        bool audio = PlayerPrefs.GetString(PrefsKey.audio) == "Enable" ? true : false;
        audio = !audio;
        _audioText.sprite = audio ? _audioTextSprites[0] : _audioTextSprites[1];

        if (audio)
            PlayerPrefs.SetString(PrefsKey.audio, "Enable");
        else
            PlayerPrefs.SetString(PrefsKey.audio, "Disbale");


    }

    #endregion
}
