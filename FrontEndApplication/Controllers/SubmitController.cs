using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FrontEndApplication.Controllers

{
    public class Data
    {
        public string Code { get; set; }
        public int Id { get; set; }
    }

    public class SubmitController : Controller
    {
        public string urlCompiler = "https://45f300de.compilers.sphere-engine.com/api/v4";
        public string problemsCompiler = "https://45f300de.problems.sphere-engine.com/api/v4";
        public string compilerToken = "7cddeddad0b2f464f210adca7d0bf758";
        public string problemsToken = "925239c48681010a0c5e96dfb1405e66";

        // GET: Submit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Submit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Submit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Submit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult<string> Submit(IFormCollection form)
        {
            string secret = "d3ce6e50c86c80ad60f3e741c1db12c704d1c1a4";
            string s = form["code"];

            string path = System.IO.Directory.GetCurrentDirectory();

            string filePath = path + "/test.py";





            //write file

            System.IO.File.WriteAllText(@""+filePath, s);

            using (FileStream fs = new FileStream(@"" + filePath, FileMode.OpenOrCreate))
            {
                string source = filePath;

                string input = "input data";

                var client = new RestClient(urlCompiler);

                var request = new RestRequest("submissions", Method.POST);
                //request.AddHeader("Content-Type", "multipart/form-data");
                // request.AddFile("file",filePath);
                //request.AddHeader("compilerId", "2");
                request.AddParameter("compilerId", "2");
                request.AddJsonBody(
                    new
                    {
                        compilerId = 2,
                        source = fs.ToString()
                    }); ;
             


                

                request.AddQueryParameter("access_token", compilerToken); // replaces matching token in request.Resource
                


                IRestResponse response = client.Execute(request);

                string data = response.Content;

                JObject jo = JObject.Parse(data);

                int x = (int)jo["id"];









            }



           // var jsonObject = JObject.Parse("{'client_secret': "+secret+"}");

           // var request = new RestRequest(Method.POST);
           // request.RequestFormat = DataFormat.Json;

            //curl -X POST -F "problemId=1" -F "compilerId=1" -F "source=@prog.cpp" "https://45f300de.compilers.sphere-engine.com/api/v4/submissions?access_token=7cddeddad0b2f464f210adca7d0bf758"


            return s;
        }


        public ActionResult<string> Submit1([FromQuery] string value)
        {
            return value;
        }
       


        // GET: Submit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Submit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Submit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Submit/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}