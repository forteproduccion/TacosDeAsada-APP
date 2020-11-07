using Cotemar.Models.Spartane;
using System.Collections.Generic;

namespace Cotemar.Testing
{
    /*
     Rol
        adm = Administrador
        usr = usuario
     */
    class TestClass
    {
        public List<UsersModel> usrsTest;
        public TestClass() {
            usrsTest = new List<UsersModel>();
            initVars();
        }
        private void initVars() {
            usrsTest.Add(new UsersModel()
            {
                Id = 1234,
                Name = "Juan Pablo",
                Password = "1",
                Rol = "adm",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1285,
                Name = "Juan Perez",
                Password = "2",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1235,
                Name = "Rosa Melchacho",
                Password = "3",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1236,
                Name = "Benito Camelo",
                Password = "4",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1237,
                Name = "Juan Pelardo",
                Password = "5",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1238,
                Name = "Daniel Parra",
                Password = "6",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });

        }
    }
}
