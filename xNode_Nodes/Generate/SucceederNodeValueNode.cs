using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/SucceederNode Value")]
    public partial class SucceederNodeValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.SucceederNode _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.SucceederNode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}