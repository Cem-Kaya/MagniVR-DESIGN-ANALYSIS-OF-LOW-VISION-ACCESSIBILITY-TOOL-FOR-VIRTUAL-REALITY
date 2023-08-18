using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    public void Load_ENG()
    {
        SceneManager.LoadScene("Test_Room_1");
    }
    public void Load_TR()
    {
        SceneManager.LoadScene("Test_Room_1_TR");
    }
}
