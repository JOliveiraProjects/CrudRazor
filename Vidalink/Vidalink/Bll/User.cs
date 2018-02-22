using System;
using System.Collections.Generic;
using System.Linq;
using Vidalink.Models;

namespace Vidalink.Bll
{
    public class User : VidalinkBase
    {
        public virtual Data.UserProfile Login(Data.UserProfile user)
        {
            using (var db = Context())
            {
                var model = db.UserProfile.FirstOrDefault(x => x.Active && x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));

                if (model != null)
                {
                    return model;
                }

                return null;
            }
        }
    }
}
