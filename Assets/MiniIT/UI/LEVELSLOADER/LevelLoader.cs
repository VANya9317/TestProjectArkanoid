using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace MiniIT.UI.LEVELSLOADER
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Animator animatorLevelLoader;
        [SerializeField] private float transitionTime;
        
        private static readonly int Enabled = Animator.StringToHash("Enabled");

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoad()
        {
            AnalyticsEvent.debugMode = true;
            InitLoader();
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private static void InitLoader()
        {
            SceneManager.LoadScene("LevelLoader", LoadSceneMode.Additive);
        }

        public void LoadLevel(string sceneName)
        {
            StartCoroutine(StartAnimation(sceneName));
        }

        private IEnumerator StartAnimation(string sceneName)
        {
            animatorLevelLoader.SetBool(Enabled, true);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(sceneName);
            animatorLevelLoader.SetBool(Enabled, false);
        }
    }
}