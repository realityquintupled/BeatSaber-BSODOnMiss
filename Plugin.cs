using IllusionPlugin;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crash_On_Miss {
    public class Plugin : IPlugin {
        public string Name => "Crash On Miss";
        public string Version => "0.0.1";

        public BeatmapObjectSpawnController Resouces { get; private set; }

        public void OnApplicationStart() {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) {
            BeatmapObjectSpawnController[] beatmapObjectSpawnControllers = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>();
            BeatmapObjectSpawnController beatmapObjectSpawnController = beatmapObjectSpawnControllers.Length > 0 ? beatmapObjectSpawnControllers?[0] : null;
            if(beatmapObjectSpawnController != null) {
                beatmapObjectSpawnController.noteWasMissedEvent += delegate (BeatmapObjectSpawnController beatmapObjectSpawnController2, NoteController noteController) { if (noteController.noteData.noteType != NoteType.Bomb) new OhNo(); };
                beatmapObjectSpawnController.noteWasCutEvent += delegate (BeatmapObjectSpawnController beatmapObjectSpawnController2, NoteController noteController, NoteCutInfo noteCutInfo) { if (!noteCutInfo.allIsOK) new OhNo(); };
            }
        }

        public void OnApplicationQuit() {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level) {

        }

        public void OnLevelWasInitialized(int level) {
        }

        public void OnUpdate() {
        }

        public void OnFixedUpdate() {
        }
    }
}
