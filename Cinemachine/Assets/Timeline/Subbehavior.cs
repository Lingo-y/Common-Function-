using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Subbehavior : PlayableBehaviour
{
    //之后的clip片段资源将会赋值到这个变量中并且在这个behavior脚本中按照逻辑执行
    public string subtitleText;

    //相当于update方法
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        //info:当前帧传入的数据信息
        //playerData是最后要输出的数据
        Text _text = playerData as Text;
        _text.text = subtitleText;
        _text.color = new Color(0, 0, 0, info.weight);

    }
}
