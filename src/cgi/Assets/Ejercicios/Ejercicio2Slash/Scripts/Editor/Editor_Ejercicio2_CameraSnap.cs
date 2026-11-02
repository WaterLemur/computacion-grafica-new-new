using UnityEngine;
using UnityEditor;

public class Editor_Ejercicio2_CameraSnap : EditorWindow
{
    private readonly string[] cameraNames = { "Cam1", "Cam2", "Cam3" };

    const string address = "⚙️/ENTREGA 2: Snap Camera";

    [MenuItem(address)]
    public static void ShowWindow()
    {
        GetWindow<Editor_Ejercicio2_CameraSnap>("Camera Switcher");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Active Camera & Align Viewport", EditorStyles.boldLabel);
        GUILayout.Space(10);

        for (int i = 0; i < cameraNames.Length; i++)
        {
            string targetCamName = cameraNames[i];

            if (GUILayout.Button($"Switch to {targetCamName}", GUILayout.Height(40)))
            {
                SwitchAndAlignCamera(targetCamName);
            }
            GUILayout.Space(5);
        }
    }

    private void SwitchAndAlignCamera(string targetName)
    {
        // Find the manager script instance in the scene
        Scene_Ejercicio2Slash manager = Object.FindAnyObjectByType<Scene_Ejercicio2Slash>();

        if (manager == null)
        {
            Debug.LogError("[Camera Switcher] Could not find 'Scene_Ejercicio2Slash' component in the scene.");
            return;
        }

        // Get GameObject references directly from the found manager script
        GameObject cam1 = manager.Cam1;
        GameObject cam2 = manager.Cam2;
        GameObject cam3 = manager.Cam3;

        if (cam1 == null || cam2 == null || cam3 == null)
        {
            Debug.LogError("[Camera Switcher] One or more camera GameObjects are missing/unassigned on the manager script.");
            return;
        }

        GameObject targetCamGo = null;

        // Handle activation and deactivation based on your selection
        if (targetName == "Cam1")
        {
            targetCamGo = cam1;
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
        }
        else if (targetName == "Cam2")
        {
            targetCamGo = cam2;
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
        }
        else if (targetName == "Cam3")
        {
            targetCamGo = cam3;
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
        }

        // Align the Scene View Viewport Camera to the active camera's transform
        if (targetCamGo != null && SceneView.lastActiveSceneView != null)
        {
            SceneView sceneView = SceneView.lastActiveSceneView;
            
            // Match the position and rotation of the viewport using the GameObject's transform
            sceneView.AlignViewToObject(targetCamGo.transform);
            
            // Mark the scene as dirty to ensure Unity updates the visuals instantly
            sceneView.Repaint();
            
            Debug.Log($"[Camera Switcher] Successfully activated and matched viewport to {targetName}.");
        }
    }
}
