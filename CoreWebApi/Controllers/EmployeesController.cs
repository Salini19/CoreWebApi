using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreWebApi;
using CoreWebApi.Models;
using CoreWebApi.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using AutoMapper;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IMethods imethods;
        private readonly IMapper _mapper;

        public EmployeesController(IMethods methods,IMapper mapper)
        {
            imethods = methods;
            _mapper = mapper;
        }

        // GET: Employees
        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = imethods.GetAllEmployees();
            //return Ok(employees);  
            var empViewModel = _mapper.Map<List<EmpViewModel>>(employees);
            return Ok(empViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Employee employee = imethods.GetEmployeeByID(id);
            var empViewModel = _mapper.Map<EmpViewModel>(employee);


            return Ok(empViewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmpViewModel employee)
        {
          var emp=  _mapper.Map<Employee>(employee);
            Random r = new Random();
            emp.Id= r.Next();
            emp.Mobile = "7829090209";
            imethods.AddEmp(emp);
            return Ok(emp);
            //imethods.AddEmp(employee);
            //return Ok(employee);
        }


        [HttpPut]
        public IActionResult Edit( Employee employee)
        {
            imethods.UpdateEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            imethods.DeleteEmp(id);
            return Ok();
        }        
    }
}
