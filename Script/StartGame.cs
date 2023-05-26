using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void batDau()
    {
        SceneManager.LoadScene("Man1");
    }

    public void reloadManChoi()
    {
        // Lấy tên của scene hiện tại đang được active lên là cái gì thì sẽ lấy tên đấy
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
}
