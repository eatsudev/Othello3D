using UnityEngine;
using UnityEngine.SceneManagement;

public class Data
{
    //public EnumManager.Scene destinationScene;
    public int maxPlayerOnRoom = 2;

    public void LoadScene(EnumManager.Scene scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }
}
