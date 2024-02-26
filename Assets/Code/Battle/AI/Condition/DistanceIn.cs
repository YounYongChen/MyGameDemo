using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

[Category("Custom")]
public class DistanceIn : ConditionTask
{

    public BBParameter<TransformAnchor> _targetTransform;

    public float distance = 0;
    private Transform _currentTransform;


    protected override string info
    {
        get
        {
            return "Check distance in under:" + distance.ToString();
        }
    }

    protected override string OnInit()
    {
        _currentTransform = agent.GetComponent<Transform>();

        return base.OnInit();
    }

    protected override bool OnCheck()
    {
        TransformAnchor anchor = _targetTransform.value;
        if (anchor != null && anchor.isSet) {
            return Vector3.Distance(_currentTransform.position, anchor.Value.position) <= distance;
        }
        return false;

    }
}