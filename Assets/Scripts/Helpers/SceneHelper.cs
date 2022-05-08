using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Helpers
{
    public class SceneHelper
    {
        public static void LoadNextScene()
        {
            int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextBuildIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextBuildIndex = 0;
            }

            SceneManager.LoadScene(nextBuildIndex);
        }

        public static void ReloadCurrentScene()
        {
            int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentBuildIndex);
        }
    }
}
