using Kamban.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamban.API.Controllers
{
    public class EquipesController : Controller
    {
        private IEquipeService _equipeService;

        public EquipesController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }
    }
}
