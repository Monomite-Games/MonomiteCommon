using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monomite.Common
{
    public class SceneLoadManager : MonoBehaviour
    {
        #region Singleton
        public static SceneLoadManager Instance
        {
            get;
            private set;
        }
        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion

        private void Awake()
        {
            CreateSingleton();
        }

        private int CurrentBuildIndex;

        protected virtual void BeforeEachLoad()
        {
            
        }
        protected virtual void AfterEachLoad()
        {
            
        }
        
        public void LoadScene(int sceneBuildIndex)
        {
            LoadLevel(sceneBuildIndex);
        }

        public void RestartScene()
        {
            LoadLevel(CurrentBuildIndex);
        }

        private void LoadLevel(int sceneBuildIndex)
        {
            BeforeEachLoad();

            CurrentBuildIndex = sceneBuildIndex;
            AsyncOperation asyncSceneLoading = SceneManager.LoadSceneAsync(sceneBuildIndex);

            asyncSceneLoading.completed += (var) => AfterEachLoad();
        }
    }
}
