﻿using DailyStandup.Entities.Models;
using DailyStandup.Entities.Models.Standup;
using DailyStandup.Entities.ViewModels.Standup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.Interfaces.IServices
{
    public interface IObstacleService
    {
        Task<DataResult> Create(ObstacleViewModel viewModel);
        Task<DataResult> Update(ObstacleViewModel viewModel);
        Task<IEnumerable<Obstacle>> GetAll(string day = null);
        Task<Obstacle> GetById(Guid id);
    }
}