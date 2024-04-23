using UnityEngine;

namespace Common.Util
{
    public interface IUnityObject
    {
        Transform transform { get; }
        GameObject gameObject { get; }
    }
}