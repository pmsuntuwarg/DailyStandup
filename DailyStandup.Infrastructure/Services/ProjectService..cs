﻿using DailyStandup.Entities.Models;
using DailyStandup.Entities.Models.Standup;
using DailyStandup.Entities.ViewModels.Standup;
using DailyStandup.Infrastructure.Interfaces.IRepository;
using DailyStandup.Infrastructure.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository _repository;

        public ProjectService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public Task<DataResult> Create(ProjectViewModel viewModel)
        {
            Project model = new Project
            {
                Name = viewModel.Name,
                ShortDescription = viewModel.ShortDescription,
                LongDescription = viewModel.LongDescription,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsArchieved = false
            };

            return _repository.Create<Project>(model);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll(string day = null)
        {
           return await (from project in _repository.GetAllAsync<Project>()
                          select new ProjectViewModel
                          {
                              Id = project.Id,
                              Name = project.Name,
                              ShortDescription = project.ShortDescription,
                              LongDescription = project.LongDescription
                          }).ToListAsync();
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            Project model = await _repository.GetById<Project, Guid>(id);

            return new ProjectViewModel
            {
                Id = model.Id,
                Name = model.Name,
                LongDescription = model.LongDescription,
                ShortDescription = model.ShortDescription
            };
        }

        public Task<DataResult> Update(ProjectViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
