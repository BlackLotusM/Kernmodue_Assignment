using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PowerUp_Flashbang : PowerUpBase, IRotateable
{
    private Vignette _vin;
    private GameObject _canvas;

    public PowerUp_Flashbang(GameObject flashbangPanel)
    {
        this._canvas = flashbangPanel;
        _name = "test";
        _powerUpList.Add(2, this);
        _vin = Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>();
    }

    //the color of the sphere changes, just testing
    public override void DoAction(GameObject ball)
    {
        Debug.Log("slomo died");

        _vin.intensity.value = 1f;
        _canvas.GetComponent<UnityEngine.UI.Image>().color = new Color(255f, 255, 255, 1f);
        CheckFlashBang();
    }

    //Updates the flashbang effect
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

    //For now this will set the color of the powerup
    public override void PowerUpColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 255.0f, 1.0f, 0.20f);
    }

    public override void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(new Vector3(2, 0, 8) * Time.deltaTime * 40f);
    }
}
