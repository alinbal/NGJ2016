using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField]
    UILabel _scoreLabel;
    [SerializeField]
    UILabel _multiplierLabel;
    [SerializeField]
    UILabel _hpLabel;
    [SerializeField]
    UILabel _endScreenScore;
    [SerializeField]
    HUDText _multiplierHUDText;
    private int _score = 0;
    private int _hp = 100;
    [SerializeField]
    GameObject _endOverlay;
    public int hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = (int)Mathf.Clamp(value,0,float.MaxValue);
            _hpLabel.text = _hp + "";
            if (_hp <= 0)
            {
                //stop game
                _endOverlay.SetActive(true);
                _endScreenScore.text = "" + _score;
                isGameOver = true;
            }
        }
    }
    public int score
    {
        get
        {
            return _score;
        }

        set
        {
            var delta = value - _score;
            if (delta > 0)
            {
                _score += delta * multiplier;
                currentStreak++;
            }
            else
            {
                _score = value;
            }
            
            _scoreLabel.text = _score + "";
            if (currentStreak > 5)
            {
                currentStreak = 0;
                IncreaseMultiplier();
            }
        }
    }

    public float speedMultiplier = 0;
    public float maxSpeedMultiplier = 3;

    public float acceleration = 1f;

    public bool isGameOver = false;

    public int multiplier = 0;
    private int currentStreak;

    public AudioSource audioSource;
    private static GameController _gameController;
    public bool _startedMusic;
    public static GameController instance
    {
        get
        {
            return _gameController;
        }
    }
    
    //Break the multiplier
    public void BreakMultiplier()
    {
        multiplier = 0;
        _multiplierLabel.text = multiplier + "x";
        if (currentStreak > 0)
        {
            _multiplierHUDText.Add("Lost Multiplier", Color.red, 0.6f);
        }
        currentStreak = 0;
    }

    public void IncreaseMultiplier()
    {
        multiplier += 10;
        _multiplierLabel.text = multiplier + "x";

        _multiplierHUDText.Add(multiplier + "x Multiplier",Color.yellow,0.6f);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _gameController = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += acceleration * Time.deltaTime;

        if (speedMultiplier > maxSpeedMultiplier)
            speedMultiplier = maxSpeedMultiplier;
    }

    public void StartMusic()
    {
        if (!_startedMusic)
        {
            //Camera.main.GetComponent<AudioSource>().Play();
            _startedMusic = true;
        }
    }

    public void RestartGame()
    {
        score = 0;
        hp = 0;
        currentStreak = 0;
        multiplier = 0;
        _endOverlay.SetActive(false);
        isGameOver = false;
        Application.LoadLevel(0);
    }
}
