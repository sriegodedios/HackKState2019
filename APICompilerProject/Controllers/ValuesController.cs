﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IronPython;
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;

namespace APICompilerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            /* int a = 1;
             int b = 2;



             Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine(); // allow us to run ironpython programs
             Microsoft.Scripting.Hosting.ScriptScope s = py.CreateScope(); // you need this to get the variables
             py.Execute("x = " + a + "+" + b, s);

             return s.GetVariable("x");*/

            return PythonInterpreter(0, 0);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        public string PythonInterpreter(int x, int y)
        {
            string pythonInterpreter = @"C:\Users\shanerd\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Python 3.8";
            string fileName = "test.py";
            //int x = 2;
            //int y = 5;

            ProcessStartInfo start = new ProcessStartInfo(fileName);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.Arguments = fileName + " " + x + " " + y;
            start.FileName = pythonInterpreter;

            Process process = new Process();
            process.StartInfo = start;
            process.Start();

            StreamReader stream = process.StandardOutput;
            string result = stream.ReadLine();
            return result;
        }
    }
}
