﻿using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _repository;
        public PatientService(IPatientRepository patientRepository)
        {
            _repository = patientRepository;
        }
        public async Task<Patient> AddNewPatient(Patient patient)
        {
            return await _repository.AddNew(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _repository.GetPatients();
        }

        public async Task<IEnumerable<Patient>> GetNewPatientsByDateAsync(int date)
        {
            return await _repository.GetNewPatientsByDateAsync(date);
        }

        public async Task<IEnumerable<Patient>> GetNewPatientsByMonthAsync(int month)
        {
            return await _repository.GetNewPatientsByMonthAsync(month);
        }

        public async Task<IEnumerable<Patient>> GetNewPatientsByYearAsync(int year)
        {
            return await _repository.GetNewPatientsByYearAsync(year);
        }

        public async Task<Patient> GetPatientByAccountIdAsync(Guid id)
        {
            return await _repository.GetByAccountId(id);
        }

        public async Task<Patient> GetPatientById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            return await _repository.Update(patient);
        }
    }
}
