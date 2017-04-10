using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc
{
    public interface IDocument : IDocumentNode
    {
        IEnumerable<IDocumentNode> SelectNodes(string xpath);
        IDocumentNode SelectSingleNode(string xpath);
        void Save(TextWriter writer);
        void LoadHtml(string v);
    }
}
