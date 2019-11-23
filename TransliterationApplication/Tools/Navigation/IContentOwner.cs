using System.Windows.Controls;

namespace Transliteration.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
