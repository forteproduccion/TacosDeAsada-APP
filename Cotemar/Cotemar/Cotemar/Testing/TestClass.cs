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
                password = "1",
                Rol = "adm",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1285,
                Name = "Juan Perez",
                password = "2",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1235,
                Name = "Rosa Melchacho",
                password = "3",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1236,
                Name = "Benito Camelo",
                password = "4",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1237,
                Name = "Juan Pelardo",
                password = "5",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });
            usrsTest.Add(new UsersModel()
            {
                Id = 1238,
                Name = "Daniel Parra",
                password = "6",
                Rol = "usr",
                UrlImage = "DefaultUserImage.png"
            });

        }
    }
}
