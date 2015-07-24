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
        /// Adds a value to nodes with a specific attribute. Value is calculated by Func parameter, this is a parallel implementation
        /// </summary>
        /// <param name="documentHelper">Extended class</param>
        /// <param name="attributeName">atribute that determines which nodes will be selected</param>
        /// <param name="getValue">Function that selects value for the node</param>
        /// <param name="removeAttribute">specifies if the attribute should be removed after inserting value</param>
        public static void ProcessNodesWithAttributeParalell(this IDocumentHelper documentHelper,
            string attributeName, Func<HtmlNode, string> getValue,
            bool removeAttribute = true)
        {
            var nodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            if (nodes == null || nodes.Count()==0) return;
            var nodesAndResults = nodes.AsParallel()
                .AsOrdered()
                .Select(node => new { Node = node, result = getValue(node) });
            foreach (var item in nodesAndResults)
            {
                
                item.Node.RenderValue(item.result);
                if (removeAttribute)
                    item.Node.Attributes.Remove(attributeName);
            }
        }

        /// <summary>
        /// Adds a value to nodes with a specific attribut. Value is calculated by Func parameter, single thread implementation
        /// </summary>
        /// <param name="documentHelper">Extended class</param>
        /// <param name="attributeName">atribute that determines which nodes will be selected</param>
        /// <param name="getValue">Function that selects value for the node</param>
        /// <param name="removeAttribute">specifies if the attribute should be removed after inserting value</param>
        public static void ProcessNodesWithAttribute(this IDocumentHelper documentHelper,
            string attributeName, Func<HtmlNode, string> getValue,
            bool removeAttribute = true)
        {
            var nodes = documentHelper.Document.DocumentNode.SelectNodes(EveMarkupAttributes.GetAttributeQuery(attributeName));
            if (nodes == null || nodes.Count() == 0) return;
            foreach (var item in nodes)
            {
                string value = getValue(item);
                item.RenderValue(value);
                if (removeAttribute)
                    item.Attributes.Remove(attributeName);
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
            if (renderNode.Attributes.Contains(EveMarkupAttributes.RenderInstead))
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
    }
}
