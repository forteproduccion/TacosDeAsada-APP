using System.Collections.Generic;

namespace Cotemar.UI.IconsApp
{
    public static class FontAwesomeCollection
    {
        /// <summary>
        /// Initializes the <see cref="FontAwesomeCollection" /> class.
        /// </summary>
        static FontAwesomeCollection()
        {
            Icons.Add(new Icon("UserCircle", '\uf2bd'));
            Icons.Add(new Icon("CreditCard", '\uf09d'));
            Icons.Add(new Icon("Ticket", '\uf3ff'));
            Icons.Add(new Icon("Bell", '\uf0f3'));
            Icons.Add(new Icon("Minus", '\uf068'));
            Icons.Add(new Icon("Plus", '\uf067'));
            Icons.Add(new Icon("Times", '\uf00d'));
            Icons.Add(new Icon("Bars", '\uf0c9'));
            Icons.Add(new Icon("ChevronLeft", '\uf053'));
            Icons.Add(new Icon("PowerOff", '\uf011'));
            Icons.Add(new Icon("AngleRight", '\uf105'));
            Icons.Add(new Icon("AngleLeft", '\uf104'));
            Icons.Add(new Icon("SignOutAlt", '\uf2f5'));
            Icons.Add(new Icon("Gamepad", '\uf11b'));
            Icons.Add(new Icon("Menu", '\uf2e7'));
            Icons.Add(new Icon("User", '\uf007'));
            Icons.Add(new Icon("CutBox", '\uf53d'));
            Icons.Add(new Icon("Delete", '\uf2ed'));
            Icons.Add(new Icon("Edit", '\uf044'));
            Icons.Add(new Icon("Back",'\uf053'));


        }

        /// <summary>
        /// Gets the icons.
        /// </summary>
        /// <value>
        /// The icons.
        /// </value>
        public static IList<IIcon> Icons { get; } = new List<IIcon>();
    }
}
