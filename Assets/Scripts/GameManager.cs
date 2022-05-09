using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject col;
    public GameObject stone1;
    public GameObject stone2;
    public Renderer fondo;
    public float velocidad = 2;
    
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public bool start = false;
    

    public bool gameOver = false;

    public List<GameObject> cols;
    public List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        //creating Map
        for (int i=0; i<21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i,-3), Quaternion.identity));
        }

        //create obstacles
        obstacles.Add(Instantiate(stone1, new Vector2(14, -2), Quaternion.identity));
        obstacles.Add(Instantiate(stone2, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false){
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        if (start == true && gameOver == true){
            
            menuGameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.15f,0) * Time.deltaTime;
        
        //move map
        for (int i=0; i<cols.Count; i++)
        {
            if (cols[i].transform.position.x <= -10)
            {
                cols[i].transform.position =new Vector3(10,-3, 0);
            }

            cols[i].transform.position = cols[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
        }
        //moving obstacles
        for (int i=0; i<obstacles.Count; i++)
        {
            if (obstacles[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(11,18);
                obstacles[i].transform.position = new Vector3(randomObs, -2, 0);
            }

            obstacles[i].transform.position = obstacles[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
        }
        }
    }
}
