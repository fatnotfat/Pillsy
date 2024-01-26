using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IScheduleRepository
    {
        public Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        public Task<Schedule> GetScheduleByIdAsync(Guid scheduleId);
        public Task<Schedule> AddScheduleAsync(Schedule schedule);
    }
}
