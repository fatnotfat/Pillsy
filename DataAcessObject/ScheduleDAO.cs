using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class ScheduleDAO
    {
        private readonly PillsyDBContext _context;
        public ScheduleDAO()
        {

            _context = new PillsyDBContext();

        }

        public async Task<IEnumerable<Schedule>> GetAll()
        {
            try
            {
                var schedules = await _context.Schedules.ToListAsync();
                if (schedules == null)
                {
                    throw new Exception("No content found!");
                }
                return schedules;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Schedule> GetScheduleById(Guid scheduleId)
        {
            try
            {
                var result = await GetAll();
                if (result.Count() < 1)
                {
                    throw new Exception("The list is empty!");
                }
                var schedule = await _context.Schedules.FirstOrDefaultAsync(p => p.ScheduleId.Equals(scheduleId));
                if (schedule == null)
                {
                    throw new Exception("No content found!");
                }
                return schedule;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Schedule> AddAsync(Schedule schedule)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.AddAsync(schedule);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            return schedule;
        }
    }
}
