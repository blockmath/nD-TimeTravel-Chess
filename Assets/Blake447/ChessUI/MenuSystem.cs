using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    static MenuSystem menu;
    
    #region Major Object References

    [SerializeField] GameObject persistent; // The button to open and close the menu.
    [SerializeField] GameObject toggled; // The menu, which is opened and closed by the button.



    #endregion
    
    #region Variant Data / Functions

    // NOTE: I have a very good reason for mixing snake case and camel case here.
    [SerializeField] TextMeshProUGUI text_boardDimension;
    [SerializeField] TextMeshProUGUI text_gameDimension;

    bool isMVTT;
    bool isFLE;
    
    int variantBoardSelected;

    int variantSetupSelected;

    public void ActionUpdateIsMVTT(bool value) {
        isMVTT = value;
    }

    public void ActionUpdateIsFLE(bool value) {
        isFLE = value;
    }

    public void ActionUpdateVariantBoardSelected(int value) {
        variantBoardSelected = value;
    }

    public void ActionUpdateVariantSetupSelected(int value) {
        variantSetupSelected = value;
    }



    #endregion


    #region Singleplayer Data / Functions 
    string filename;

    public void ActionTriggerStartLocal() {

    }

    public void ActionTriggerStartEditor() {

    }

    public void ActionUpdateFileName(string value) {
        filename = value;
    }

    public void ActionTriggerSaveFile() {
        GameInstance game = FindObjectOfType<GameInstance>();
        if (game != null) {
            if (filename != "") {
                game.SaveGame(filename);
            } else {
                Debug.Log("Filename is empty. Please specify a save filename.");
            }
        } else {
            Debug.LogError("No game instance found to save. Is there a game running?");
        }
    }

    public void ActionTriggerLoadFile() {
        GameInstance game = FindObjectOfType<GameInstance>();
        if (game != null) {
            if (filename != "") {
                game.LoadGame(filename);
            } else {
                Debug.Log("Filename is empty. Please specify a save filename.");
            }
        } else {
            Debug.LogError("No game instance found to load into. Is there a game running?");
        }
        toggled.SetActive(false);
    }

    public void ActionTriggerLeaveCurrentGame() {

    }

    #endregion

    #region Multiplayer Data / Functions

    string username;
    string lobbyname;

    public void ActionUpdateUsername(string value) {
        username = value;
    }

    public void ActionUpdateRoomName(string value) {
        lobbyname = value;
    }

    public void ActionTriggerHostMultiplayer() {

    }

    public void ActionTriggerJoinMultiplayer() {

    }

    #endregion

    #region Major Menu Functions
    // Start is called before the first frame update
    void Awake()
    {
        // Construct singleton menu
        if (menu == null) {
            DontDestroyOnLoad(this.gameObject);
            menu = this;
        } else {
            Destroy(this.gameObject);
        }
        
#if UNITY_ANDROID
        Screen.orientation = ScreenOrientation.LandscapeLeft;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActionTriggerToggleMenu() {
        toggled.SetActive(!toggled.activeInHierarchy);
    }

    #endregion
}
