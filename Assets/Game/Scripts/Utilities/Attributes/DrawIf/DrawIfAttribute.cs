using UnityEngine;
using System;

namespace Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class DrawIfAttribute : PropertyAttribute
    {
        #region Fields

        public string comparedPropertyName { get; private set; }
        public object comparedValue { get; private set; }
        public Type type { get; private set; }

        /// <summary>
        /// Types of comperisons.
        /// </summary>
        public enum Type
        {
            ReadOnly = 2,
            Draw = 3,
            DontDraw = 4
        }

        #endregion

        /// <summary>
        /// Only draws the field only if a condition is met. Supports enum and bools.
        /// </summary>
        /// <param name="comparedPropertyName">The name of the property that is being compared (case sensitive).</param>
        /// <param name="comparedValue">The value the property is being compared to.</param>
        /// <param name="type">The type of disabling that should happen if the condition is NOT met. Defaulted to DisablingType.DontDraw.</param>
        public DrawIfAttribute(string comparedPropertyName, object comparedValue, Type type = Type.Draw)
        {
            this.comparedPropertyName = comparedPropertyName;
            this.comparedValue = comparedValue;
            this.type = type;
        }
    }
}