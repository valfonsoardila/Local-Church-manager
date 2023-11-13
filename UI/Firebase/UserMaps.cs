using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud;
using Entity;

namespace UI
{
    public class UserMaps
    {
        UserData data;
        public UserData UserMap(Usuario usuario)
        {
            if (CheckIfUserAlreadyExist(usuario.Identificacion))
            {
                return new UserData() {
                    ID = usuario.Identificacion.Trim(),
                    TypeID = usuario.TipoDeIdentificacion.Trim(),
                    Name = usuario.Nombres,
                    LastName = usuario.Apellidos,
                    Birthdate = usuario.FechaDeNacimiento.ToString(),
                    Age = usuario.Edad.ToString().Trim(),
                    Gender = usuario.Sexo.Trim(),
                    Address = usuario.Direccion,
                    PhoneNumber = usuario.Telefono.Trim(),
                    Rol = usuario.Rol.Trim(),
                    Email = usuario.CorreoElectronico.Trim(),
                    UserName = usuario.NombreUsuario,
                    Password = FirebaseSecurity.Encrypt(usuario.Contraseña),
                    UserCode = FirebaseSecurity.Encrypt(usuario.CodigoUsuario.Trim())
                };
            }
            else
            {
                return new UserData()
                {
                    ID = usuario.Identificacion.Trim(),
                    TypeID = usuario.TipoDeIdentificacion.Trim(),
                    Name = usuario.Nombres,
                    LastName = usuario.Apellidos,
                    Birthdate = usuario.FechaDeNacimiento.ToString(),
                    Age = usuario.Edad.ToString().Trim(),
                    Gender = usuario.Sexo.Trim(),
                    Address = usuario.Direccion,
                    PhoneNumber = usuario.Telefono.Trim(),
                    Rol = usuario.Rol.Trim(),
                    Email = usuario.CorreoElectronico.Trim(),
                    UserName = usuario.NombreUsuario,
                    Password = FirebaseSecurity.Encrypt(usuario.Contraseña),
                    UserCode = FirebaseSecurity.Encrypt(usuario.CodigoUsuario.Trim())
                };
            }
        }

        private bool CheckIfUserAlreadyExist(string idUser)
        {
            //Consulta en la nube
            var db = FirebaseService.Database;
            Google.Cloud.Firestore.DocumentReference docRef = db.Collection("UserData").Document(idUser);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
