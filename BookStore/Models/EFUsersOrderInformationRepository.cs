using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFUsersOrderInformationRepository : IUsersOrderInformationRepository
    {
        private ApplicationDbContext context;

        public EFUsersOrderInformationRepository(ApplicationDbContext cntxt)
        {
            context = cntxt;
        }

        public IQueryable<UsersOrderInformation> Orders => context.Orders
            .Include(o => o.Orders).ThenInclude(o => o.Book);

        public void SaveOrder(UsersOrderInformation OrderInformation)
        {
            context.AttachRange(OrderInformation.Orders.Select(l => l.Book));

            if(OrderInformation.UsersOrderInformationId==0)
            {
                context.Orders.Add(OrderInformation);
            }

            context.SaveChanges();

        }
    }
}
