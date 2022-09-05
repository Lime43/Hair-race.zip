using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public enum GameState { wait,play,end};
    public GameState currentGameState;
    //Reference
    public static GameManagers instance;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startPlay()
    {
        currentGameState = GameState.play;
    }public void endPlay()
    {
        currentGameState = GameState.end;
    }
}
