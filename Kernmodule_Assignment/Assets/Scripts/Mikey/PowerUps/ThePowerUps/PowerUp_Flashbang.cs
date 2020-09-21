using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PowerUp_Flashbang : PowerUpBase, IRotateable
{
    /// <summary>
    /// Postprocessing vignette
    /// </summary>
    private Vignette _vin;
    /// <summary>
    /// Reference to the canvas of the scene
    /// </summary>
    private GameObject _canvas;

    /// <summary>
    /// Set the values of the script
    /// </summary>
    /// <param name="flashbangPanel">The Gameobject that connects with the flashbang</param>
    public PowerUp_Flashbang(GameObject flashbangPanel)
    {
        this._canvas = flashbangPanel;
        _name = "test";
        _powerUpList.Add(2, this);
        _vin = Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>();
    }

    /// <summary>
    /// When the powerup is activated this gets called
    /// </summary>
    /// <param name="ball"></param>
    public override void DoAction(GameObject ball)
    {
        Debug.Log("slomo died");

        _vin.intensity.value = 1f;
        _canvas.GetComponent<UnityEngine.UI.Image>().color = new Color(255f, 255, 255, 1f);
        CheckFlashBang();
    }

    /// <summary>
    /// Updates the flashbang effect
    /// </summary>
    public void CheckFlashBang()
    {
        //checks camera vignette intensity if its abvove 0 it will go down
        if (Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>().intensity > 0f)
        {
            _vin.intensity.value = _vin.intensity.value - 0.1f * Time.deltaTime;
        }

        if (_canvas.GetComponent<UnityEngine.UI.Image>().color != new Color(255f, 255f, 255f, 0f))
        {
            _canvas.GetComponent<UnityEngine.UI.Image>().color = Color.Lerp(_canvas.GetComponent<UnityEngine.UI.Image>().color, new Color(255f, 255f, 255f, 0f), 0.7f * Time.deltaTime);
        }
    }

    /// <summary>
    /// Set the color of the powerup
    /// </summary>
    /// <param name="obj"></param>
    public override void PowerUpColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 255.0f, 1.0f, 0.20f);
    }

    /// <summary>
    /// Rotate the gameobject
    /// </summary>
    /// <param name="powerUp"></param>
    public override void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(new Vector3(2, 0, 8) * Time.deltaTime * 40f);
    }
}
