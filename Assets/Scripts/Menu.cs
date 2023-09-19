using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public EnumManager.Scene scene;
    public void PlayButton()
    {
        Data data = new Data();
        data.LoadScene(scene);
    }
}
