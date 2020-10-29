using System.Collections.Generic;
using System.Linq;

namespace Cotemar.UI.IconsApp
{
    public static class IconExtensions
    {
        public static Icon DefaultIcon => new Icon("UserCircle", '\uf2bd');

        public static void Add(this IList<IIcon> list, string key, char character) => list.Add(new Icon(key, character));

        public static IIcon FindIconForKey(string iconKey)
        {
            if (string.IsNullOrWhiteSpace(iconKey))
            {
                return DefaultIcon;
            }
            return FontAwesomeCollection.Icons.FirstOrDefault(x => x.Key.Equals(iconKey)) ?? DefaultIcon;
        }
        public static string FindNameFileForFont(Icons font)
        {
            switch (font)
            {
                case Icons.BrandsRegular:
                    return "AwesomeBrandsRegular400.otf";

                case Icons.Regular:
                    return "AwesomeRegular400.otf";

                case Icons.Solid:
                    return "AwesomeSolid900.otf";
                case Icons.Light:
                    return "AwesomeProLight300.otf";
                default:
                    return string.Empty;
            }
        }
        public static string FindNameForFont(Icons font)
        {
            switch (font)
            {
                case Icons.BrandsRegular:
                    return "FontAwesome5FreeBrandsRegular";

                case Icons.Regular:
                    return "FontAwesome5FreeRegular";

                case Icons.Solid:
                    return "FontAwesome5FreeSolid";

                case Icons.Light:
                    return "FontAwesome5ProLight";
                default:
                    return string.Empty;
            }
        }
    }
    /// <summary>
    /// Defines the <see cref="Icon" /> type.
    /// </summary>
    /// <seealso cref="IIcon" />
    public class Icon : IIcon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Icon" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="character">The character.</param>
        public Icon(string key, char character)
        {
            Character = character;
            Key = key;
        }

        /// <summary>
        /// The character matching the key in the font, for example '\u4354'
        /// </summary>
        public char Character { get; private set; }

        /// <summary>
        /// The key of icon, for example 'fa-ok'
        /// </summary>
        public string Key { get; private set; }
    }
    /// <summary>
    /// Icon represents one icon in an icon font.
    /// </summary>
    public interface IIcon
    {
        /// <summary>
        /// The character matching the key in the font, for example '\u4354'
        /// </summary>
        /// <returns></returns>
        char Character { get; }

        /// <summary>
        /// The key of icon, for example 'fa-ok'
        /// </summary>
        /// <returns></returns>
        string Key { get; }
    }
    public enum Icons
    {
        Regular,
        Solid,
        BrandsRegular,
        Light
    }
}
