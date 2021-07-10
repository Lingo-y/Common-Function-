using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPControl : MonoBehaviour
{

    private PostProcessVolume volume;
    private Vignette vignette;
    //private bool isFading; 
    //[SerializeField] private float fadeSpeed = 0.35f;
    private bool isDamaging;
    private bool isBack;
    [SerializeField] private Color hurtColor;   
    [SerializeField] private float hurtSpeed;

    #region 如何获取

    //void Start()
    //{
    //    volume = GetComponent<PostProcessVolume>();
    //    volume.profile.TryGetSettings(out vignette);
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        //不使用value就要讲floatPara强转float
    //        //vignette.intensity.value = 1.0f;
    //        //override可以退出以后保存设置
    //        //vignette.intensity.Override(1.0f);
    //        //vignette.enabled.Override(false);
    //        isFading = true;

    //    }
    //    if (isFading)
    //    {
    //        vignette.intensity.value += fadeSpeed * Time.deltaTime;
    //        if (vignette.intensity.value >= 0.75f)
    //            isFading = false;
    //    }
    //}

    #endregion

    #region 如何创建
    //private void Start()
    //{
    //    vignette = ScriptableObject.CreateInstance<Vignette>();
    //    vignette.enabled.Override(true);
    //    vignette.intensity.Override(1.0f);
    //    //创建volume对象(渲染层，优先度，要配置的设置)
    //    volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 1, vignette);

    //}
    //private void Update()
    //{
    //    vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    //    Debug.Log(vignette.intensity.value);

    //}
    //private void OnDestroy()
    //{
    //    RuntimeUtilities.DestroyVolume(volume, true, true);
    //}
    #endregion

    #region 受伤效果
    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isDamaging = true;
        if (isDamaging&&isBack == false) {
            vignette.intensity.value += hurtSpeed * Time.deltaTime;
            vignette.color.value = hurtColor;
            if (vignette.intensity.value > 0.75f)
            {
                isDamaging = false;
                isBack = true;
            }
              
        }
        if (isBack)
        {
            vignette.intensity.value -= 5f * hurtSpeed * Time.deltaTime;
            if (vignette.intensity.value <= 0.05)
                isBack = false;

        }
    }
    #endregion

}
