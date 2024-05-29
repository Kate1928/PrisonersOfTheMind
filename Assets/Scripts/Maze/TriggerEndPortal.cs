using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEndPortals : MonoBehaviour
{
    private const string saveKeyPlayer = "PLAYER_DATA";
    private PlayerData data = new PlayerData();
    private void OnTriggerEnter2D(Collider2D penguin) {
        saveHelper.Save(saveKeyPlayer, getPlayerData());
        SceneManager.LoadScene(2);        
    }
    public PlayerData getPlayerData() {
        var playerData = new PlayerData() {
            audioVolume = data.audioVolume,
            level = data.level < 1 ? 1 : data.level,
        };
        return playerData;
    }
}
