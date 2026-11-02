using UnityEngine; 
using UnityEditor; 
using UnityEngine.Playables; 
using UnityEngine.Timeline; 
using UnityEditor.Timeline; 

public class SlashComboMenuTool
{
    const string address = "⚙️/ENTREGA 2: Set scene for";
    const string addressCinema = address + "/🙌 ✋CINEMA✋";
    
    static Scene_Ejercicio2Slash scriptScene;
    static PlayableDirector director;

    // Define the exact names of your parent Group Tracks here
    static readonly string[] groupTrackNames = new string[]
    {
        "Combo Slash Pixel",    // 0
        "Combo Slash Fire",     // 1
        "Combo Slash Water",    // 2
        "Combo Slash Thunder",  // 3
        "Combo Slash Cut",      // 4

        "Stuntgirl"             // 5
    };
    
    static void GetRefs()
    {
        scriptScene = Object.FindAnyObjectByType<Scene_Ejercicio2Slash>();
        director = Object.FindAnyObjectByType<PlayableDirector>();
    }


    static void ConfigureGroupTracks(string groupToEnable)
    {
        if (director == null) return;

        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        if (timelineAsset == null) return;

        Undo.RecordObject(timelineAsset, "Toggle Timeline Groups");

        // flattening all tracks ensures we find groups even if they are nested inside other groups
        foreach (TrackAsset track in timelineAsset.GetRootTracks())
        {
            ProcessTrackRecursively(track, groupToEnable);
        }

        EditorUtility.SetDirty(timelineAsset);
        TimelineEditor.Refresh(RefreshReason.ContentsModified);
    }

    static void ProcessTrackRecursively(TrackAsset track, string groupToEnable)
    {
        if (track is GroupTrack)
        {
            if (track.name.Equals(groupTrackNames[5], System.StringComparison.OrdinalIgnoreCase))
            {
                bool shouldBeActiveForElement = groupToEnable.Equals(groupTrackNames[1], System.StringComparison.OrdinalIgnoreCase) || 
                                                groupToEnable.Equals(groupTrackNames[2], System.StringComparison.OrdinalIgnoreCase) || 
                                                groupToEnable.Equals(groupTrackNames[3], System.StringComparison.OrdinalIgnoreCase);

                track.muted = !shouldBeActiveForElement;
            }
            else
            {
                bool isTargetGroup = track.name.Equals(groupToEnable, System.StringComparison.OrdinalIgnoreCase);
                bool isManagedGroup = false;

                for (int i = 0; i < 5; i++)
                {
                    if (track.name.Equals(groupTrackNames[i], System.StringComparison.OrdinalIgnoreCase))
                    {
                        isManagedGroup = true;
                        break;
                    }
                }

                if (isManagedGroup)
                {
                    track.muted = !isTargetGroup;
                }
            }
        }

        foreach (TrackAsset childTrack in track.GetChildTracks())
        {
            ProcessTrackRecursively(childTrack, groupToEnable);
        }
    }

    // Master method to handle refs, timeline modifications, and script logic
    static void SetSceneForElement(string groupName, System.Action scriptSceneAction)
    {
        GetRefs();
        ConfigureGroupTracks(groupName);
        if (scriptScene != null)
        {
            Undo.RegisterFullObjectHierarchyUndo(scriptScene.gameObject, "Set Combo Scene Option");
            
            scriptSceneAction?.Invoke();
            
            EditorUtility.SetDirty(scriptScene.gameObject);
            Selection.activeGameObject = scriptScene.FXParentObject;
            SceneView.RepaintAll();
        }
    }

    [MenuItem(addressCinema, false, 1)] 
    private static void SetSceneForCinema() 
    { 
        GetRefs();
        if (scriptScene != null)
        {
            Undo.RegisterFullObjectHierarchyUndo(scriptScene.gameObject, "Toggle Cinema Mode");
            scriptScene.IsCinema = !scriptScene.IsCinema;
            
            EditorUtility.SetDirty(scriptScene.gameObject);
            SceneView.RepaintAll();
        }
    } 

    [MenuItem(addressCinema, true, 1)] 
    private static bool SetSceneForCinemaValidate() 
    { 
        GetRefs();
        if (scriptScene != null)
        {
            Menu.SetChecked(addressCinema, scriptScene.IsCinema); 
        }
        return true; 
    } 

    [MenuItem(address + "/" + "👾", false, 20)]
    private static void SetSceneForPixel()
    {
        SetSceneForElement(groupTrackNames[0], () => scriptScene.SetSlashPixel());
    }

    [MenuItem(address + "/" + "🔥", false, 21)]
    private static void SetSceneForFire()
    {
        SetSceneForElement(groupTrackNames[1], () => scriptScene.SetSlashFire());
    }

    [MenuItem(address + "/" + "🌊", false, 22)]
    private static void SetSceneForWater()
    {
        SetSceneForElement(groupTrackNames[2], () => scriptScene.SetSlashWater());
    }

    [MenuItem(address + "/" + "⚡", false, 23)]
    private static void SetSceneForThunder()
    {
        SetSceneForElement(groupTrackNames[3], () => scriptScene.SetSlashThunder());
    }

    [MenuItem(address + "/" + "🩸 *goofy", false, 24)]
    private static void SetSceneForCut()
    {
        SetSceneForElement(groupTrackNames[4], () => scriptScene.SetSlashCut());
    }
}
