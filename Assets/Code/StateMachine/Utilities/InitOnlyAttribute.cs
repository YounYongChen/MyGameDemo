using System;
using UnityEngine;

namespace Kill.StateMachine
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InitOnlyAttribute : PropertyAttribute { }
}
