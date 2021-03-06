﻿using CabinIcarus.IcSkillSystem.Nodes.Editor.Utils;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_Nodes
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(ValueNode))]
    public class ValueNodeEditor:NodeEditor
    {
        private ValueNode _valueNode;
        private NodePort _valueOutPut;
        
        private SimpleTypeSelectPopupWindow windowContent;

        public override void OnInit()
        {
            _valueNode = (ValueNode) target;
            _valueOutPut = _valueNode.GetOutputPort(ValueNode.ValueOutPutPortName);

            if (_valueOutPut != null)
            {
                if (_valueOutPut.ValueType == null)
                {
                    _valueOutPut.ValueType = _valueNode.ValueType;
                }
            }
            
            windowContent = new SimpleTypeSelectPopupWindow(true);
            
            windowContent.OnChangeTypeSelect = type =>
            {
                _valueOutPut.ValueType = type;
                windowContent.editorWindow.Close();
                serializedObject.ApplyModifiedProperties();
                serializedObject.UpdateIfRequiredOrScript();
            };
        }

        public override void OnBodyGUI()
        {
            serializedObject.Update();
            {
                if (_valueOutPut == null)
                {
                    _valueOutPut = _valueNode.AddDynamicOutput(_valueNode.ValueType, fieldName: ValueNode.ValueOutPutPortName);
                }
                
                base.OnBodyGUI();
                
                if (_valueNode.IsChangeValueType)
                {
                    if (GUILayout.Button("Change Type"))
                    {
                        windowContent.BaseType = _valueNode.BaseType;
                        
                        UnityEditor.PopupWindow.Show(new Rect(GetCurrentMousePosition(), new Vector2(0, 0)),
                            windowContent);
                    }
                }
                
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}