using MessageService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Domain.Repositories
{
    public interface IActivityRepository
    {
        Activity Load(ActivityId id);
        void Create(Activity activity);
        void UpdateActionUrl(Activity activity);
        void Delete(ActivityId id);
    }
}
