using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleDAO scheduleDAO;
        public ScheduleRepository()
        {
            scheduleDAO = new ScheduleDAO();
        }
        public async Task<Schedule> AddScheduleAsync(Schedule schedule)
        {
            return await scheduleDAO.AddAsync(schedule);
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await scheduleDAO.GetAll();
        }

        public async Task<Schedule> GetScheduleByIdAsync(Guid scheduleId)
        {
            return await scheduleDAO.GetScheduleById(scheduleId);
        }
    }
}
