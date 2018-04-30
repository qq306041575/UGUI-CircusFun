using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainViewController : MonoBehaviour
{
    public AudioClip DeathSound;
    public AudioClip CoinSound;
    public AudioClip JumpSound;
    public AudioClip MenuSound;
    public AudioClip GameSound;

    AudioSource _sceneAudio;
    BackgroundComponent _circusBackground;
    BarrierController _barrierController;
    JokerController _jokerController;
    GameObject _menuObject;
    GameObject _muteObject;
    GameObject _loseObject;
    Text _scoreText;
    bool _isMute;
    bool _canJump;
    bool _isLose;
    int _coin;

    void Awake()
    {
        _sceneAudio = transform.GetComponent<AudioSource>();
        _circusBackground = transform.Find("CircusBackground").GetComponent<BackgroundComponent>();
        _barrierController = transform.Find("BarrierController").GetComponent<BarrierController>();
        _jokerController = transform.Find("JokerController").GetComponent<JokerController>();
        _menuObject = transform.Find("MenuPanel").gameObject;
        _muteObject = transform.Find("MenuPanel/MuteButton").gameObject;
        _loseObject = transform.Find("LosePanel").gameObject;
        _scoreText = transform.Find("LosePanel/ScoreText").GetComponent<Text>();

        _isMute = PlayerPrefs.GetInt("Mute", 0) == 1;
        if (_isMute)
        {
            _muteObject.SetActive(false);
        }
        else
        {
            _sceneAudio.mute = false;
        }
    }

    void Update()
    {
        var go = _jokerController.GetColliderObject();
        if (go == null || _isLose)
        {
            return;
        }
        if ("FireCollider" == go.name)
        {
            LoseGame();
        }
        else if ("CoinCollider" == go.name)
        {
            AddCoin(go);
        }
        else if ("FloorCollider" == go.name)
        {
            _canJump = true;
        }
    }

    void LoseGame()
    {
        _isLose = true;
        _circusBackground.enabled = false;
        _barrierController.enabled = false;
        _jokerController.enabled = false;
        _scoreText.text = string.Format("{0}", _coin * 100);
        _loseObject.SetActive(true);
        _sceneAudio.PlayOneShot(DeathSound);
    }

    void AddCoin(GameObject go)
    {
        _coin++;
        if (0 == _coin % 20 && _coin < 150)
        {
            _barrierController.AddSpeed();
        }
        go.SetActive(false);
        _sceneAudio.PlayOneShot(CoinSound);
    }

    void Play()
    {
        _circusBackground.enabled = true;
        _barrierController.enabled = true;
        _jokerController.enabled = true;
        _isLose = false;
        _coin = 0;
    }

    public void OnMaskClick()
    {
        if (!_canJump || _isLose)
        {
            return;
        }
        _canJump = false;
        _jokerController.Jump();
        _sceneAudio.PlayOneShot(JumpSound);
    }

    public void OnHomeClick()
    {
        _sceneAudio.clip = MenuSound;
        _sceneAudio.Play();
        _loseObject.SetActive(false);
        _menuObject.SetActive(true);
    }

    public void OnReplayClick()
    {
        Play();
        _loseObject.SetActive(false);
    }

    public void OnPlayClick()
    {
        Play();
        _sceneAudio.clip = GameSound;
        _sceneAudio.Play();
        _loseObject.SetActive(false);
        _menuObject.SetActive(false);
    }

    public void OnMuteClick()
    {
        _isMute = true;
        _muteObject.SetActive(false);
        _sceneAudio.mute = true;
        PlayerPrefs.SetInt("Mute", 1);
    }

    public void OnUnmuteClick()
    {
        _isMute = false;
        _muteObject.SetActive(true);
        _sceneAudio.mute = false;
        PlayerPrefs.SetInt("Mute", 0);
    }
}
