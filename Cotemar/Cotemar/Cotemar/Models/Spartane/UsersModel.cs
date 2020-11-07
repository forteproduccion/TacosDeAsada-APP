
using System.Drawing;

namespace Cotemar.Models.Spartane
{
    public class UsersModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string UrlImage { get; set; }
        public Color BgColor { get; set; }

        public void initEmpty(){
            Id = 0;
            Name = "";
            Password = "";
            Rol = "usr";
            UrlImage = "DefaultUserImage.png";
        }

    }

}
