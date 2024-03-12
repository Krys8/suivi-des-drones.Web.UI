using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {/// <summary>
     /// Vérifie la présence d'un utilisateur par son email et son mot de passe (hashé)
     /// </summary>
     /// <param name="user"></param>
        CompleteUser LogIn(AuthenticationUser user);
    }
}
