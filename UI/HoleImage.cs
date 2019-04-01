/*
 * @Description: 挖洞的image,该脚本需要放在mask的子UI上才能正确使用
 * @Author: ookuro19 
 * @Date: 2018-09-30 14:05:20 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2018-09-30 14:23:47
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class HoleImage : Image
{
    public override Material GetModifiedMaterial(Material baseMaterial)
    {
        var toUse = baseMaterial;

        if (m_ShouldRecalculateStencil)
        {
            var rootCanvas = MaskUtilities.FindRootSortOverrideCanvas(transform);
            m_StencilValue = maskable ? MaskUtilities.GetStencilDepth(transform, rootCanvas) : 0;
            m_ShouldRecalculateStencil = false;
        }

        // if we have a enabled Mask component then it will
        // generate the mask material. This is an optimisation
        // it adds some coupling between components though :(
        Mask maskComponent = GetComponent<Mask>();
        if (m_StencilValue > 0 && (maskComponent == null || !maskComponent.IsActive()))
        {
            var maskMat = StencilMaterial.Add(toUse, (1 << m_StencilValue) - 1, StencilOp.Keep, CompareFunction.NotEqual, ColorWriteMask.All, (1 << m_StencilValue) - 1, 0);
            StencilMaterial.Remove(m_MaskMaterial);
            m_MaskMaterial = maskMat;
            toUse = m_MaskMaterial;
        }
        return toUse;
    }
}