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
        private static ScheduleDAO instance = null;

        public static ScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScheduleDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Schedule>> GetAll()
        {
            try
            {
                var _context = new PillsyDBContext();
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
                var _context = new PillsyDBContext();
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
    }
}
