using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheSocialNetwork.DomainModel.Interfaces.Repositories
{
    public interface IGroupRepository
    {
        void Create(Group group);
    }
}
