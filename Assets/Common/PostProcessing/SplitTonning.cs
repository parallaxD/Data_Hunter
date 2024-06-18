using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Common.Game.Player;

public class SplitTonning : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] PlayerHpController playerHpController;
    [SerializeField] private SplitToning _splitTonning;

    void Start()
    {
        volume.profile.TryGet<SplitToning>(out _splitTonning);

        if (playerHpController == null)
        {
            return;
        }

        playerHpController.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDestroy()
    {
        if (playerHpController != null)
        {
            playerHpController.OnHealthChanged -= HandleHealthChanged;
        }
    }

    private void HandleHealthChanged(int currentHp, int maxHp)
    {
        if (currentHp < maxHp * 0.2f)
        {
            float t = Mathf.InverseLerp(0, 20, currentHp);
            Color newColor = Color.Lerp(Color.red, Color.white, t);
            _splitTonning.shadows.value = Color.red;
        }
        else
        {
            _splitTonning.shadows.value = Color.white;
        }
    }
}
