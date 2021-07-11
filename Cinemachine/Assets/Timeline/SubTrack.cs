using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

[TrackBindingType(typeof(Text))] //绑定组件类型,可以添加text的track
[TrackClipType(typeof(SubClip))]//实现添加clip
public class SubTrack : TrackAsset
{

}
