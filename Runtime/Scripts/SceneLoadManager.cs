using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monomite.Common
{
    public abstract class SceneLoadManager : MonoBehaviour
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

        protected abstract void BeforeEachLoad();
        protected abstract void AfterEachLoad();

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