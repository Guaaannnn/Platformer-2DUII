using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayAction()
   {
    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
   }
}