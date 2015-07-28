using EVE.Mvc.ViewEngine;
using HtmlAgilityPack;
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
        public static void ProcessNodesWithAttribute(this IDocumentHelper documentHelper,
            string attributeName, Func<HtmlNode, string> getValue,
            bool removeAttribute = true)
        {
            // first we deal with  nodes that are not renderinsteads in parallel fashion

            var nodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            if (nodes != null)
            {
                var nodesAndResult = nodes
                    .Where(n => !n.IsReanderInstead())
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
                        item.Node.Attributes.Remove(attributeName);
                }
            }
            // then we take the renderinsteads in sequence
            var node = documentHelper.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            while (node != null)
            {
                node.RenderValue(getValue(node));
                if (removeAttribute)
                    node.Attributes.Remove(attributeName);
                node = documentHelper.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            }

        }
        /// <summary>
        /// Adds a value to nodes with a specific attribute. Value is calculated by Func parameter, single thread implementation
        /// </summary>
        /// <param name="documentHelper">Extended class</param>
        /// <param name="attributeName">Attribute that determines which nodes will be selected</param>
        /// <param name="getValue">Function that selects value for the node</param>
        /// <param name="removeAttribute">specifies if the attribute should be removed after inserting value</param>
        public static void ProcessNodesWithAttributeSequential(this IDocumentHelper documentHelper,
            string attributeName, Func<HtmlNode, string> getValue,
            bool removeAttribute = true)
        {
            var nodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            if (nodes == null || nodes.Count() == 0) return;
            var notRInodes = nodes.Where(n => !n.IsReanderInstead());
            foreach (var item in notRInodes)
            {
                string value = getValue(item);
                item.RenderValue(value);
                if (removeAttribute)
                    item.Attributes.Remove(attributeName);
            }
            var node = documentHelper.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            while (node != null)
            {
                node.RenderValue(getValue(node));
                if (removeAttribute)
                    node.Attributes.Remove(attributeName);
                node = documentHelper.Document.DocumentNode.SelectSingleNode(EveMarkupAttributes.GetAttributeQueryWithRenderInstead(attributeName));
            }

        }

        /// <summary>
        /// Renders content for node considering renderinstead, and renderinto attributes
        /// </summary>
        /// <param name="renderNode"></param>
        /// <param name="content"></param>
        public static void RenderValue(this HtmlNode renderNode, string content)
        {
            //let's see if we should render the current view into the tag, or instead
            // we put the raw markup in there
            if (renderNode.IsReanderInstead())
            {
                var parent = renderNode.ParentNode;
                parent.InnerHtml = parent.InnerHtml.Replace(renderNode.OuterHtml, content);
            }
            else if (renderNode.Attributes.Contains(EveMarkupAttributes.RenderInto))
            {
                renderNode.InnerHtml += content;
            }
            else
            {
                renderNode.InnerHtml = content;
            }
        }

        /// <summary>
        /// Determines if a node has the renderinstead attribute
        /// </summary>
        /// <param name="renderNode">the node</param>

        public static bool IsReanderInstead(this HtmlNode renderNode)
        {
            return renderNode.Attributes.Contains(EveMarkupAttributes.RenderInstead);


        }
    }
}
