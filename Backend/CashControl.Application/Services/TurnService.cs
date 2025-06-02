using Azure.Core;
using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using CashControl.Infrastructure.Context;
using CashControlSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CashControl.Application.Services
{
    public class TurnService : ITurnService
    {
        //private readonly ICashControlDbContext _db;
        private readonly ITurnRepository _repo;

        public TurnService(ITurnRepository repo)
        {
            _repo = repo;
        }

        public async Task<string?> AddAsync(TurnDto dto)
        {
            var turn = new Turn
            {
                Description = dto.Description,
                DateTurn = dto.DateTurn,
                Cash_CashId = dto.CashId,
                UserGestorId = dto.UserGestorId
            };

            var result = await _repo.AddAsync(turn);

            return result?.ToString();
        }
    }
}