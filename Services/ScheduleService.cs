using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository repo)
        {
            _scheduleRepository = repo;
        }
        public async Task<Schedule> AddScheduleAsync(Schedule schedule)
        {
            return await _scheduleRepository.AddScheduleAsync(schedule);
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _scheduleRepository.GetAllSchedulesAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(Guid scheduleId)
        {
            return await _scheduleRepository.GetScheduleByIdAsync(scheduleId);
        }
    }
}
