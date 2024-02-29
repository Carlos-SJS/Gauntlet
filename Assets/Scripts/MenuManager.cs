using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager: MonoBehaviour{
    public GameObject[] starts;
    int selected = -1;

    public AudioClip bell;
    private AudioSource asource;
    void Update(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x == 1) select(0);
        else if(x == -1) select(1);
        else if(y == 1) select(2);
        else if(y == -1) select(3);
        else if(selected != -1 && Input.GetKeyDown(KeyCode.Return)) startGame();

        asource = GameObject.Find("audio").GetComponent<AudioSource>();
        DontDestroyOnLoad(GameObject.Find("audio"));
    }

    void select(int ix){
        selected = ix;
        for(int i=0; i<4; i++)
            if(i == ix) starts[i].SetActive(true);
            else starts[i].SetActive(false);
    }

    void startGame(){
        GameState.character = selected;
        GameState.score = 0;
        GameState.hp = 700;
        GameState.pots = 0;
        GameState.keys = 0;


        asource.clip = bell;
        asource.Play();
        SceneManager.LoadScene("Level 1");
    }
}