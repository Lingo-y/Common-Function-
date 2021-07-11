using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubClip : PlayableAsset
{
    public string originText;
    //实现抽象类
    //创建资源文件，就是graph，是playable类型，将它反馈出来才能在behavior中使用
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Subbehavior>.Create(graph);
        Subbehavior sb=playable.GetBehaviour();
        sb.subtitleText = originText;
        return playable;


    }
}
