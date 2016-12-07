using EVE.Mvc.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc
{
    public static class Utils
    {


        /// <summary>
        /// Adds a value to nodes with a specific attribute. Value is calculated by Func parameter, single thread implementation
        /// </summary>
        /// <param name="documentHelper">Extended class</param>
        /// <param name="attributeName">attribute that determines which nodes will be selected</param>
        /// <param name="getValue">Function that selects value for the node</param>
        /// <param name="removeAttribute">specifies if the attribute should be removed after inserting value</param>
        public static void ProcessNodesWithAttribute<T>(this IDocumentHelper<T> documentHelper,
            string attributeName, Func<IDocumentNode, string> getValue,
            bool removeAttribute = true) where T : IDocument
        {
            // first we deal with  nodes that are not renderinsteads in parallel fashion

            //var nodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            var nodes = documentHelper.Document.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            if (nodes != null)
            {
                var nodesAndResult = nodes
                    .Where(n => !n.IsRenderInstead())
                    .AsParallel()
                    .AsOrdered()
                    .Select(n => new
                    {
                        Node = n,
                        Result = getValue(n)
                    });
                foreach (var item in nodesAndResult)
                {

                    item.Node.RenderValue(item.Result);
                    if (removeAttribute)
                        //item.Node.Attributes.Remove(attributeName);
                        item.Node.RemoveAttribute(attributeName);
                       
                }
            }
            // then we take the renderinsteads in sequence
            //var node = documentHelper.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            var node = documentHelper.Document.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            while (node != null)
            {
                node.RenderValue(getValue(node));
                if (removeAttribute)
                    node.RemoveAttribute(attributeName);
                node = documentHelper.Document.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            }

        }
        /// <summary>
        /// Adds a value to nodes with a specific attribute. Value is calculated by Func parameter, single thread implementation
        /// </summary>
        /// <param name="documentHelper">Extended class</param>
        /// <param name="attributeName">Attribute that determines which nodes will be selected</param>
        /// <param name="getValue">Function that selects value for the node</param>
        /// <param name="removeAttribute">specifies if the attribute should be removed after inserting value</param>
        public static void ProcessNodesWithAttributeSequential<T>(this IDocumentHelper<T> documentHelper,
            string attributeName, Func<IDocumentNode, string> getValue,
            bool removeAttribute = true) where T : IDocument
        {
            var nodes = documentHelper.Document.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            if (nodes == null || nodes.Count() == 0) return;
            var notRInodes = nodes.Where(n => !n.IsRenderInstead());
            foreach (var item in notRInodes)
            {
                string value = getValue(item);
                item.RenderValue(value);
                if (removeAttribute)
                    item.RemoveAttribute(attributeName);
            }
            var node = documentHelper.Document.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            while (node != null)
            {
                node.RenderValue(getValue(node));
                if (removeAttribute)
                    node.RemoveAttribute(attributeName);
                node = documentHelper.Document.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            }

        }

        /// <summary>
        /// Renders content for node considering renderinstead, and renderinto attributes
        /// </summary>
        /// <param name="renderNode"></param>
        /// <param name="content"></param>
        public static void RenderValue(this IDocumentNode renderNode, string content)
        {
            //let's see if we should render the current view into the tag, or instead
            // we put the raw markup in there
            if (renderNode.IsRenderInstead())
            {
                //var parent = renderNode.ParentNode;
                //parent.InnerHtml = parent.InnerHtml.Replace(renderNode.OuterHtml, content);
                renderNode.RenderInstead(content);
            }
            else if (renderNode.ContainsAttribute(EveMarkupAttributes.RenderInto))
            {
                //renderNode.InnerHtml += content;
                renderNode.RenderInto(content);
            }
            else
            {
                //renderNode.InnerHtml = content;
                renderNode.Render(content);
            }
        }

        /// <summary>
        /// Determines if a node has the renderinstead attribute
        /// </summary>
        /// <param name="renderNode">the node</param>

        public static bool IsRenderInstead(this IDocumentNode renderNode)
        {
            //return renderNode.Attributes.Contains(EveMarkupAttributes.RenderInstead);
            return renderNode.ContainsAttribute(EveMarkupAttributes.RenderInstead);


        }
    }
}
