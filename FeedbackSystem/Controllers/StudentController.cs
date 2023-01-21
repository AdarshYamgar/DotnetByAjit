using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FeedbackSystem.Models;
using DAL;
using BOL;

namespace FeedbackSystem.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public StudentController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetAllStudent()
    {
        List<Student> data = dbmanager.getstudent();
        ViewData["Get"] =data;
        return View();
    }

    public IActionResult Insertstudent(int id,string name,string email,string password)
    {
        Student stud=new Student(){
            Sid=id, Sname=name,Semail=email,Spassword=password
        };
       dbmanager.insertstd(stud);
       return View();
    }
    public IActionResult Delstudent(int id)
    {
        
       dbmanager.deletestd(id);
       return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
