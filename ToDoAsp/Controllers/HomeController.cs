using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoAsp.Models;
using ToDoAsp.Models.Records;
using ToDoAsp.Services;

namespace ToDoAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRecordService _recordService;

        public HomeController(ILogger<HomeController> logger, IRecordService recordService)
        {
            _logger = logger;
            _recordService = recordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRecords()
        {
            _logger.Log(LogLevel.Debug, "Get all records request came");
            var serviceResponce = await _recordService.GetRecords(); 
            if(!serviceResponce.Succeed)
            {
                _logger.Log(LogLevel.Debug, serviceResponce.Message);
                return NotFound(serviceResponce.Message);
            }

            return View(serviceResponce.Data.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            _logger.Log(LogLevel.Debug, "Delete record request came");
            var serviceResponce = await _recordService.DeleteRecord(id);
            if (!serviceResponce.Succeed)
            {
                _logger.Log(LogLevel.Debug, serviceResponce.Message);
                return NotFound(serviceResponce.Message);
            }

            return RedirectToAction("GetRecords");
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(Record record)
        {
            _logger.Log(LogLevel.Debug, "Add record Post request came");
            record.CreationTime = DateTime.Now;
            var serviceResponce = await _recordService.AddRecord(record);
            if (!serviceResponce.Succeed)
            {
                _logger.Log(LogLevel.Debug, serviceResponce.Message);
                return NotFound(serviceResponce.Message);
            }

            return Redirect("GetRecords");
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            _logger.Log(LogLevel.Debug, "Add record Get request came");
            return View(new Record());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(Record record)
        {
            _logger.Log(LogLevel.Debug, "Update record Post request came");
            var serviceResponce = await _recordService.UpdateRecord(record);
            if (!serviceResponce.Succeed)
            {
                _logger.Log(LogLevel.Debug, serviceResponce.Message);
                return NotFound(serviceResponce.Message);
            }

            return RedirectToAction("GetRecords");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRecord(int id)
        {
            _logger.Log(LogLevel.Debug, "Update record Get request came");
            var serviceResponce = await _recordService.GetRecord(id);
            if(!serviceResponce.Succeed)
            {
                _logger.Log(LogLevel.Debug, serviceResponce.Message);
                return NotFound(serviceResponce.Message);
            }

            return View(serviceResponce.Data);
        }
    }
}