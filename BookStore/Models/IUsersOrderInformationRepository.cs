using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
   public interface IUsersOrderInformationRepository
    {
        IQueryable<UsersOrderInformation> Orders { get; }

        void SaveOrder(UsersOrderInformation OrderInformation);

    }
}
