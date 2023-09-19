using UnityEngine;
using UnityEngine.SceneManagement;

public class Data
{
    //public EnumManager.Scene destinationScene;
    
    public void LoadScene(EnumManager.Scene scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }
}
