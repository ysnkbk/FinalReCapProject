using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EntityUseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new EntityUseContext();
            var result=from operationClaim in context.OperationsClaims
                       join userOperationClaim in context.UserOperationClaims
                       on operationClaim.Id equals userOperationClaim.Id
                       where userOperationClaim.UserId==user.Id
                       select new OperationClaim { Id=operationClaim.Id,Name=operationClaim.Name};
            return result.ToList();
        }
    }
}