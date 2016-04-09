using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
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
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _gameController = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMusic()
    {
        if (!_startedMusic)
        {
            //Camera.main.GetComponent<AudioSource>().Play();
            _startedMusic = true;
        }
    }
}
