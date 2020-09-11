using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class test : PowerUpBase
{
    private Vignette vin;
    private GameObject canvas;
    public test(GameObject flashbangpanel)
    {
        this.canvas = flashbangpanel;
        name = "test";
        PowerUpList.Add(2, this);
        vin = Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>();
    }

    //the color of the sphere changes, just testing
    public override void DoAction(GameObject ball)
    {
        Debug.Log("slomo died");
        ball.GetComponent<MeshRenderer>().material.color = Color.green;

        vin.intensity.value = 1f;
        canvas.GetComponent<UnityEngine.UI.Image>().color = new Color(255f, 255, 255, 1f);
        CheckFlashBang();
    }

    public void CheckFlashBang()
    {
        if (Camera.main.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>().intensity > 0f)
        {
            vin.intensity.value = vin.intensity.value - 0.1f * Time.deltaTime;
        }
        if (canvas.GetComponent<UnityEngine.UI.Image>().color == new Color(255f, 255f, 255f, 0.2f))
        {
            canvas.GetComponent<UnityEngine.UI.Image>().color = new Color(255f, 255f, 255f, 0.0f);
        }
        if (canvas.GetComponent<UnityEngine.UI.Image>().color != new Color(255f, 255f, 255f, 0f))
        {
            canvas.GetComponent<UnityEngine.UI.Image>().color = Color.Lerp(canvas.GetComponent<UnityEngine.UI.Image>().color, new Color(255f, 255f, 255f, 0f), 0.7f * Time.deltaTime);
        }
    }

    //For now this will set the color of the powerup
    public override void Test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 255.0f, 1.0f, 0.20f);
    }

    public override void Rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(2, 0, 8) * Time.deltaTime * 40f);
    }
}
