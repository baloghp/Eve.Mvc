using System.Collections.Generic;

namespace EVE.Mvc.ViewEngine
{
    public interface ISection
    {
        IList<string> Contents { get; }
        string Name { get; set; }
        bool RenderInstead { get; set; }
    }
}