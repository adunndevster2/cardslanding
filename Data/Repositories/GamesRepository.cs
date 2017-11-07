using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cardslanding.Data;
using cardslanding.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cardslanding.Data.Repositories
{
    public class GamesRepository
    {
        private readonly ApplicationDbContext _context;

        public GamesRepository(ApplicationDbContext db )
        {
            _context = db;
        }

        public List<Game> GetAllPublicGames()
        {
            return _context.Games.Where(oo => oo.IsPublic).ToList();
        }


    }

}